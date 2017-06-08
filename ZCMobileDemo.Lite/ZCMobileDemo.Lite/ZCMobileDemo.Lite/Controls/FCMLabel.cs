using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite.Controls
{
    /// <summary>
    /// This is custome Control for Handling FCM
    /// </summary>
    public class FCMLabellist : ContentView
    {
        #region Bindable Properties 
        public static readonly BindableProperty FCMlstProperty = BindableProperty.Create("FCMlst", typeof(IEnumerable), typeof(FCMLabellist), null, propertyChanged: OnFCMlstPropertyChanged);

        #endregion

        #region Constructor
        public FCMLabellist()
        {
            Content = new StackLayout();
        }
        #endregion

        #region Properties
        public IList FCMlst
        {
            get { return (IList)GetValue(FCMlstProperty); }
            set { SetValue(FCMlstProperty, value); }
        }
        private IList _FCMlst;

        #endregion


        #region Private Method
        private static void OnFCMlstPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var lst = (FCMLabellist)bindable;
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
