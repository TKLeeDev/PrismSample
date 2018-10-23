using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.Interaction.ViewModels
{
    class interactivityViewModel : BindableBase
    {
        // Loaded, MouseDown, MouseUp, MouseMove, MouseLeave Event is 
        // binding to "View(XAML)" as "prism:InteractionRequestTrigger".

        public ObservableCollection<string> obLog { get; set; } = new ObservableCollection<string>();
        public interactivityViewModel()
        {
            TimerFunc();
        }

        private DelegateCommand<string> _cInteraction;
        public DelegateCommand<string> cInteraction =>
            _cInteraction ?? (_cInteraction = new DelegateCommand<string>(ExecuteccInteraction));

        void ExecuteccInteraction(string msg)
        {
            obLog.Add(msg);
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Occur event via interaction library.\n 'ScrollView' Used 'AutoScrollBehavior Behavior Class.'";
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
