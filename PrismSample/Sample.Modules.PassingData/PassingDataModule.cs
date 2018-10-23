using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Modules.PassingData.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.PassingData
{
    public class PassingDataModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public PassingDataModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("DataEventAggregator_LeftRegion", typeof(EventAggregatorPublishView));
            _regionManager.RegisterViewWithRegion("DataEventAggregator_RightRegion", typeof(EventAggregatorSubscribeView));
            _container.RegisterTypeForNavigation<EventAggregatorShellView>();


            _regionManager.RegisterViewWithRegion("UsingEventFilter_Left", typeof(EAFilterPublishView));
            _regionManager.RegisterViewWithRegion("UsingEventFilter_Right", typeof(EAFilterSubscribeView));
            _container.RegisterTypeForNavigation<EAFilterShellView>();


            _regionManager.RegisterViewWithRegion("DataPassingParameters_MainRegion", typeof(PassingParametersListView));
            _container.RegisterTypeForNavigation<PassingParametersDetailView>();
            _container.RegisterTypeForNavigation<PassingParametersShellView>();

        }
    }
}
