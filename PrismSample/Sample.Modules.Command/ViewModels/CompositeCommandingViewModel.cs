using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Sample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Command.ViewModels
{
    class CompositeCommandingViewModel : BindableBase
    {

        public InteractionRequest<INotification> PopupRequest { get; set; } = new InteractionRequest<INotification>();
        public DelegateCommand cPopupCommand { get; set; }

        //Composite Command Properties 
        //  - Active Button Binding "{Binding DummyCompositeCommands.command1 }"
        private IDummyCompositeCommands _dummyCompositeCommands;
        public IDummyCompositeCommands DummyCompositeCommands
        {
            get { return _dummyCompositeCommands; }
            set { SetProperty(ref _dummyCompositeCommands, value); }
        }

        public CompositeCommandingViewModel(IDummyCompositeCommands dummyCompositeCommands)
        {
            TimerFunc();
            DummyCompositeCommands = dummyCompositeCommands;

            cPopupCommand = new DelegateCommand(RaiseSome);

        }

        void RaiseSome()
        {  //Description Image
            PopupRequest.Raise(new Notification { Title = "Description Images", Content = "/Sample.Infrastructure;component/Images/Ch6AdvMVVMFig1.png" }, null);
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Composite Command is mapping to other view's command.";
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
