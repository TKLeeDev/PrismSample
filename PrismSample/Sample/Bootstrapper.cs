using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Sample.Infrastructure;
using Sample.Modules;
using Sample.Modules.Binding;
using Sample.Modules.Binding.Views;
using Sample.Modules.Command;
using Sample.Modules.Command.Views;

using Sample.Modules.Interaction;
using Sample.Modules.Interaction.Views;
using Sample.Modules.PassingData;
using Sample.Modules.PassingData.Views;
using Sample.Modules.Region;
using Sample.Views;
using System.ComponentModel;
using System.Windows;

namespace Sample
{
    /* Author : TaeKyungLee
     * Data : 2018-09-18
     * LastUpdate : -
     * Used Library :
     *  Prism 6.3v (Nuget) 
     *  System.ValueTuple (Nuget)
     *  CommentsPlus (Option, ExtensionsTool)
     *  Prism Template Pack Snippets (Option, ExtensionsTool) :
     *      propp - Property, with a backing field, that depends on BindableBase
     *      cmd - Creates a DelegateCommand property with Execute method
     *      cmdfull - Creates a DelegateCommand property with Execute and CanExecute methods
     *      cmdg - Creates a generic DelegateCommand<T> property
     *      cmdgfull - Creates a generic DelegateCommand<T> property with Execute and CanExecute methods
     */

    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return MainWindow object via 'Resolve'
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            // Register views
            var regionManager = this.Container.Resolve<IRegionManager>();

            //Allocate region's default view.
            if (regionManager != null)
            {
                regionManager.RegisterViewWithRegion("Region_MainWindow", typeof(FirstView));

                //BindingCompositeCommands
               // regionManager.RegisterViewWithRegion("BindingCompositeCommand_LeftRegion", typeof(BindingConmpositeCommand_Dummy));
               // regionManager.RegisterViewWithRegion("BindingCompositeCommand_RightRegion", typeof(BindingConmpositeCommand_Dummy));

                //UsingEventFilter


                //// 현재 호출하는 View의 ViewModel의 생성자에서 비동기로 호출 (Test용도, Invoke처리함)
                //regionManager.RegisterViewWithRegion("ViewInjectionMain_MainRegion", typeof(DummyView));
            }

            ////View등록 및 Tag등록 RegisterTypeForNavigation와 동일
            //Container.RegisterType<object, RegionViewsBasic>("RegionBasic");
            //Container.RegisterType<object, RegionControlMain>("RegionControlMain");
            //Container.RegisterType<object, DummyView>("DummyView");
            //Container.RegisterType<object, RegionViewInjection>("ViewInjectionMain");
            //Container.RegisterType<object, RegionViewActiveDeactive>("RegionViewActiveDeactive");
            //Container.RegisterType<object, RegionViewDiscovery>("RegionViewDiscovery");

            //Binding
            Container.RegisterTypeForNavigation<BindingBasicView>();
            Container.RegisterTypeForNavigation<ObservableCollectionView>();

            //Command
            //Container.RegisterTypeForNavigation<BindingCommand>();
            Container.RegisterTypeForNavigation<CommandingView>();
            Container.RegisterTypeForNavigation<ExcuteCanexcuteView>();

            //Container.RegisterType<IDummyCompositeCommands, DummyCompositeCommands>(new ContainerControlledLifetimeManager());
            Container.RegisterTypeForNavigation<CompositeCommandingView>();

            //Interaction
            Container.RegisterTypeForNavigation<interactivityView>();

            //passing data. ok
            Container.RegisterTypeForNavigation<EventAggregatorShellView>();
            Container.RegisterTypeForNavigation<EAFilterShellView>();
            Container.RegisterTypeForNavigation<PassingParametersShellView>();

            //MainWindow Show
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            //Add other project module
            var catalog = (ModuleCatalog)ModuleCatalog;

            //binding
            catalog.AddModule(typeof(BindingModule));

            //passing data
            catalog.AddModule(typeof(PassingDataModule));

            //command
            catalog.AddModule(typeof(CommandModule));

            //interaction
            catalog.AddModule(typeof(InteractionModule));

            //View(region)
            catalog.AddModule(typeof(RegionModule));
        }
    }
}
