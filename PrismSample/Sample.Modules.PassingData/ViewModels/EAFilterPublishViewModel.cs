using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Sample.Infrastructure.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.PassingData.ViewModels
{
    class EAFilterPublishViewModel :BindableBase
    {
        IEventAggregator _ea;


        public EAFilterPublishViewModel(IEventAggregator ea)
        {
            _ea = ea;
            TimerFunc();
        }

        private string _filterString = "TaekyungLee";
        public string bFilterString
        {
            get { return _filterString; }
            set { SetProperty(ref _filterString, value); }
        }

        private string _message;
        public string bMessage
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private DelegateCommand _cSend;
        public DelegateCommand cSend =>
            _cSend ?? (_cSend = new DelegateCommand(ExecutecSend));

        void ExecutecSend()
        {
            _ea.GetEvent<UsingEventFilterMsg>().Publish(bMessage);
        }


        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Just Publish via EventAggregator";
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
