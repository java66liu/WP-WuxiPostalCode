using System;
using System.Text;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using MVVMSidekick.Views;
using WuxiPostal.Models;
using WuxiPostal.ViewModels;

namespace WuxiPostal
{
    public partial class DistrictDetail : MVVMPage
    {
        public DistrictDetail():base(null)
        {
            InitializeComponent();
        }
        public DistrictDetail(DistrictDetail_Model model):base(model)
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string dId;

            if (NavigationContext.QueryString.TryGetValue("dId", out dId))
            {
                var vm = (this.ViewModel as DistrictDetail_Model);
                if (null != vm)
                {
                    vm.InitData(dId);
                }
            }
        }

        private void MenuEmail_Click(object sender, EventArgs e)
        {
            var vm = (this.ViewModel as DistrictDetail_Model);
            if (null != vm)
            {
                var sb = new StringBuilder();
                foreach (var pCode in vm.District.PostalCodes)
                {
                    sb.Append(pCode.Code + Environment.NewLine);
                }

                var emailComposeTask = new EmailComposeTask
                {
                    Subject = vm.District.Name + " 所有邮编号码",
                    Body = sb + Environment.NewLine + "----《无锡邮编查询》Windows Phone应用"
                };

                emailComposeTask.Show();
            }
        }

        private void SelectCode(object sender, SelectionChangedEventArgs e)
        {
            object selected = ((LongListSelector)(sender)).SelectedItem;
            if (null != selected)
            {
                string code = ((PostalCode)(selected)).Code;
                NavigationService.Navigate(new Uri(string.Format("/PostalCodeDetail.xaml?code={0}", code),
                    UriKind.Relative));
            }

            PostalCodeSelector.SelectedItem = null;
        }

        private void MenuReportError_Click(object sender, EventArgs e)
        {
            Utils.ReportError("DistrictDetail");
        }
    }
}