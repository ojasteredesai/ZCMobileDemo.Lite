using ZCMobileDemo.Lite.Views;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.ViewModels
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Private Members
        private RelayCommand dashboardCommand;
        private RelayCommand datacenterCommand;
        private RelayCommand loginCommand;
        #endregion

        #region Commands
        /// <summary>
        /// Dashboard
        /// </summary>
        public RelayCommand DashboardCommand
        {
            get
            {
                return dashboardCommand ?? (dashboardCommand = new RelayCommand(() =>
                {
                    App.MasterDetailVM.PushAsync(new Dashboard());

                }));
            }
            set { dashboardCommand = value; }
        }

        /// <summary>
        /// DataCenter
        /// </summary>
        public RelayCommand DatacenterCommand
        {
            get
            {
                return datacenterCommand ?? (datacenterCommand = new RelayCommand(() =>
                {
                    App.MasterDetailVM.Header = "Data Center Page";
                    App.MasterDetailVM.PushAsync(new MainPage());

                }));
            }
            set { datacenterCommand = value; }
        }

        /// <summary>
        /// Login
        /// </summary>
        public RelayCommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(() =>
                {
                    App.MasterDetailVM.PushAsync(new LoginPage());
                }));
            }
            set { loginCommand = value; }
        }
        #endregion
    }
}
