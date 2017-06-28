using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ZCMobileDemo.Lite.Behaviors
{
    public class CheckUncheckImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                bool? checkState = value as bool?;

                if (checkState != null)
                {
                    if (checkState.Value) return "checkMatrixBG.png";
                    else return "checkBGOff.png";
                }
            }
            return "checkBGOff.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //private ImageSource ConvertToImageSource(string fileName)
        //{
        //    //return Device.OnPlatform(
        //    //     iOS: ImageSource.FromFile($"Resources/{fileName}"),
        //    //     Android: ImageSource.FromFile(fileName));
        //    return ImageSource.FromFile($"Resources/{fileName}")
        //}
    }
}
