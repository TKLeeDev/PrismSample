

using Microsoft.Practices.Unity;
using ModuleA.Views;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public ModuleAModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion("LeftRegion", typeof(MessageSender));
            _container.RegisterTypeForNavigation<MessageSender>();
            
        }
    }
}
