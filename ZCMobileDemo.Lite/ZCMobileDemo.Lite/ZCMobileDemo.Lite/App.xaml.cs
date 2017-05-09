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
        public App()
        {
            InitializeComponent();
            if (App.UserSession == null)
            {
                App.UserSession = new ZCMobileSystemConfiguration { SideContentVisibility = true};
            }
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
    }
}
