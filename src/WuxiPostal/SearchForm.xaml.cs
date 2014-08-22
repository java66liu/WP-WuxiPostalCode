using System;
using System.Windows;
using MVVMSidekick.Views;
using WuxiPostal.ViewModels;

namespace WuxiPostal
{
    public partial class SearchForm : MVVMPage
    {
        public SearchForm()
            : base(null)
        {
            InitializeComponent();
        }
        public SearchForm(SearchForm_Model model)
            : base(model)
        {
            InitializeComponent();
        }

        private void MenuDoSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PostalCodeBox.Text) && string.IsNullOrEmpty(DistrictTermBox.Text))
            {
                NavigationService.Navigate(new Uri(string.Format("/PostalCodeDetail.xaml?code={0}", PostalCodeBox.Text),
                    UriKind.Relative));
            }
            else if (!string.IsNullOrEmpty(DistrictTermBox.Text))
            {
                NavigationService.Navigate(new Uri(string.Format("/SearchResultByDistrictName.xaml?term={0}", DistrictTermBox.Text), UriKind.Relative));
            }
            else
            {
                MessageBox.Show("请输入关键词", "你TM在逗我?", MessageBoxButton.OK);
            }
        }
    }
}