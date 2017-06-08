using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Interfaces;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class DossierViewModel : BaseViewModel
    {
        #region Constructor
        public DossierViewModel()
        {
            LoadLanguages();
            LoadUDFs();

        }
        #endregion
        #region Commands
        private RelayCommand _LanguageSelected;

        public RelayCommand LanguageSelected
        {
            get
            {
                return _LanguageSelected ?? (_LanguageSelected = new RelayCommand(() =>
                {
                    var selectedlanguage = Languages.Where(p => p.code == SelectedLanguage.code).FirstOrDefault();
                    if (selectedlanguage != null)
                    {

                        DependencyService.Get<ILocalization>().SetCulture(selectedlanguage.code);
                        App.MasterDetailVM.LoadAccordian();
                        App.MasterDetailVM.RaisePropertyChanged("AccordionItems");
                        App.MasterDetailVM.RaisePropertyChanged("AccordionContent");
                        var dueDatePicker = new DatePicker();
                        DateContent = dueDatePicker;
                    }

                }));
            }
            set { _LanguageSelected = value; }
        }

        private RelayCommand _AddFCM;

        public RelayCommand AddFCM
        {
            get
            {
                return _AddFCM ?? (_AddFCM = new RelayCommand(() =>
          {
              FCM fcm = new FCM();
              fcm.BindingContext = this;
              var navigationData = new ZCMobileNavigationData
              {
                  CurrentPage = null,
                  CurrentPageTitle = App.PageTitels["dossier"],
                  NextPage = fcm,
                  NextPageTitle = App.PageTitels["fcm"]
              };

              App.MasterDetailVM.PushAsync(navigationData);
          }));
            }
            set { _AddFCM = value; }
        }


        private RelayCommand _SaveFCM;

        public RelayCommand SaveFCM
        {
            get
            {
                return _SaveFCM ?? (_SaveFCM = new RelayCommand(() =>
          {
              FcmListData.Add(new FCMFields() { DefaultValue = FCMFieldsData.DefaultValue, DisplayName = FCMFieldsData.DisplayName, IsModified = FCMFieldsData.IsModified, IsVisible = FCMFieldsData.IsVisible });
              FCMFieldsData = new FCMFields();
              RaisePropertyChanged("FcmListData");
              App.MasterDetailVM.PopAsync1();

          }));
            }
            set { _SaveFCM = value; }
        }

        private RelayCommand _CheckUpdate;

        public RelayCommand CheckUpdate
        {
            get
            {
                return _CheckUpdate ?? (_CheckUpdate = new RelayCommand(() =>
                {
                    foreach (var item in UDFListData)
                    {
                        
                      App.Current.MainPage.DisplayAlert("UDF", item.Value, "OK");
                      
                    }

                }));
            }
            set { _CheckUpdate = value; }
        }





        #endregion
        #region Properties
        private FCMFields _FCMFieldsData;

        public FCMFields FCMFieldsData
        {
            get { return _FCMFieldsData ?? (_FCMFieldsData = new FCMFields()); }
            set { _FCMFieldsData = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Language> _Languages;

        public ObservableCollection<Language> Languages
        {
            get { return _Languages ?? (_Languages = new ObservableCollection<Language>()); }
            set { _Languages = value; RaisePropertyChanged(); }
        }
        //UDFListData
        private ObservableCollection<UserDefinedFields> _UDFListData;

        public ObservableCollection<UserDefinedFields> UDFListData
        {
            get { return _UDFListData ?? (_UDFListData = new ObservableCollection<UserDefinedFields>()); }
            set { _UDFListData = value; RaisePropertyChanged(); }
        }
       

        private ObservableCollection<FCMFields> _FcmListData;

        public ObservableCollection<FCMFields> FcmListData
        {
            get { return _FcmListData ?? (_FcmListData = new ObservableCollection<FCMFields>()); }
            set { _FcmListData = value; RaisePropertyChanged(); }
        }

        private Language _SelectedLanguage;

        public Language SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set { _SelectedLanguage = value; RaisePropertyChanged(); }
        }

        private View _DateContent;

        public View DateContent
        {
            get { return _DateContent; }
            set { _DateContent = value; RaisePropertyChanged(); }
        }
        private DateTime _SelectedDate;

        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { _SelectedDate = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Private Methods
        private void LoadLanguages()
        {
            Languages.Add(new Language { Name = "English", code = "en-US" });
            Languages.Add(new Language { Name = "German", code = "de-DE" });
        }
        private void LoadUDFs()
        {
            UDFListData.Add(new UserDefinedFields { ControlID = 1, ID = "2", IsRequired = true, Value = "Test" });
            UDFListData.Add(new UserDefinedFields { ControlID = 2, ID = "3", IsRequired = true, Value = "Check Checkbox",IsUDFBool=true });
            UDFListData.Add(new UserDefinedFields { ControlID = 1, ID = "4", IsRequired = true, Value = "Test second",IsDisabled=true });
            var userDDmenu = new List<DropDownItem>();
            userDDmenu.Add(new DropDownItem { Name = "Contact 1", Value = "1",ShareWithID=5 });
            userDDmenu.Add(new DropDownItem { Name = "Contact 2", Value = "2" , ShareWithID = 5 });
            UDFListData.Add(new UserDefinedFields { ControlID = 3, ID = "5", IsRequired = true, Value = "Contact", IsDisabled = true,UserDefinedDropDown= userDDmenu });
        }

        #endregion
    }
   
}
