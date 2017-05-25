using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.ViewModels;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailControl
    {
        #region Private Members
        private bool secondDetailPageVisible = false;
        #endregion

        #region Public Bindable Properties
        /// <summary>
        /// Bindable property for navigation slider.
        /// </summary>
        public static readonly BindableProperty SideContentProperty = BindableProperty.Create("SideContent",
            typeof(Xamarin.Forms.View), typeof(MasterDetailControl), null, propertyChanged: (bindable, value, newValue) =>
            {
                var control = (MasterDetailControl)bindable;
                control.SideContentContainer.Children.Clear();
                control.SideContentContainer.Children.Add(control.SideContent);
            });


        /// <summary>
        /// Bindable property for contentview. When the orientation is landscape it holds pages like listview and divison/requisition selector
        /// </summary>
        public BindableProperty DetailProperty = BindableProperty.Create("Detail",
            typeof(ContentPage), typeof(MasterDetailControl),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                masterPage.DetailContainer.Content = newValue != null ?
                    ((ContentPage)newValue).Content : null;
                if (masterPage.DetailContainer.Content != null)
                {
                    masterPage.DetailContainer.Content.BindingContext = newValue != null ? (newValue as Page).BindingContext : null;
                }

                masterPage.OnPropertyChanged("SideContentVisible");

            });

        /// <summary>
        ///  Bindable property for contentview1. When the orientation is landscape it holds pages like detail view and filters.
        ///  It is not visible for portrait mode.
        /// </summary>
        public BindableProperty DetailProperty1 = BindableProperty.Create("Detail1",
            typeof(ContentPage), typeof(MasterDetailControl),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                masterPage.DetailContainer1.Content = newValue != null ?
                    ((ContentPage)newValue).Content : null;
                if (masterPage.DetailContainer1.Content != null)
                {
                    masterPage.DetailContainer1.Content.BindingContext = newValue != null ? (newValue as Page).BindingContext : null;
                }

                masterPage.OnPropertyChanged("SideContentVisible");

            });

        /// <summary>
        /// Gets and sets the navigation slider.
        /// </summary>
        public View SideContent
        {
            get { return (Xamarin.Forms.View)GetValue(SideContentProperty); }
            set { SetValue(SideContentProperty, value); }
        }

        public bool SideContentVisible
        {
            get
            {
                return App.UserSession.SideContentVisibility;
            }
        }

        //public bool SecondDetailPageVisible
        //{
        //    get
        //    {
        //        return secondDetailPageVisible;
        //    }
        //    set
        //    {
        //        secondDetailPageVisible = value;
        //    }
        //}
        #endregion

        #region Constructors
        public MasterDetailControl()
        {
            InitializeComponent();
            SetBinding(DetailProperty, new Binding("Detail", BindingMode.TwoWay));
            SetBinding(DetailProperty1, new Binding("Detail1", BindingMode.TwoWay));
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// This is the method that initiates masterdetail page. It binds the page with the master view model that is being used across the application code.
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="userLoggedIn"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Page Create<TView, TViewModel>(bool userLoggedIn = true, Page page = null) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel, new()
        {
            return Create<TView, TViewModel>(new TViewModel(), userLoggedIn, page);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="viewModel"></param>
        /// <param name="userLoggedIn"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static Page Create<TView, TViewModel>(TViewModel viewModel, bool userLoggedIn = true, Page page = null) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel
        {
            try
            {
                #region commented code
                //This condition sets the visibility of the side bar as per device orientation. For portrait mode side content is not shown.
                //if (userLoggedIn)
                //{
                //    App.IsUSerLoggedIn = true;
                //    App.UserSession.SideContentVisibility = (!viewModel.Isportrait);
                //}
                //else
                //{
                //    App.UserSession.SideContentVisibility = false;
                //}
                #endregion
                var masterDetail = new TView();
               // var navigationPage = new NavigationPage(masterDetail);
                var navigationPage = masterDetail;
                viewModel.SetNavigation(navigationPage.Navigation);
                viewModel.Header = (!string.IsNullOrEmpty(App.UserSession.SelectedDataCenter) ? "Login Page" : "Data Center Page");
                viewModel.RightButton = string.Empty;
                masterDetail.BindingContext = viewModel;
                App.MasterDetailVM = viewModel;
                if (userLoggedIn)
                {
                    App.MasterDetailVM.PushAsync(new Dashboard());
                }
                else
                {
                    App.UserSession.SideContentVisibility = false;
                    App.MasterDetailVM.PushAsync(page);
                }
                return navigationPage;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;

            }

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Hamgurger icon method. This method to be converted to ICommand implementation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.MasterDetailVM.IsExecuting = true;
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            OnPropertyChanged("SideContentVisible");
            App.MasterDetailVM.IsExecuting = false;
        }

        /// <summary>
        /// Back button method for IOS. To be converted to ICommand implementation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TapGestureRecognizerBack_Tapped(object sender, EventArgs e)
        {
            if (App.IsUSerLoggedIn)
            {
                App.MasterDetailVM.IsExecuting = true;
                App.MasterDetailVM.PopAsync1();
                App.MasterDetailVM.IsExecuting = false;
            }
            else
            {
                App.MasterDetailVM.PopAsyncInitialPages();
            }
        }
        #endregion
    }
}
