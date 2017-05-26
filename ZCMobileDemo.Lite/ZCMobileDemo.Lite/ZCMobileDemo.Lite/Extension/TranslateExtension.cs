using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using ZCMobileDemo.Lite.Utility;

namespace ZCMobileDemo.Lite.Extension
{
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var translated = CultureUtility.GetResxNameByValue(Text);

            return translated;
        }
    }
}
