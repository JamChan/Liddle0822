using System;

using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace Liddle.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		private KeyValueManager StoreManager { get; set; }

		public MyWebViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Web";

			StoreManager = new KeyValueManager ();


			btnGo.TouchUpInside += (sender, e) => {

				if (txtUrl.IsFirstResponder) {
					txtUrl.ResignFirstResponder ();
				}
				btnGoBottomConstraint.Constant = 10;

				var url = StoreManager.ReadNSDefaults ("nextUrl");
				var uriString = string.IsNullOrEmpty (txtUrl.Text) ? url : txtUrl.Text;

				myWebView.LoadRequest (new NSUrlRequest (new NSUrl (uriString )));
			};

			UIKeyboard.Notifications.ObserveWillChangeFrame ((sender, e) => {

				var beginRect = e.FrameBegin;
				var endRect = e.FrameEnd;

				Debug.WriteLine ($"ObserveWillChangeFrame endRect:{endRect.Height}");

				btnGoBottomConstraint.Constant = endRect.Height + 5;

			});


		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


