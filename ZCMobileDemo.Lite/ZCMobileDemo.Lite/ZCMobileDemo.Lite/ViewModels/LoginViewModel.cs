using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCMobileDemo.Lite.Views;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.ViewModels
{
    /// <summary>
    /// LoginViewModel
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Command
        private RelayCommand _Dashboard;

        public RelayCommand Dashboard
        {
            get
            {
                return _Dashboard ?? (_Dashboard = new RelayCommand(() =>
                {
                    App.MasterDetailVM.PushAsync(new Dashboard());

                }));
            }
            set { _Dashboard = value; }
        }

        private RelayCommand _Datacenter;

        public RelayCommand Datacenter
        {
            get
            {
                return _Datacenter ?? (_Datacenter = new RelayCommand(() =>
                {
                    App.MasterDetailVM.Header = "Data Center Page";
                    App.MasterDetailVM.PushAsync(new MainPage());

                }));
            }
            set { _Datacenter = value; }
        }

        private RelayCommand _Login;

        public RelayCommand Login
        {
            get
            {
                return _Login ?? (_Login = new RelayCommand(() =>
                {
                    App.MasterDetailVM.PushAsync(new LoginPage());
                }));
            }
            set { _Login = value; }
        }

        #endregion
    }
}
