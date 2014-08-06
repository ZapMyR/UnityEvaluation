using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Ninject;
using UnityTests.MDI.ViewModels;

namespace UnityTests.MDI
{
    public class ShellViewModel : Screen, IShell
    {
        private readonly IEventAggregator _aggregator;
        private IDocumentListViewModel activeView;

        public IDocumentListViewModel ActiveView
        {
            get { return this.activeView; }
            set
            {
                this.activeView = value;
                this.NotifyOfPropertyChange(() => this.ActiveView);
            }
        }

        private ShellViewModel() { }

        public ShellViewModel(IEventAggregator aggregator)
        {
            this._aggregator = aggregator;
            this._aggregator.Subscribe(this);

            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<IDocumentListViewModel>().To<DocumentListViewModel>().InSingletonScope();
                this.ActiveView = kernel.Get<IDocumentListViewModel>();
            }
        }
    }
}