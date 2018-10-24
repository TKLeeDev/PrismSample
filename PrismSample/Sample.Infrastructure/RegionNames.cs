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

        //ViewActiveDeactiveView
        public const string Region_ViewActiveDeactive_Top = "Region_ViewActiveDeactive_Top";
        public const string Region_ViewActiveDeactive_Bottom = "Region_ViewActiveDeactive_Bottom";

        //EventAggregatorShellView
        public const string Region_EventAggregatorShell_Left = "Region_EventAggregatorShell_Left";
        public const string Region_EventAggregatorShell_Right = "Region_EventAggregatorShell_Right";

        //EAFilterShellView
        public const string Region_EAFilterShell_Left = "Region_EAFilterShell_Left";
        public const string Region_EAFilterShell_Right = "Region_EAFilterShell_Right";

        //PassingParametersShellView
        public const string Region_PassingParameters = "Region_EAFilterShell";
    }
}
