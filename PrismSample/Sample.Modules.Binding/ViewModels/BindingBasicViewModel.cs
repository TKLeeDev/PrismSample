using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Binding.ViewModels
{
    class BindingBasicViewModel : BindableBase
    {
        public BindingBasicViewModel()
        {
            bProp1 = 50;
            bProp2 = 50;
            bProp3 = 50;
            bProp4 = 50;
            TimerFunc();
        }

        #region Setproperies

        //OneTime
        private int _bProp1;
        public int bProp1
        {
            get { return _bProp1; }
            set { SetProperty(ref _bProp1, value); }
        }

        //OneWay
        private int _bProp2;
        public int bProp2
        {
            get { return _bProp2; }
            set { SetProperty(ref _bProp2, value); }
        }

        //OneWayToSource
        private int _bProp3;
        public int bProp3
        {
            get { return _bProp3; }
            set { SetProperty(ref _bProp3, value); }
        }

        //TwoWay
        private int _bProp4;
        public int bProp4
        {
            get { return _bProp4; }
            set { SetProperty(ref _bProp4, value); }
        }
        #endregion


        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Binding Basic : View Model Sent '50' to every bound properties. ";
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
