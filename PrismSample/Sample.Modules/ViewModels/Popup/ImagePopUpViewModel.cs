using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.ViewModels
{
    public class ImagePopUpViewModel : BindableBase, IInteractionRequestAware
    {
        public ImagePopUpViewModel()
        {
            bImgSource = "init";
        }
        private string _imgSource;
        public string bImgSource
        {
            get { return _imgSource; }
            set { SetProperty(ref _imgSource, value); }
        }

        INotification IInteractionRequestAware.Notification { get; set; }
        Action IInteractionRequestAware.FinishInteraction { get; set; }

        public string Content
        {
            set
            {
                bImgSource = value;
            }
        }
    }
}
