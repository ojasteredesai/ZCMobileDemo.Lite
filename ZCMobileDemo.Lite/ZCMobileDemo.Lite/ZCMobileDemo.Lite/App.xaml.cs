using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.ViewModels;
using ZCMobileDemo.Lite.Views;

namespace ZCMobileDemo.Lite
{
    public partial class App : Application
    {
        public static ZCMobileSystemConfiguration UserSession { get; set; }
        public static MasterDetailControlViewModel MasterDetailVM { get; set; }
        public static Dictionary<string, string> PageTitels = new Dictionary<string, string>();
        public App()
        {
            InitializeComponent();
            if (App.UserSession == null)
            {
                App.UserSession = new ZCMobileSystemConfiguration { SideContentVisibility = true};
            }

            GetPageTitles();
            MainPage = MasterDetailControl.Create<MasterDetail, MasterDetailViewModel>(); 
        }

        protected override void OnStart()
        {
            // Handle when your app starts            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void GetPageTitles()
        {
            PageTitels.Add("page1", "Page 1");
            PageTitels.Add("page2", "Page 2");
            PageTitels.Add("page3", "Page 3");
            PageTitels.Add("page4", "Page 4");
            PageTitels.Add("page5", "Page 5");
            PageTitels.Add("page6", "Page 6");
        }
    }
}
