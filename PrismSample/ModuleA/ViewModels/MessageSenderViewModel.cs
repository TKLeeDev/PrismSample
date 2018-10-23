
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

namespace ModuleA.ViewModels
{
    class MessageSenderViewModel : BindableBase
    {
        IEventAggregator _ea;
        DispatcherTimer dispatcherTimer;
        private string _message;

        public MessageSenderViewModel(IEventAggregator ea)
        {
            _ea = ea;
            TimerFunc();
            
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private DelegateCommand _sendMsg;
        public DelegateCommand SendMessageCommand =>
            _sendMsg ?? (_sendMsg = new DelegateCommand(ExecutedelegateCommand));

        void ExecutedelegateCommand()
        {
            //Publish message 
            _ea.GetEvent<DummyMessage>().Publish(Message);
        }



        public void TimerFunc()
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


    }
}
