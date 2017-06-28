using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using ZCMobileDemo.Lite;
using ZCMobileDemo.Lite.Droid;
using Xamarin.Forms;

//[assembly: ExportRenderer(typeof(ViewCell), typeof(NoSelectionViewCellRenderer))]
namespace ZCMobileDemo.Lite.Droid
{
    public class NoSelectionViewCellRenderer : ViewCellRenderer
    {
        //public override ViewCell GetCell(Cell item, ViewCell reusableCell, ListView listView)
        //{
        //    listView.SetSelector(Android.Resource.Color.Transparent);
        //    listView.CacheColorHint = Xamarin.Forms.Color.Transparent.ToAndroid();


        //    return listView;
        //}
    }
}