using Sample.Modules.Models;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.ViewModels.Popup
{
    class CustomInteractionViewModel : BindableBase, IInteractionRequestAware
    {
        private ICustomNotification _notification;

        public string SelectedItem { get; set; }

        public DelegateCommand SelectItemCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }

        public CustomInteractionViewModel()
        {
            SelectItemCommand = new DelegateCommand(AcceptSelectedItem);
            CancelCommand = new DelegateCommand(CancelInteraction);
        }

        private void CancelInteraction()
        {
            _notification.SelectedItem = null; // From : ICustomNotification
            _notification.Confirmed = false;   // From : IConfirmation
            FinishInteraction?.Invoke();
        }

        private void AcceptSelectedItem()
        {
            _notification.SelectedItem = SelectedItem;
            _notification.Confirmed = true;
            FinishInteraction?.Invoke();
        }

        public Action FinishInteraction { get; set; }

       
        // INotification(Title, Content) -> IConfirmation(Confirmed) -> ICustomNotification(SelectedItem)
        //1
        public INotification Notification
        {
            get { return _notification; }
            set { SetProperty(ref _notification, (ICustomNotification)value); }
        }
    }
}
