using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;

namespace Company.UnityTests_VisualStudio_Package
{
    public class SelectionEventsListener : IVsSelectionEvents, IDisposable
    {
        private IVsMonitorSelection monitor;
        private uint monitorEventsCookie;

        public event Action SelectionChanged;
        public event Action ElementValueChanged;
        public event Action CmdUIContextChanged;

        public SelectionEventsListener(IServiceProvider serviceProvider)
        {
            InitNullEvents();

            this.monitor = serviceProvider.GetService(typeof(SVsShellMonitorSelection)) as IVsMonitorSelection;
            if (this.monitor != null)
            {
                this.monitor.AdviseSelectionEvents(this, out this.monitorEventsCookie);
            }
        }

        private void InitNullEvents()
        {
            this.SelectionChanged += () => { };
            this.ElementValueChanged += () => { };
            this.CmdUIContextChanged += () => { };
        }
        
        /// <summary>
        /// Reports that the project hierarchy, item and/or selection container has changed.
        /// </summary>
        /// <returns>
        /// If the method succeeds, it returns <see cref="F:Microsoft.VisualStudio.VSConstants.S_OK"/>. If it fails, it returns an error code.
        /// </returns>
        /// <param name="pHierOld">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.IVsHierarchy"/> interface of the project hierarchy for the previous selection.</param><param name="itemidOld">[in] Identifier of the project item for previous selection. For valid <paramref name="itemidOld"/> values, see VSITEMID.</param><param name="pMISOld">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.IVsMultiItemSelect"/> interface to access a previous multiple selection.</param><param name="pSCOld">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.ISelectionContainer"/> interface to access Properties window data for the previous selection.</param><param name="pHierNew">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.IVsHierarchy"/> interface of the project hierarchy for the current selection.</param><param name="itemidNew">[in] Identifier of the project item for the current selection. For valid <paramref name="itemidNew"/> values, see VSITEMID.</param><param name="pMISNew">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.IVsMultiItemSelect"/> interface for the current selection.</param><param name="pSCNew">[in] Pointer to the <see cref="T:Microsoft.VisualStudio.Shell.Interop.ISelectionContainer"/> interface for the current selection.</param>
        public int OnSelectionChanged(
            IVsHierarchy pHierOld,
            uint itemidOld,
            IVsMultiItemSelect pMISOld,
            ISelectionContainer pSCOld,
            IVsHierarchy pHierNew,
            uint itemidNew,
            IVsMultiItemSelect pMISNew,
            ISelectionContainer pSCNew)
        {
            SelectionChanged();
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Reports that an element value has changed.
        /// </summary>
        /// <returns>
        /// If the method succeeds, it returns <see cref="F:Microsoft.VisualStudio.VSConstants.S_OK"/>. If it fails, it returns an error code.
        /// </returns>
        /// <param name="elementid">[in] DWORD value representing a particular entry in the array of element values associated with the selection context. For valid <paramref name="elementid"/> values, see <see cref="T:Microsoft.VisualStudio.VSConstants.VSSELELEMID"/>.</param><param name="varValueOld">[in] VARIANT that contains the previous element value. This parameter contains element-specific data, such as a pointer to the <see cref="T:Microsoft.VisualStudio.OLE.Interop.IOleCommandTarget"/> interface if <paramref name="elementid"/> is set to SEID_ResultsList or a pointer to the <see cref="T:Microsoft.VisualStudio.OLE.Interop.IOleUndoManager"/> interface if <paramref name="elementid"/> is set to SEID_UndoManager.</param><param name="varValueNew">[in] VARIANT that contains the new element value. This parameter contains element-specific data, such as a pointer to the IOleCommandTarget interface if <paramref name="elementid"/> is set to SEID_ResultsList or a pointer to the IOleUndoManager interface if <paramref name="elementid"/> is set to SEID_UndoManager.</param>
        public int OnElementValueChanged(uint elementid, object varValueOld, object varValueNew)
        {
            ElementValueChanged();
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Reports that the command UI context has changed.
        /// </summary>
        /// <returns>
        /// If the method succeeds, it returns <see cref="F:Microsoft.VisualStudio.VSConstants.S_OK"/>. If it fails, it returns an error code.
        /// </returns>
        /// <param name="dwCmdUICookie">[in] DWORD representation of the GUID identifying the command UI context passed in as the <paramref name="rguidCmdUI"/> parameter in the call to <see cref="M:Microsoft.VisualStudio.Shell.Interop.IVsMonitorSelection.GetCmdUIContextCookie(System.Guid@,System.UInt32@)"/>.</param><param name="fActive">[in] Flag that is set to true if the command UI context identified by <paramref name="dwCmdUICookie"/> has become active and false if it has become inactive.</param>
        public int OnCmdUIContextChanged(uint dwCmdUICookie, int fActive)
        {
            CmdUIContextChanged();
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (monitor != null && monitorEventsCookie != 0)
            {
                GC.SuppressFinalize(this);
                monitor.UnadviseSelectionEvents(monitorEventsCookie);
                SelectionChanged = null;
                CmdUIContextChanged = null;
                ElementValueChanged = null;
                monitorEventsCookie = 0;
                monitor = null;
            }
        }
    }
}
