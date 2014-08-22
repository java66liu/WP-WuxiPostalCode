using MVVMSidekick.Views;
using System;
using WuxiPostal;
using WuxiPostal.ViewModels;


namespace MVVMSidekick.Startups
{
    public static partial class StartupFunctions
    {
        static Action PostalCodeDetailConfig =
            CreateAndAddToAllConfig(ConfigPostalCodeDetail);

        public static void ConfigPostalCodeDetail()
        {
            ViewModelLocator<PostalCodeDetail_Model>
                .Instance
                .Register(context =>
                    new PostalCodeDetail_Model())
                .GetViewMapper()
                .MapToDefault<PostalCodeDetail>();

        }
    }
}
