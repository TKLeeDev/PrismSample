using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Infrastructure;
using Sample.Modules.Command.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Modules.Command
{
    public class CommandModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public CommandModule(RegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {

            _regionManager.RegisterViewWithRegion(RegionNames.Region_CompositeCommanding_Left, typeof(CompositeCommandingDummyView));
            _regionManager.RegisterViewWithRegion(RegionNames.Region_CompositeCommanding_Right, typeof(CompositeCommandingDummyView));


            //BindingCompositeCommands
            _container.RegisterTypeForNavigation<CommandingView>();
            _container.RegisterTypeForNavigation<ExcuteCanexcuteView>();

           

            _container.RegisterType<IDummyCompositeCommands, DummyCompositeCommands>(new ContainerControlledLifetimeManager());
            _container.RegisterTypeForNavigation<CompositeCommandingView>();
        }
    }
}
