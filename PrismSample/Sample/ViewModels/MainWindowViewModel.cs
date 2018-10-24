
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using Sample.Infrastructure;
using Sample.Infrastructure.Messages;
using Sample.Modules.Popup.Models;

namespace Sample.ViewModels
{
    class MainWindowViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> cNavigationCommand { get; private set; }
        public DelegateCommand<string> cPopupCommand { get; set; }

        // Popup Request objects 
        // - Used to raise popup in "PopupCommandFunc" and 
        // - Each "InteractionRequest" is Binding to "View(XAML)" as "prism:InteractionRequestTrigger"
        public InteractionRequest<INotification> DefaultNotificationRequest { get; set; } = new InteractionRequest<INotification>();
        public InteractionRequest<IConfirmation> DefaultConfirmationRqeust { get; set; } = new InteractionRequest<IConfirmation>();
        public InteractionRequest<INotification> CustomPopupRequest { get; set; } = new InteractionRequest<INotification>();
        public InteractionRequest<ICustomNotification> CustomInteractionRequest { get; set; } = new InteractionRequest<ICustomNotification>();

        //Binding Windowbar Text.
        private string _title = "WPF - PRISM Sample";
        public string bTitle
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;

            cNavigationCommand = new DelegateCommand<string>(NavigationCommandFunc);
            cPopupCommand = new DelegateCommand<string>(PopupCommandFunc);

            // EventAggregator - To receive messages from "FirstView" (FirstView's popup send Msg to here)
            eventAggregator.GetEvent<DefaultNotificationMsg>().Subscribe(Msg_DefaultNotification);
            eventAggregator.GetEvent<DefaultConfirmationMsg>().Subscribe(Msg_DefaultConfirmation);
            eventAggregator.GetEvent<CustomInteractionMsg>().Subscribe(Msg_CustomInteraction);
            eventAggregator.GetEvent<CustomPopupMsg>().Subscribe(Msg_CustomPopupMsg);
        }

        private void NavigationCommandFunc(string viewName)
        {
            if (viewName != null)
                _regionManager.RequestNavigate(RegionNames.Region_MainWindow, viewName);
        }
        private void PopupCommandFunc(string name)
        {
            switch (name)
            {
                case "DefaultNotification":
                    DefaultNotificationRequest.Raise(new Notification { Title = name, Content = name + "Content" }, r => bTitle = name);
                    break;
                case "DefaultConfirmation":
                    DefaultConfirmationRqeust.Raise(new Confirmation { Title = name, Content = name + "Content" }, r => bTitle = r.Confirmed ? "Confiremd " : "Not Confired");
                    break;
                //? Default Notification (Title, Content) "can't use"MVVM Pattern" so it need custominteraction.
                case "CustomPopup":
                    CustomPopupRequest.Raise(new Notification { Title = name, Content = name + "Content" }, r => bTitle = "good");
                    break;
                case "CustomInteraction":
                    CustomInteractionRequest.Raise(new CustomNotification { Title = "Custom Notification" }, r =>
                    {
                        if (r.Confirmed && r.SelectedItem != null)
                            bTitle = $"User selected: { r.SelectedItem}";
                        else
                            bTitle = "User cancelled or didn't select an item";
                    });
                    break;
                default:
                    break;
            }
        }

        //EventAggregator Functions - To receive messages from "FirstView".
        private void Msg_DefaultNotification(string message)
        {
            bTitle = message;
        }
        private void Msg_DefaultConfirmation(string message)
        {
            bTitle = message;
        }
        private void Msg_CustomInteraction(string message)
        {
            bTitle = message;
        }
        private void Msg_CustomPopupMsg(string message)
        {
            bTitle = message;
        }



    }
}
