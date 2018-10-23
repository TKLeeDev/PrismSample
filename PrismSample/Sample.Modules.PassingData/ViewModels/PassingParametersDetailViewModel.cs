using Prism.Mvvm;
using Prism.Regions;
using Sample.Modules.PassingData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.PassingData.ViewModels
{
    class PassingParametersDetailViewModel : BindableBase, INavigationAware
    {
        public PassingParametersDetailViewModel()
        {
            TimerFunc();
        }

        private Person _SelectedPerson;
        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
            set { SetProperty(ref _SelectedPerson, value); }
        }

        //Active this implement function when any "NavigationParameters" object with RequestNavigation.
        void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
        {
            //Find value via key
            var person = navigationContext.Parameters["person"] as Person;
            if (person != null)
                SelectedPerson = person;
        }

        //Call it from second Check dupulicate view.
        bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters["person"] as Person;
            if (person != null)
                return SelectedPerson != null && SelectedPerson.LastName == person.LastName;
            else
                return true;
        }

        void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
        {
            //check sent user.
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "Person Detail";
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
