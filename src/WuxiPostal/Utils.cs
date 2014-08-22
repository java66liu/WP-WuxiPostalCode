using System;
using Microsoft.Phone.Tasks;

namespace WuxiPostal
{
    public class Utils
    {
        public string AppVersion
        {
            get { return GetType().Assembly.GetName().Version.ToString(); }
        }

        public static string Version
        {
            get { return new Utils().AppVersion; }
        }

        public static void ReportError(string viewName)
        {
            var emailComposeTask = new EmailComposeTask
            {
                Subject = "《无锡邮编查询》Windows Phone应用错误报告",
                Body = "程序版本：" + Version + "，所在页面：" + viewName + Environment.NewLine,
                To = "Edi.Wang@outlook.com"
            };

            emailComposeTask.Show();
        }
    }
}