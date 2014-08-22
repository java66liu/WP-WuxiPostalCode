using System;
using System.Text;
using System.Windows.Navigation;
using Microsoft.Phone.Tasks;
using MVVMSidekick.Views;
using WuxiPostal.ViewModels;

namespace WuxiPostal
{
    public partial class SearchResultByDistrictName : MVVMPage
    {
        public SearchResultByDistrictName()
            : base(null)
        {
            InitializeComponent();
        }
        public SearchResultByDistrictName(SearchResultByDistrictName_Model model)
            : base(model)
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string term;

            if (NavigationContext.QueryString.TryGetValue("term", out term))
            {
                var vm = (ViewModel as SearchResultByDistrictName_Model);
                if (null != vm)
                {
                    vm.InitData(term);
                }
            }
        }

        private void MenuEmail_Click(object sender, EventArgs e)
        {
            var vm = (ViewModel as SearchResultByDistrictName_Model);
            if (null != vm)
            {
                var sb = new StringBuilder();
                foreach (var @group in vm.GroupedSearchResult)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(@group.Key + Environment.NewLine);
                    sb.Append("---------------" + Environment.NewLine);
                    foreach (var item in @group)
                    {
                        sb.Append(item.Address + Environment.NewLine);
                    }
                }

                var emailComposeTask = new EmailComposeTask
                {
                    Subject = vm.DistrictTerm + " 的邮编搜索结果",
                    Body = sb + Environment.NewLine + "----《无锡市邮编查询》Windows Phone应用"
                };

                emailComposeTask.Show();
            }
        }
    }
}