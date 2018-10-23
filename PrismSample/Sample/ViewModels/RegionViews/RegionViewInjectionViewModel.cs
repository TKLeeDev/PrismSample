using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Modules.Dummy.Views;
using Sample.Views;
using System;
using System.Windows.Threading;

namespace Sample.ViewModels
{
    class RegionViewInjectionViewModel : BindableBase
    {
        //Injection means using object via "Resolve" and add it to region.

        IUnityContainer _container;
        IRegionManager _regionManager;
        public RegionViewInjectionViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            TimerFunc();
            _container = container;
            _regionManager = regionManager;

            //! Stackoverflow 문의했음. bootstrapper →  regionManager.RegisterViewWithRegion("ViewInjectionMain_MainRegion", typeof(DummyView)); 추가함.
            // interaction으로 Loaded 이벤트 발생시, 호출 하던지 Bootstrapper에서 초기화면 설정해주던지(Bootstrapper에서 RegisterViewWithRegion) 해야함. 
            // 그렇지 않고 생성자에서 호출시 Region이 RegionManager에 등록되지 않아 Exception남. 
            ////! View  injection
            //System.Windows.Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() =>
            //{
            //    var view = _container.Resolve<DummyView>();
            //    IRegion region = _regionMansger.Regions["ViewInjectionMain_MainRegion"];
            //    region.Add(view);
            //}));
        }

        private DelegateCommand _bCommand;
        public DelegateCommand bCommand =>
            _bCommand ?? (_bCommand = new DelegateCommand(ExecutebCommand));

        void ExecutebCommand()
        {
            var view = _container.Resolve<DummyView>();
            IRegion region = _regionManager.Regions["ViewInjectionMain_MainRegion"];
            region.Add(view);
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Injection means using object via \"Resolve\" and add it to region.";
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
