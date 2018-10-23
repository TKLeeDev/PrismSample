using Sample.Modules.Views;
using Sample.Modules.Views._Dummy;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Sample.Modules
{
    public class SampleModules : IModule
    {
        IRegionManager _regionManger;
        IUnityContainer _container;
        public SampleModules(RegionManager regionManger, IUnityContainer container)
        {
            _regionManger = regionManger;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<DummyModuleView>();
           //? _container.RegisterTypeForNavigation<BindingConmpositeCommand_Dummy>();
            // _container.RegisterTypeForNavigation<DataPassingParameters_Dummy>();
            //_regionManger.RegisterViewWithRegion("DataPassingParameters_MainRegion", typeof(DataPassingParameters_PersonList));
            //_container.RegisterTypeForNavigation<DataPassingParameters_PersonDetail>();
        //    _container.RegisterTypeForNavigation<ImagePopUp>();
        
        }
    }
}
