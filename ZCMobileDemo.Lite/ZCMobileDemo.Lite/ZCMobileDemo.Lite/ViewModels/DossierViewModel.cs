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
                        CultureInfo cl = new CultureInfo(selectedlanguage.code);
                        DependencyService.Get<ILocalization>().SetCulture(cl);
                        App.MasterDetailVM.LoadAccordian();
                        App.MasterDetailVM.RaisePropertyChanged("AccordionItems");
                        App.MasterDetailVM.RaisePropertyChanged("AccordionContent");
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

        #endregion

        #region Private Methods
        private void LoadLanguages()
        {
            Languages.Add(new Language { Name = "English", code = "en" });
            Languages.Add(new Language { Name = "German", code = "de" });
        }
        #endregion
    }
}
