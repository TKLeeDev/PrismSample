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
    class RegionControlsViewModel : BindableBase
    {

        private IRegionManager _regionManager;
        private IUnityContainer _container;
        private IRegion _region;
        private int viewNameCountNum = 0;

        public RegionControlsViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            TimerFunc();
            bCommand1 = new DelegateCommand<string>(CommandFunc1);
            _regionManager = regionManager;
            _container = container;
        }

        //Left top
        public DelegateCommand<string> bCommand1 { get; set; }
        private void CommandFunc1(string param)
        {
            // 다중 CommandParameter를 받고 파싱.
            //string[] param = viewName.Split('^');

            //// Bootstrapper에 RegisterTypeForNavigation 등록했을 경우
            //_regionManager.RequestNavigate(SpliteCommandParameter(viewName).regionName,
            //  SpliteCommandParameter(viewName).viewName);

            //
            bDescription = "Region1 Discovery Call DummyView";
            _regionManager.RegisterViewWithRegion(SpliteCommandParameter(param).regionName, typeof(DummyView));

        }


        //left top
        private DelegateCommand<string> _bCommand2;
        public DelegateCommand<string> bCommand2 =>
            _bCommand2 ?? (_bCommand2 = new DelegateCommand<string>(CommandFunc2));
        void CommandFunc2(string param)
        {
            //// Bootstrapper에 RegisterTypeForNavigation 등록했을 경우
            //_regionManager.RequestNavigate(SpliteCommandParameter(viewName).regionName,
            //    SpliteCommandParameter(viewName).viewName);

            bDescription = "Region2 Discovery Call DummyView";
            _regionManager.RegisterViewWithRegion(SpliteCommandParameter(param).regionName, typeof(DummyView));

        }


        private DelegateCommand<string> _bCommand3;
        public DelegateCommand<string> bCommand3 =>
            _bCommand3 ?? (_bCommand3 = new DelegateCommand<string>(CommandFunc3));
        void CommandFunc3(string param)
        {
            string viewName = "Dummy" + viewNameCountNum;

            //Make view's object via Resolve  access to ViewModel
            //Change the access value to "serproperty" in "ViewModel" by name.
            var view = _container.Resolve<DummyView>();
            var vm = view.DataContext as DummyViewModel;
            vm.bDescription = "Dummy Name : " + viewName;

            //add view to region to "viewName" then each view got name like : "Dummy1", "Dummy2", "Dummy3"
            _regionManager.Regions[SpliteCommandParameter(param).regionName].Add(view, viewName);

            // case : directly object without using "Resolve" 
            //may it has performence issue.
            ////_regionManager.Regions[SpliteCommandParameter(viewName).regionName].Add(new DummyView(), "viewName";

            viewNameCountNum++;

            // case : without naming.
            ////bDescription = "Region3 (ItemsControl) Discovery Call DummyView";
            ////regionManager.RegisterViewWithRegion(SpliteCommandParameter(viewName).regionName, typeof(DummyView));

        }

        //Delete View
        private DelegateCommand<string> _bFindDelete;
        public DelegateCommand<string> bFindDeleteCommand =>
            _bFindDelete ?? (_bFindDelete = new DelegateCommand<string>(ExecutebFindDeleteCommand));
        void ExecutebFindDeleteCommand(string param)
        {
            var theView = _regionManager.Regions[SpliteCommandParameter(param).regionName].GetView(bTextBox);

            if (theView == null)
            {
                MessageBox.Show("View NULL");
            }
            else  //Delete Find View and Remove it in Region's object.
                _regionManager.Regions[SpliteCommandParameter(param).regionName].Remove(theView);
        }

        //remove textbox string.
        private string _bTextBox;
        public string bTextBox
        {
            get { return _bTextBox; }
            set { SetProperty(ref _bTextBox, value); }
        }

        // 튜플 사용위해서는 System.ValueTuple, 내장되어 있지 않아 Nuget에서 추가함..
        private (string regionName, string viewName) SpliteCommandParameter(string param)
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
