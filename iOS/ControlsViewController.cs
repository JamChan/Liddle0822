using System;
using System.Collections.Generic;

using UIKit;

namespace Liddle.iOS
{
	public partial class ControlsViewController : UIViewController
	{
		public ControlsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			var urls = new List<string> {"AAA","BBB" };


			var model = new UrlPickerViewModel (urls);


			pickUrl.Model = model;

			model.RowSelected += (object sender, RowSelectedEventArgs e) => { 
			
			
			};

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public class UrlPickerViewModel : UIPickerViewModel 
		{
			public List<string> Urls { get; set; }

			public UrlPickerViewModel (List<string> urls)
			{
				Urls = new List<string> (urls);
			}

			public override nint GetRowsInComponent (UIPickerView pickerView, nint component)
			{
				return Urls.Count;
			}

			public override string GetTitle (UIPickerView pickerView, nint row, nint component)
			{
				return Urls [(int)row];
			}

			public override nint GetComponentCount (UIPickerView pickerView)
			{
				return 1;
			}


			public event EventHandler<RowSelectedEventArgs> RowSelected;

			public override void Selected (UIPickerView pickerView, nint row, nint component)
			{
				EventHandler<RowSelectedEventArgs> handle = RowSelected;

				if (null != handle) {
					var args = new RowSelectedEventArgs { SelectedIndex = (int)row, SelectedTitle = Urls [(int)row] };
					handle (this, args);
				}
			}
		}

		public class RowSelectedEventArgs : EventArgs
		{
			public string SelectedTitle { get; set; }
			public int SelectedIndex { get; set; }
		}
	}
}


