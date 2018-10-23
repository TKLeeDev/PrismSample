﻿using Prism.Mvvm;
using System;
using System.Windows.Threading;

namespace Sample.ViewModels
{
    class RegionViewsBasicViewModel : BindableBase
    {
        /* 
         * This ViewModel's view called in MainWindowViewModel as "RequestNavigate"
         * when use RequestNavigation is hould added in bootstrapper.cs like :
         * "Container.RegisterTypeForNavigation<BindingCommand>();"
         */

        public RegionViewsBasicViewModel()
        {
            TimerFunc();
        }
        

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "This ViewModel's view called in MainWindowViewModel as \"RequestNavigate\"" +
                "when use RequestNavigation is hould added in bootstrapper.cs like :" +
                "\"Container.RegisterTypeForNavigation<BindingCommand>();\"";
               
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