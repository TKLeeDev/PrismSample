using Sample.Modules.Views;
using Sample.Modules.Views._Dummy;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Threading;

namespace Sample.ViewModels
{
    class RegionViewModuleViewModel : BindableBase
    {
        //Displaying View from other project.

        IRegionManager _regionManager;
        public RegionViewModuleViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            TimerFunc();
        }

        private DelegateCommand<string> _bCommand;
        public DelegateCommand<string> bCommand =>
            _bCommand ?? (_bCommand = new DelegateCommand<string>(ExecutebCommand));

        void ExecutebCommand(string regionName)
        {
            _regionManager.RegisterViewWithRegion(regionName, typeof(DummyModuleView));
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Displaying View from other project.";
        public string bDescription
        {
            get { return _bDescription; }
            set { SetProperty(ref _bDescription, value); }
        }

        private void TimerFunc()
        {
            //Timer
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            dispatcherTimer.Tick += (s, e) =>
            {
                if (bCount != 100000)
                    bCount++;
            };

            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private int _bCount = 0;
        public int bCount
        {
            get { return _bCount; }
            set { SetProperty(ref _bCount, value); }
        }
        #endregion
    }
}
