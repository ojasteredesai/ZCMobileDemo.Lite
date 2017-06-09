using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite.Controls
{
    /// <summary>
    /// This is custom Control for Handling FCM
    /// </summary>
    public class FCMLabelList : ContentView
    {
        #region Bindable Properties 
        public static readonly BindableProperty FCMListProperty = BindableProperty.Create("FCMList", typeof(IEnumerable), typeof(FCMLabelList), null, propertyChanged: OnFCMlstPropertyChanged);

        #endregion

        #region Constructor
        public FCMLabelList()
        {
            Content = new StackLayout();
        }
        #endregion

        #region Properties
        public IList FCMList
        {
            get { return (IList)GetValue(FCMListProperty); }
            set { SetValue(FCMListProperty, value); }
        }
        #endregion


        #region Private Method
        private static void OnFCMlstPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var lst = (FCMLabelList)bindable;
            lst.Content = new StackLayout();
            var st = lst.Content as StackLayout;
            if (newValue == null)
                return;
            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    lst.Content = new StackLayout();
                    st = lst.Content as StackLayout;
                    if (args.NewItems != null)
                    {
                        foreach (var item in newValue as IEnumerable)
                        {
                            var it = item as FCMFields;
                            if (it.IsVisible)
                            {
                                st.Children.Add(new Label() { Text = it.DisplayName });
                                st.Children.Add(new Label() { Text = it.DefaultValue });
                            }
                        }
                    }                    
                };
            }

            foreach (var item in newValue as IEnumerable)
            {
                var it = item as FCMFields;
                if(it.IsVisible)
                {
                    st.Children.Add(new Label() { Text = it.DisplayName });
                    st.Children.Add(new Label() { Text = it.DefaultValue });
                }
            }
        }
        #endregion
    }
}
