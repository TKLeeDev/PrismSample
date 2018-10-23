using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Command.ViewModels
{
    class CommandingViewModel : BindableBase
    {
        public CommandingViewModel()
        {
            TimerFunc();
        }

        private DelegateCommand _cCommand1;
        public DelegateCommand cCommand1 =>
            _cCommand1 ?? (_cCommand1 = new DelegateCommand(ExecutecCommand1));

        void ExecutecCommand1()
        {
            bText1 = "Button Clicked";
        }
        private string _bText1;
        public string bText1
        {
            get { return _bText1; }
            set { SetProperty(ref _bText1, value); }
        }


        private DelegateCommand<string> _cCommand2;
        public DelegateCommand<string> cCommand2 =>
            _cCommand2 ?? (_cCommand2 = new DelegateCommand<string>(ExecutecCommand2));

        void ExecutecCommand2(string param)
        {
            bText2 = param;
        }

        private string _bText2;
        public string bText2
        {
            get { return _bText2; }
            set { SetProperty(ref _bText2, value); }
        }



        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Command binding and binding with parameter.";
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
