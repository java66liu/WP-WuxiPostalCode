using System;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace WuxiPostal
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            InitializeComponent();
        }

        private void MenuEmail_Click(object sender, EventArgs e)
        {
            var emailComposeTask = new EmailComposeTask
            {
                Subject = string.Format("《上海市邮编查询》用户联系作者")
            };

            emailComposeTask.Show();
        }

        private void MenuReview_Click(object sender, EventArgs e)
        {
            var rev = new MarketplaceReviewTask();
            rev.Show();
        }
    }
}