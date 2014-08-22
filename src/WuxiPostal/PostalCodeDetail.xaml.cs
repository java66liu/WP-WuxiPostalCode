using System;
using System.Text;
using System.Windows.Navigation;
using Microsoft.Phone.Tasks;
using MVVMSidekick.Views;
using WuxiPostal.ViewModels;

namespace WuxiPostal
{
    public partial class PostalCodeDetail : MVVMPage
    {
        public PostalCodeDetail():base(null)
        {
            InitializeComponent();
        }
        public PostalCodeDetail(PostalCodeDetail_Model model):base(model)
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string code;

            if (NavigationContext.QueryString.TryGetValue("code", out code))
            {
                var vm = (ViewModel as PostalCodeDetail_Model);
                if (null != vm)
                {
                    vm.InitData(code);
                }
            }
        }

        private void MenuEmail_Click(object sender, EventArgs e)
        {
            var vm = (ViewModel as PostalCodeDetail_Model);
            if (null != vm)
            {
                var sb = new StringBuilder();
                foreach (var add in vm.PostalCode.Addresses)
                {
                    sb.Append(add + Environment.NewLine);
                }

                var emailComposeTask = new EmailComposeTask
                {
                    Subject = vm.PostalCode.Code + " 邮编所有地址",
                    Body = sb + Environment.NewLine + "----《无锡邮编查询》Windows Phone应用"
                };

                emailComposeTask.Show();
            }
        }

        private void MenuReportError_Click(object sender, EventArgs e)
        {
            Utils.ReportError("PostalCodeDetail");
        }
    }
}