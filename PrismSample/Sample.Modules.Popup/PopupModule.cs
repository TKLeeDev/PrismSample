using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;
using Sample.Modules.Popup.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Popup
{
    public class PopupModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public PopupModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            
            _container.RegisterTypeForNavigation<CustomInteractionView>();

            
        }
    }
}
