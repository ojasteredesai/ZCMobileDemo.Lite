using System.Collections;
using System.Linq;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Behaviors;
using ZCMobileDemo.Lite.Model;
using ZCMobileDemo.Lite.Views.Module;

namespace ZCMobileDemo.Lite.Controls
{
    /// <summary>
    /// User Defind field Handling Control
    /// </summary>
    public class UDFListControl : ContentView
    {
        #region Bindable Properties
        public static readonly BindableProperty UDFListProperty = BindableProperty.Create("UDFList", typeof(IEnumerable), typeof(UDFListControl), null, propertyChanged: OnUDFlstpropertyChanged);
        #endregion

        #region Properties
        public IList UDFList
        {
            get { return (IList)GetValue(UDFListProperty); }
            set { SetValue(UDFListProperty, value); }
        }
        #endregion

        #region Constructor
        public UDFListControl()
        {
            Content = new StackLayout();
            MessagingCenter.Subscribe<DropDownItem>(this, "SelectedUDF", (sa) =>
            {
                var ddlList = UDFList.Cast<UserDefinedFields>().Where(p => p.ControlID == 3);
                var updatedddlList = ddlList.Where(p => p.ID == sa.ShareWithID.Value.ToString()).FirstOrDefault();
                updatedddlList.Value = sa.Name;
                var tem = this.Content as StackLayout;
                var updatedEntry = tem.Children.Where(p => p.StyleId == sa.ShareWithID.Value.ToString()).FirstOrDefault();
                if (updatedEntry != null)
                    (updatedEntry as Entry).Text = sa.Name;
            });
        }
        #endregion

        #region Private Methods
        private static void OnUDFlstpropertyChanged(BindableObject bindable,object oldValue,object newValue)
        {
            if (newValue == null)
                return;

            var udfControl = bindable as UDFListControl;
            udfControl.Content = new StackLayout();

            var st = udfControl.Content as StackLayout;

            foreach (var item in newValue as IEnumerable)
            {
                var udffield = item as UserDefinedFields;
                switch (udffield.ControlID)
                {
                    case 1:
                        Entry txt = new Entry();
                        txt.StyleId = udffield.ID;
                        txt.IsEnabled = !udffield.IsDisabled;
                        txt.Text = udffield.Value;
                        if (udffield.IsRequired)
                        {
                            txt.Behaviors.Add(new RequiredValidatorBehavior());
                        }
                        txt.TextChanged += (ea, sa) =>
                        {
                            var entry = ea as Entry;
                            var udfl = udfControl.UDFList as IEnumerable;
                            var udllst = udfl.Cast<UserDefinedFields>();
                            if (udllst.Any(p => p.ID == entry.StyleId))
                            {
                                udllst.Where(p => p.ID == entry.StyleId).FirstOrDefault().Value = entry.Text;
                            }

                        };
                        st.Children.Add(txt);
                        break;
                    case 2:
                        CheckBox ck = new CheckBox();
                        ck.StyleId = udffield.ID;
                        ck.Checked = udffield.IsUDFBool;
                        ck.IsEnabled = !udffield.IsDisabled;
                        ck.DefaultText = udffield.Value;
                        ck.CheckedChanged += (ea, sa) =>
                        {
                            var chk = ea as CheckBox;
                            var udfl = udfControl.UDFList as IEnumerable;
                            var udllst = udfl.Cast<UserDefinedFields>();
                            if (udllst.Any(p => p.ID == chk.StyleId))
                            {
                                udllst.Where(p => p.ID == chk.StyleId).FirstOrDefault().IsUDFBool = chk.Checked;
                            }
                        };
                        st.Children.Add(ck);
                        break;
                    case 3:
                        Entry combo = new Entry();
                        combo.StyleId = udffield.ID;
                        combo.Text = udffield.Value;
                        combo.Focused += (ea, sa) =>
                        {
                            UDFDDMenu dd = new UDFDDMenu();
                            dd.ItemSource = udffield.UserDefinedDropDown;
                            var navigationData = new ZCMobileNavigationData
                            {
                                CurrentPage = null,
                                CurrentPageTitle = App.PageTitels["dossier"],
                                NextPage = dd,
                                NextPageTitle = App.PageTitels["fcm"]
                            };

                            App.MasterDetailVM.PushAsync(navigationData);
                        };
                        st.Children.Add(combo);
                        break;
                    default:
                        break;
                }

            }
        }
        #endregion
    }
    
   
}
