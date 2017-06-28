using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using ZCMobileDemo.Lite;
using ZCMobileDemo.Lite.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(NoSelectionViewCellRenderer))]
namespace ZCMobileDemo.Lite.iOS
{

    public class NoSelectionViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            UITableViewCell cell = base.GetCell(item, reusableCell, tv);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None; // This does nothing ...
            //if (cell != null)
            //{
            //    cell.SelectedBackgroundView = new UIView
            //    {
            //        BackgroundColor = UIColor.None, // This doesn't matter ...
            //    };
            //}

            //UpdateBackground(cell, item); // This doesn't seem to do anything ...

            return cell;
        }
    }
}