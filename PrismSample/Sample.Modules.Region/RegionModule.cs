using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Modules.Region.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Region
{
    public class RegionModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public RegionModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {     
            _container.RegisterTypeForNavigation<DummyView>();

            _container.RegisterTypeForNavigation<ViewActiveDeactiveView>();
            _container.RegisterTypeForNavigation<ViewBasicView>();
            _container.RegisterTypeForNavigation<ViewControlView>();
            _container.RegisterTypeForNavigation<ViewDiscoveryView>();
            _container.RegisterTypeForNavigation<ViewInjectionView>();
        }
    }
}
