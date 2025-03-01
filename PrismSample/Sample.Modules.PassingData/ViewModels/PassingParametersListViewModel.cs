﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Infrastructure;
using Sample.Modules.PassingData.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Sample.Modules.PassingData.ViewModels
{
    class PassingParametersListViewModel : BindableBase
    {
        IRegionManager _regionManager;

        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        public DelegateCommand<Person> PersonSelectedCommand { get; private set; }

        public PassingParametersListViewModel(RegionManager regionManager)
        {
            TimerFunc();
            _regionManager = regionManager;

            PersonSelectedCommand = new DelegateCommand<Person>(PersonSelected);
            CreatePeople();
        }

        private void PersonSelected(Person person)
        {
            //Add value like key-value formet, via "NavigationParameters"
            var parameters = new NavigationParameters();
            parameters.Add("person", person);

            if (person != null)
                //RequestNavigation with NavigationParameters object.
                _regionManager.RequestNavigate(RegionNames.Region_PassingParametersList, "PassingParametersDetailView", parameters);
        }

        private void CreatePeople()
        {
            var people = new ObservableCollection<Person>();


            people.Add(new Person()
            {
                FirstName = String.Format("TaeKyung"),
                LastName = String.Format("Lee"),
                Age = 29
            });
            people.Add(new Person()
            {
                FirstName = String.Format("tatatatata"),
                LastName = String.Format("Kim"),
                Age = 30
            });
            people.Add(new Person()
            {
                FirstName = String.Format("dadadadadada"),
                LastName = String.Format("Ryu"),
                Age = 32
            });

            People = people;
        }

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "PersonList. (XAML Resource define tab control headers)";
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
