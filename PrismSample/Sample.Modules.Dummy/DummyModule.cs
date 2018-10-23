using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Sample.Modules.Dummy
{
    public class DummyModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public DummyModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
         
            _container.RegisterTypeForNavigation<Views.DummyView>();
        }
    }
}
