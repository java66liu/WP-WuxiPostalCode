using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using MVVMSidekick.Views;
using System;
using System.Windows.Controls;
using WuxiPostal.Models;
using WuxiPostal.ViewModels;

namespace WuxiPostal
{
    public partial class MainPage : MVVMPage
    {
        public MainPage()
            : base(null)
        {
            InitializeComponent();
        }

        public MainPage(MainPage_Model model)
            : base(model)
        {
            InitializeComponent();
        }

        private void MenuReview_Click(object sender, EventArgs e)
        {
            var rev = new MarketplaceReviewTask();
            rev.Show();
        }

        private void MenuReportError_Click(object sender, EventArgs e)
        {
            Utils.ReportError("MainPage");
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void MenuSearch_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchForm.xaml", UriKind.Relative));
        }

        private void SelectDistrict(object sender, SelectionChangedEventArgs e)
        {
            object selected = ((LongListSelector)(sender)).SelectedItem;
            if (null != selected)
            {
                string dId = ((District)(selected)).Id;
                NavigationService.Navigate(new Uri(string.Format("/DistrictDetail.xaml?dId={0}", dId),
                    UriKind.Relative));
            }

            DistrictSelector.SelectedItem = null;
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
    }
}
