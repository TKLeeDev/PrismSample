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
    class ExcuteCanexcuteViewModel : BindableBase
    {
        public ExcuteCanexcuteViewModel()
        {
            TimerFunc();
        }


        private DelegateCommand _bCreate;
        //! Renew 'Canexcute' via 'ObservasProperty' (when "bStatus" get some value)
        public DelegateCommand bCreate =>
            _bCreate ?? (_bCreate = new DelegateCommand(ExecutebCreate, CanExecutebCreate)).ObservesProperty(() => bStatus);

        void ExecutebCreate()
        {
            bStatus = "Created.";
        }


        bool CanExecutebCreate()
        {
            return (bStatus == "Created.") || (bStatus == "Collapsed.") ? false : true;
        }

        private DelegateCommand _bCollapse;
        public DelegateCommand bCollapse =>
            _bCollapse ?? (_bCollapse = new DelegateCommand(ExecutebCollapse, CanExecutebCollapse)).ObservesProperty(() => bStatus);

        void ExecutebCollapse()
        {
            bStatus = "Collapsed.";

            //! Instead of a 'ObservasProperty'
            //bCreate.RaiseCanExecuteChanged();
        }

        bool CanExecutebCollapse()
        {
            return (bStatus == "Collapsed.") || (bStatus == "Removed.") ||
                (string.IsNullOrEmpty(bStatus)) ? false : true;
        }

        private DelegateCommand _bRemove;
        public DelegateCommand bRemove =>
            _bRemove ?? (_bRemove = new DelegateCommand(ExecutebRemove, CanExecutebRemove)).ObservesProperty(() => bStatus);

        void ExecutebRemove()
        {
            bStatus = "Removed.";
        }

        bool CanExecutebRemove()
        {
            return (bStatus == "Removed.") || (string.IsNullOrEmpty(bStatus)) ? false : true;
        }


        private string _bStatus;
        public string bStatus
        {
            get { return _bStatus; }
            set { SetProperty(ref _bStatus, value); }
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Set state of element via Excute and Canexcute Method.";
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
