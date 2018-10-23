

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Modules.Binding.Views;


namespace Sample.Modules.Binding
{
    public class BindingModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public BindingModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<BindingBasicView>();
            _container.RegisterTypeForNavigation<ObservableCollectionView>();
        }
    }
}
