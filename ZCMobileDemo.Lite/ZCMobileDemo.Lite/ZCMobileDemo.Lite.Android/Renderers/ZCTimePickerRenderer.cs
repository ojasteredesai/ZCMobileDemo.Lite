using System;
using System.ComponentModel;
using Android.Content.Res;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZCMobileDemo.Lite.Controls;
using ZCMobileDemo.Lite.Droid.Renderers;
[assembly: ExportRendererAttribute(typeof(ZCTimePicker), typeof(ZCTimePickerRenderer))]

namespace ZCMobileDemo.Lite.Droid.Renderers
{
	public class ZCTimePickerRenderer : TimePickerRenderer
	{
		//public ZCTimePickerRenderer()
		//{
		//}
		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
		{
			base.OnElementChanged(e);

			//this.Control.SetTextColor(Android.Graphics.Color.Green);
		}

	}
}
