using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite.Views.Module
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UDFDDMenu : ContentPage
    {
        public UDFDDMenu()
        {
            InitializeComponent();
        }
        public int ID { get; set; }
        private IList _ItemSource;

        public IList ItemSource
        {
            get { return (IList)lst.ItemsSource; }
            set { lst.ItemsSource = value; }
        }

        private void lst_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedItem as DropDownItem;
            App.MasterDetailVM.PopAsync1();
            MessagingCenter.Send(new DropDownItem() { Name = selectedItem.Name, Value = selectedItem.Value,ShareWithID=selectedItem.ShareWithID }, "SelectedUDF");
          
        }
    }
}