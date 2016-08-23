using System;

using UIKit;

namespace Liddle.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();



			Button.TouchUpInside += (sender, e) => {
				// moveToMapViewSegue
				PerformSegue ("moveToMapViewSegue", this);
			};

			btnConfirm.TouchUpInside += (sender, e) => {
				// moveToWebViewSegue
				PerformSegue ("moveToWebViewSegue", this);
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
