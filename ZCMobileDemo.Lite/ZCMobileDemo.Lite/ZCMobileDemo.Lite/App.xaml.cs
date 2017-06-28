using System.Collections.Generic;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.ViewModels;
using ZCMobileDemo.Lite.Views;

namespace ZCMobileDemo.Lite
{

    public partial class App : Application
    {
        #region Public Properties
        public static object ApplicationDataViewModel { get; set; }
        public static ZCMobileSystemConfiguration UserSession { get; set; }
        public static MasterDetailControlViewModel MasterDetailVM { get; set; }
        public static Dictionary<string, string> PageTitels;
        public const string SelectedDataCenter = "SelectedDataCenter";
        public static bool IsUSerLoggedIn = false;
        public const int Take = 5;
    #endregion

    #region Constructors
    public App()
        {
            Page page;
            InitializeComponent();
            if (App.UserSession == null)
            {
                App.UserSession = new ZCMobileSystemConfiguration { SideContentVisibility = true};
            }

            if (Properties.ContainsKey(SelectedDataCenter))
            {
                App.UserSession.SelectedDataCenter = (string)Properties[SelectedDataCenter];
            }

            if (!string.IsNullOrEmpty(App.UserSession.SelectedDataCenter))
            {
                page = new LoginPage();
                page.Title = "Login PAge";
            }
            else
            {
                page = new MainPage();
                page.Title = "DataCenter PAge";
            }

            App.Current.MainPage = MasterDetailControl.Create<MasterDetail, MasterDetailViewModel>(App.IsUSerLoggedIn, page);
            GetPageTitles();
        }
        #endregion

        #region Xamarin App Events
        protected override void OnStart()
        {
            // Handle when your app starts            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Properties[SelectedDataCenter] = App.UserSession.SelectedDataCenter;
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        #endregion

        #region Private Methods
        private void GetPageTitles()
        {
            PageTitels = new Dictionary<string, string>();
            PageTitels.Add("page1", "Page 1");
            PageTitels.Add("page2", "Page 2");
            PageTitels.Add("page3", "Page 3");
            PageTitels.Add("page4", "Page 4");
            PageTitels.Add("page5", "Page 5");
            PageTitels.Add("page6", "Page 6");
            PageTitels.Add("dossier", "Dossier");
            PageTitels.Add("fcm", "FCM");
            PageTitels.Add("viewTime", "View Timesheet");
            PageTitels.Add("appTime", "Approve Timesheet");
        }
        #endregion
    }
}
