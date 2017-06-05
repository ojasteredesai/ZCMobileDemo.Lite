using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ZCMobileDemo.Lite.Model;
using System.Globalization;
using ZCMobileDemo.Lite.Interfaces;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Behaviors;

namespace ZCMobileDemo.Lite.ViewModels
{
    public class DossierViewModel : BaseViewModel
    {
        #region Constructor
        public DossierViewModel()
        {
            LoadLanguages();
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



        #endregion
        #region Properties
        private ObservableCollection<Language> _Languages;

        public ObservableCollection<Language> Languages
        {
            get { return _Languages ?? (_Languages = new ObservableCollection<Language>()); }
            set { _Languages = value; RaisePropertyChanged(); }
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

        #endregion

        #region Private Methods
        private void LoadLanguages()
        {
            Languages.Add(new Language { Name = "English", code = "en-US" });
            Languages.Add(new Language { Name = "German", code = "de-DE" });
        }
        #endregion
    }
}
