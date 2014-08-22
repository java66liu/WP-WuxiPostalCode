using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using System;
using System.Net;
using System.Windows;
using WuxiPostal;
using WuxiPostal.ViewModels;


namespace MVVMSidekick.Startups
{
    public static partial class StartupFunctions
    {
        static Action DistrictDetailConfig =
            CreateAndAddToAllConfig(ConfigDistrictDetail);

        public static void ConfigDistrictDetail()
        {
            ViewModelLocator<DistrictDetail_Model>
                .Instance
                .Register(context =>
                    new DistrictDetail_Model())
                .GetViewMapper()
                .MapToDefault<DistrictDetail>();

        }
    }
}
