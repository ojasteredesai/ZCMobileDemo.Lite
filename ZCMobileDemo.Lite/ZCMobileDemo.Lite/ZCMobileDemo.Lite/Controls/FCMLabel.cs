using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZCMobileDemo.Lite.Model;

namespace ZCMobileDemo.Lite.Controls
{
    public class FCMLabel : Label
    {
        #region Bindable Properties 
        public static readonly BindableProperty FCMLblProperty = BindableProperty.Create("FCMLabel", typeof(FCMFields), typeof(FCMLabel), null, propertyChanged: OnFCMlstPropertyChanged);
        #endregion

        #region Properties
        public FCMFields FCMLbl
        {
            get { return (FCMFields)GetValue(FCMLblProperty); }
            set { SetValue(FCMLblProperty, value); }
        }

        #endregion

        #region Private Method
        private static void OnFCMlstPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var label = bindable as FCMLabel;
            var fcmValue = newValue as FCMFields;
            if (newValue != null)
            {
                label.IsVisible = fcmValue.IsVisible;
                if (fcmValue.IsVisible)
                {
                    label.Text = fcmValue.DisplayName;
                }
            }
        }
        #endregion
    }
}
