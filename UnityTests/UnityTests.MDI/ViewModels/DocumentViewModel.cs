using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace UnityTests.MDI.ViewModels
{
    public class DocumentViewModel : Screen, IDocumentViewModel
    {
        public string Title { get; set; }
    }

    public interface IDocumentViewModel {}
}
