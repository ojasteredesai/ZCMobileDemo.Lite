using ZCMobileDemo.Lite.Views;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Commands
        private RelayCommand _LoginType;

        public RelayCommand LoginType
        {
            get
            {
                return _LoginType ?? (_LoginType = new RelayCommand(() =>
                {
                    App.UserSession.SelectedDataCenter = "US";
                    App.Current.Properties[App.SelectedDataCenter] = App.UserSession.SelectedDataCenter;
                    // App.Current.MainPage = new LoginTypePage();
                    App.MasterDetailVM.PushAsync(new LoginTypePage());
                }));
            }
            set { _LoginType = value; }
        }
        private RelayCommand _Back;

        public RelayCommand Back
        {
            get
            {
                return _Back ?? (_Back = new RelayCommand(() =>
                {
                    App.Current.MainPage = new LoginPage();
                }));
            }
            set { _Back = value; }
        }

        #endregion

    }
}
