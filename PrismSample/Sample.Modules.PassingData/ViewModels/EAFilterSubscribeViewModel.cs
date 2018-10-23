using Prism.Events;
using Prism.Mvvm;
using Sample.Infrastructure.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.PassingData.ViewModels
{
    class EAFilterSubscribeViewModel :BindableBase
    {
        IEventAggregator _ea;
        public EAFilterSubscribeViewModel(IEventAggregator ea)
        {
            TimerFunc();
            _ea = ea;
            _ea.GetEvent<UsingEventFilterMsg>().Subscribe(MsgFunc, ThreadOption.PublisherThread,
                false, (filter) => filter.Contains("TaeKyung"));
        }

        private void MsgFunc(string msg)
        {
            obMsgList.Add(msg);
        }

        private ObservableCollection<string> _msg = new ObservableCollection<string>();
        public ObservableCollection<string> obMsgList
        {
            get { return _msg; }
            set { SetProperty(ref _msg, value); }
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Subscribe only contains \"TaeKyung\"";
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
