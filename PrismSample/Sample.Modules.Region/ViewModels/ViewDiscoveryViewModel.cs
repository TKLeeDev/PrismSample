using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Modules.Region.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Region.ViewModels
{
    class ViewDiscoveryViewModel : BindableBase
    {
        IRegionManager _regionManager;
        public ViewDiscoveryViewModel(RegionManager regionManager)
        {
            TimerFunc();
            _regionManager = regionManager;
        }

        private DelegateCommand _command;
        public DelegateCommand bCommand =>
            _command ?? (_command = new DelegateCommand(ExecutebCommand));

        void ExecutebCommand()
        {
            _regionManager.RegisterViewWithRegion("RegionViewDiscovery_MainRegion", typeof(DummyView));
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "_regionManager.RegisterViewWithRegion(\"[RegionName]\", typeof([ViewName]));\n" +
                "//Bootstrapper.cs에 등록되어 있지 않아도됨. \n" +
                "//객체를 지정하지 않고 typeof([ViewName])과 같이 Type만 지정해주면 알아서 호출함.";
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
