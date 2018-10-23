using Sample.Modules.Views;
using Sample.Modules.Views._Dummy;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Views;
using System;
using System.Windows;
using System.Windows.Threading;

namespace Sample.ViewModels
{
    class RegionViewActiveDeactiveViewModel : BindableBase
    {


        IUnityContainer _container;
        IRegionManager _regionManager;
        IRegion _region1;
        IRegion _region2;


        DummyModuleView dmv1;
        DummyModuleView dmv2;

        public RegionViewActiveDeactiveViewModel(IUnityContainer containter, IRegionManager regionManager)
        {
            TimerFunc();
            _container = containter;
            _regionManager = regionManager;
        }

        private DelegateCommand _bLoaded;
        public DelegateCommand bLoaded =>
            _bLoaded ?? (_bLoaded = new DelegateCommand(ExecutebLoaded));

        void ExecutebLoaded()
        {
            
            dmv1 = _container.Resolve<DummyModuleView>();
            dmv2 = _container.Resolve<DummyModuleView>();

            ////addName
            //dv1.Name = "a123";
            //dv2.Name = "a456";

            _region1 = _regionManager.Regions["ViewActiveDeactive_Region1"];
            _region2 = _regionManager.Regions["ViewActiveDeactive_Region2"];

            //_region1.Add(dv1);
            //_region2.Add(dv2);
        }


        private DelegateCommand<string> _bCommand;
        public DelegateCommand<string> bCommand =>
            _bCommand ?? (_bCommand = new DelegateCommand<string>(ExecutebCommand1));
        void ExecutebCommand1(string param)
        {
            //? Deactive 또는 Active를 해도 계속해서 VM의 루프가 도는데 그렇다면 Active/Deactive의미는?

            switch (SpliteCommandParameter(param).what)
            {
                case "Add":
                    var theView = _regionManager.Regions[SpliteCommandParameter(param).regionName].GetView("Dummy123");
                    if (theView != null)
                    {
                        MessageBox.Show("View Duplicated");
                        break;
                    }
                    _regionManager.Regions[SpliteCommandParameter(param).regionName].Add(new DummyView(), "Dummy123");
                    break;
                case "Active":
                    theView = _regionManager.Regions[SpliteCommandParameter(param).regionName].GetView("Dummy123");
                    if (theView == null)
                    {
                        MessageBox.Show("View NULL");
                        break;
                    }
                    _regionManager.Regions[SpliteCommandParameter(param).regionName].Activate(theView);
                    break;
                case "Deactive":
                    theView = _regionManager.Regions[SpliteCommandParameter(param).regionName].GetView("Dummy123");
                    if (theView == null)
                    {
                        MessageBox.Show("View NULL");
                        break;
                    }
                    _regionManager.Regions[SpliteCommandParameter(param).regionName].Deactivate(theView);
                    break;
                case "Remove":
                    theView = _regionManager.Regions[SpliteCommandParameter(param).regionName].GetView("Dummy123");
                    if (theView == null)
                    {
                        MessageBox.Show("View NULL");
                        break;
                    }
                    _regionManager.Regions[SpliteCommandParameter(param).regionName].Remove(theView);
                    break;

                default:
                    break;
            }
        }

        private (string regionName, string what) SpliteCommandParameter(string param)
        {
            string[] paramStr = param.Split('^');
            return (paramStr[0], paramStr[1]);
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "-";
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
