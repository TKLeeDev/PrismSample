
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Infrastructure;
using Sample.Infrastructure.Messages;
using Sample.Modules.Popup.Models;
using System;
using System.Windows.Threading;

namespace Sample.ViewModels
{
    class FirstViewModel : BindableBase
    {
        IEventAggregator _ea;
        IRegionManager _regionManager;

        public DelegateCommand<string> cPopupCommand { get; set; }
        public DelegateCommand<string> cNavigationCommand { get; private set; }

        // Refer : "MainWindowViewModel" Popup commants.
        public InteractionRequest<INotification> DefaultNotificationRequest { get; set; } = new InteractionRequest<INotification>();
        public InteractionRequest<IConfirmation> DefaultConfirmationRqeust { get; set; } = new InteractionRequest<IConfirmation>();
        public InteractionRequest<INotification> CustomPopupRequest { get; set; } = new InteractionRequest<INotification>();
        public InteractionRequest<ICustomNotification> CustomInteractionRequest { get; set; } = new InteractionRequest<ICustomNotification>();

        public FirstViewModel(RegionManager regionManager, IEventAggregator ea)
        {
            TimerFunc();
            _regionManager = regionManager;
            _ea = ea;

            cPopupCommand = new DelegateCommand<string>(PopupCommandFunc);
            cNavigationCommand = new DelegateCommand<string>(NavigationCommandFunc);
        }

        void NavigationCommandFunc(string param)
        {
            // - Any "Region" is accessible via "IRegionManager"
            _regionManager.RequestNavigate(RegionNames.Region_MainWindow, param);
        }

        #region Popup


        private void PopupCommandFunc(string name)
        {
            // Refer : MainWindowsViewModel
            switch (name)
            {
                case "DefaultNotification":
                    DefaultNotificationRequest.Raise(new Notification { Title = name, Content = name + "Content (FirstView)" }, r =>
                    {
                        //Can't access the MainWindow's "bTitle" property(titlebar), send it using EventAggregator.
                        _ea.GetEvent<DefaultNotificationMsg>().Publish(name + "(FirstView)");
                    });
                    break;
                case "DefaultConfirmation":
                    DefaultConfirmationRqeust.Raise(new Confirmation { Title = name, Content = name + "Content(FirstView)" }, r =>
                    {
                        var v = r.Confirmed ? "Confirmed(FirstView)" : "Not confired(FirstView)";
                        _ea.GetEvent<DefaultConfirmationMsg>().Publish(v + "(FirstView)");
                    });
                    break;
                case "CustomPopup":
                    CustomPopupRequest.Raise(new Notification { Title = name, Content = name + "Content(FirstView)" }, r =>
                    {
                        _ea.GetEvent<CustomPopupMsg>().Publish("good (FirstView)");
                    });
                    break;
                case "CustomInteraction":
                    CustomInteractionRequest.Raise(new CustomNotification { Title = "Custom Notification(FirstView)" }, r =>
                    {
                        string tmp;
                        if (r.Confirmed && r.SelectedItem != null)
                            tmp = $"User selected(FirstView): { r.SelectedItem}";
                        else
                            tmp = "User 5cancelled or didn't select an item(FirstView)";
                        _ea.GetEvent<CustomInteractionMsg>().Publish(tmp);
                    });
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Default UI
        DispatcherTimer dispatcherTimer;
        private string _bDescription = "This sample allows introductory users to use Prism intuitively.";
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
