using Prism.Commands;
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
    class CompositeCommandingDummyViewModel : BindableBase
    {
        IDummyCompositeCommands _DummyCompositeCommands;
        public DelegateCommand UpdateCommand { get; private set; }
        public CompositeCommandingDummyViewModel(IDummyCompositeCommands DummyCompositeCommands)
        {
            TimerFunc();
            _DummyCompositeCommands = DummyCompositeCommands;
            UpdateCommand = new DelegateCommand(Update);
            //when command1 (CompositeCommand) active, UpdateCommand Active Too.
            DummyCompositeCommands.command1.RegisterCommand(UpdateCommand);
        }
        private void Update()
        {
            bDescription = $"Updated: {DateTime.Now}";
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Dummy View";
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
