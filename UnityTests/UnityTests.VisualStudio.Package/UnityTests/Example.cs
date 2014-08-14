using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

using EnvDTE80;

using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

using IServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace Company.UnityTests_VisualStudio_Package.UnityTests
{
    public class Example
    {
        public void DoExample()
        {
            System.Type t = System.Type.GetTypeFromProgID("VisualStudio.DTE.9.0");
            object obj = Activator.CreateInstance(t, true);
            var dte = (DTE)obj;
            var serviceProvider = new ServiceProvider(dte as IServiceProvider);
            
            var solutionEventsListener = new SolutionEventsListener(serviceProvider);
            solutionEventsListener.AfterSolutionLoaded += solutionEventsListener_AfterSolutionLoaded;
            solutionEventsListener.BeforeSolutionClosed += solutionEventsListener_BeforeSolutionClosed;

            var selectionEventsListener = new SelectionEventsListener(serviceProvider);
            selectionEventsListener.CmdUIContextChanged += selectionEventsListener_CmdUIContextChanged;
            selectionEventsListener.ElementValueChanged += selectionEventsListener_ElementValueChanged;
            selectionEventsListener.SelectionChanged += selectionEventsListener_SelectionChanged;
        }

        private void selectionEventsListener_SelectionChanged()
        {
        }

        private void selectionEventsListener_ElementValueChanged()
        {
        }

        private void selectionEventsListener_CmdUIContextChanged()
        {
        }

        private void solutionEventsListener_BeforeSolutionClosed()
        {
        }

        private void solutionEventsListener_AfterSolutionLoaded()
        {

        }
    }
}
