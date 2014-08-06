using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace UnityTests.MDI.ViewModels
{
    public class DocumentListViewModel : Conductor<IDocumentViewModel>.Collection.AllActive, IDocumentListViewModel
    {
        public DocumentListViewModel()
        {
            this.Items.AddRange(new IDocumentViewModel[]
            {
                new DocumentViewModel() { Title = "First"}, 
                new DocumentViewModel() { Title = "Second"}, 
                new DocumentViewModel() { Title = "Third"}, 
            });
        }
    }

    public interface IDocumentListViewModel {}
}
