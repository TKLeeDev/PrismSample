using Microsoft.Practices.Unity;
using ModuleB.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleBModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion("RightRegion", typeof(MessageSender));
            _container.RegisterTypeForNavigation<MessageView>();
        }
    }
}
