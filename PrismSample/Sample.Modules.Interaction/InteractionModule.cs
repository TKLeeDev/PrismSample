using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Modules.Interaction.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Interaction
{
    public class InteractionModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public InteractionModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            //BindingCompositeCommands
            _container.RegisterTypeForNavigation<interactivityView>();            
        }
    }
}
