using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ZCMobileDemo.Lite.Controls;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(ZCMobileDemo.Lite.iOS.Renderers.RoundedButtonRenderer))]
namespace ZCMobileDemo.Lite.iOS.Renderers
{
    public class RoundedButtonRenderer: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (RoundedButton)e.NewElement;
                if(button !=null)
                {
                    button.SizeChanged += (s, args) =>
                    {
                        var radius = Math.Min(button.Width, button.Height) / 2.0;
                        button.BorderRadius = (int)(radius);
                    };
                }
              
                
            }
        }
    }
}