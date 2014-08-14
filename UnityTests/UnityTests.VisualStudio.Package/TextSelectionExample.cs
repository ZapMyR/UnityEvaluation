using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

using Microsoft.VisualStudio.Shell;

namespace Company.UnityTests_VisualStudio_Package
{
    public static class TextSelectionExample
    {
        public static string GetSelectedText()
        {
            string result = "";
            EnvDTE80.DTE2 dte = (EnvDTE80.DTE2)
                System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
            
            var selection = dte.ActiveDocument.Selection as TextSelection;
            var active = selection.ActivePoint as VirtualPoint;

            var activeDoc = dte.ActiveDocument;
            var doc = ((TextDocument) activeDoc).Selection.Text;

            //selection.StartOfLine();
            var col = active.DisplayColumn;
            //selection.EndOfLine();

            return doc.ToString(CultureInfo.InvariantCulture);
        }
    }
}
