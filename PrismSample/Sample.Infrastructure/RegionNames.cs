using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure
{
    public static class RegionNames
    {
        //MainWindow
        public const string Region_MainWindow = "Region_MainWindow";

        //CompositeCommandingView
        public const string Region_CompositeCommanding_Left = "Region_CompositeCommanding_Left";
        public const string Region_CompositeCommanding_Right = "Region_CompositeCommanding_Right";

        //ViewDiscoveryView
        public const string Region_ViewDiscovery = "Region_ViewDiscovery";

        //ViewInjectionView
        public const string Region_ViewInjection = "Region_ViewInjection";

        //ViewControlView
        public const string Region_ViewControl_LeftTop = "Region_ViewControl_LeftTop";
        public const string Region_ViewControl_LeftBottom = "Region_ViewControl_LeftBottom";
        public const string Region_ViewControl_RightItems = "Region_ViewControl_RightItems";

        public const string RegionParam_ViewControl_LeftTop = "Region_ViewControl_LeftTop^DummyView";
        public const string RegionParam_ViewControl_LeftBottom = "Region_ViewControl_LeftBottom^DummyView";
        public const string RegionParam_ViewControl_RightItems = "Region_ViewControl_RightItems^DummyView";

        //ViewActiveDeactiveView
        public const string Region_ViewActiveDeactive_Top = "Region_ViewActiveDeactive_Top";
        public const string Region_ViewActiveDeactive_Bottom = "Region_ViewActiveDeactive_Bottom";

        public const string RegionParam_ViewActiveDAeactive_TopAdd = "Region_ViewActiveDeactive_Top^Add";
        public const string RegionParam_ViewActiveDeactive_BottomAdd = "Region_ViewActiveDeactive_Bottom^Add";

        public const string RegionParam_ViewActiveDeactive_TopActive = "Region_ViewActiveDeactive_Top^Active";
        public const string RegionParam_ViewActiveDeactive_BottomActive = "Region_ViewActiveDeactive_Bottom^Active";

        public const string RegionParam_ViewActiveDeactive_TopDeactive = "Region_ViewActiveDeactive_Top^Deactive";
        public const string RegionParam_ViewActiveDeactive_BottomDeactive = "Region_ViewActiveDeactive_Bottom^Deactive";

        public const string RegionParam_ViewActiveDeactive_TopRemove = "Region_ViewActiveDeactive_Top^Remove";
        public const string RegionParam_ViewActiveDeactive_BottomRemove = "Region_ViewActiveDeactive_Bottom^Remove";

        //EventAggregatorShellView
        public const string Region_EventAggregatorShell_Left = "Region_EventAggregatorShell_Left";
        public const string Region_EventAggregatorShell_Right = "Region_EventAggregatorShell_Right";

        //EAFilterShellView
        public const string Region_EAFilterShell_Left = "Region_EAFilterShell_Left";
        public const string Region_EAFilterShell_Right = "Region_EAFilterShell_Right";

        //PassingParametersShellView
        public const string Region_PassingParametersShell = "Region_PassingParametersShell";
        public const string Region_PassingParametersList = "Region_Region_PassingParametersList_Tab";
    }
}
