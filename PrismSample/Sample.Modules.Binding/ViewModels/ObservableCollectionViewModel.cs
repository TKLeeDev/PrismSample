using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Binding.ViewModels
{
    class ObservableCollectionViewModel : BindableBase
    {

        private TestClass _bTestClass = new TestClass();
        public TestClass bTestClass
        {
            get { return _bTestClass; }
            set { SetProperty(ref _bTestClass, value); }
        }

        public ObservableCollectionViewModel()
        {
            TimerFunc();
        }

        public ObservableCollection<TestClass> obStringList { get; set; } = new ObservableCollection<TestClass>();

        private DelegateCommand<string> _cAddCommand;
        public DelegateCommand<string> cAddCommand =>
            _cAddCommand ?? (_cAddCommand = new DelegateCommand<string>(ExecutecAddCommand));

        void ExecutecAddCommand(string str)
        {
            obStringList.Add(new TestClass() { param1 = bTestClass.param1, param2 = bTestClass.param2 });
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Binding \"ObservableCollection\" to \"ListView\".";

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

    public class TestClass : BindableBase
    {
        public string param1 { get; set; }
        public string param2 { get; set; }
    }
}
