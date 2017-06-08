using System.Threading.Tasks;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Views.Timesheet;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class Page2ViewModel : BaseViewModel
    {
        #region Private Members
        private string message1 = "Message 1 - Page 2";
        private string message2 = "Message 2 - Page 2";
        private RelayCommand nextcommand;
        private RelayCommand previousCommand;
        #endregion

        #region Public Properties
        public string Messsge1
        {
            get
            {
                return message1;
            }
            set
            {
                message1 = value;
                RaisePropertyChanged();
            }
        }

        public string Messsge2
        {
            get
            {
                return message2;
            }
            set
            {
                message2 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// NextCommand
        /// </summary>
        public RelayCommand NextCommand
        {
            get
            {
                return nextcommand ?? (nextcommand = new RelayCommand(async () =>
                {
                    App.MasterDetailVM.IsExecuting = true;
                    await Task.Delay(1800);
                    var navigationData = new ZCMobileNavigationData
                    {
                        CurrentPage = new Page2(),
                        CurrentPageTitle = App.MasterDetailVM.Header1,
                        NextPage = new Page3(),
                        NextPageTitle = App.PageTitels["page3"]
                    };

                    App.MasterDetailVM.PushAsync(navigationData);
                    App.MasterDetailVM.IsExecuting = false;
                }));
            }
            set { nextcommand = value; }
        }

        /// <summary>
        /// PreviousCommand
        /// </summary>
        public RelayCommand PreviousCommand
        {
            get
            {
                return previousCommand ?? (previousCommand = new RelayCommand(() =>
                {
                    //  App.MasterDetailVM.IsExecuting = true;
                    var bindingContext = this;
                    App.ApplicationDataViewModel = new Page1ViewModel { Messsge1 = bindingContext.Messsge1, Messsge2 = bindingContext.Messsge2 };
                    App.MasterDetailVM.PushAsyncPreviousPage(new Page1());
                    //  App.MasterDetailVM.IsExecuting = false;
                }));
            }
            set { previousCommand = value; }
        }
        #endregion
    }
}
