
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

namespace ModuleB.ViewModels
{
    class MessageViewModel : BindableBase
    {
        IEventAggregator _ea;
        DispatcherTimer dispatcherTimer;

        private ObservableCollection<string> _msg;
        public ObservableCollection<string> Messages
        {
            get { return _msg; }
            set { SetProperty(ref _msg, value); }
        }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();

            //Subscribe Message
            _ea.GetEvent<DummyMessage>().Subscribe(MessageReceived);
            TimerFunc();
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
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
