using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Views.Timesheet;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class Page1ViewModel : BaseViewModel
    {
        #region Private Members
        private string message1 = "Message 1 - Page 1";
        private string message2 = "Message 2 - Page 1";
        private RelayCommand nextcommand;
        #endregion

        #region
        public Page1ViewModel()
        {
            App.MasterDetailVM.RightButtonVisibility = true;
        }
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
        public RelayCommand NextCommand
        {
            get
            {
                return nextcommand ?? (nextcommand = new RelayCommand(async () =>
                {
                    App.MasterDetailVM.IsExecuting = true;
                    await Task.Delay(1800);
                    var bindingContext = this;
                    App.ApplicationDataViewModel = new Page2ViewModel { Messsge1 = bindingContext.Messsge1, Messsge2 = bindingContext.Messsge2 };

                    var navigationData = new ZCMobileNavigationData
                    {
                        CurrentPage = new Page1(),
                        CurrentPageTitle = App.MasterDetailVM.Header,
                        NextPage = new Page2(),
                        NextPageTitle = App.PageTitels["page2"]
                    };

                    App.MasterDetailVM.PushAsync(navigationData);
                    App.MasterDetailVM.IsExecuting = false;
                }));
            }
            set { nextcommand = value; }
        }

        #endregion
    }
}
