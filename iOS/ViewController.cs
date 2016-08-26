using System;

using UIKit;

namespace Liddle.iOS
{
	public partial class ViewController : UIViewController
	{
		private string NextUrl { get; set; }
		//private KeyValueManager StoreManager { get; set; }

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//StoreManager = new KeyValueManager ();
			//NextUrl = "https://www.google.com";
			//StoreManager.SaveNSDefaults ("nextUrl", NextUrl);

			Button.TouchUpInside += (sender, e) => {
				// moveToMapViewSegue
				PerformSegue ("moveToMapViewSegue", this);
			};

			btnConfirm.TouchUpInside += (sender, e) => {
				// moveToWebViewSegue
				PerformSegue ("moveToWebViewSegue", this);
			};

			btnTable.TouchUpInside += (sender, e) => {
				PerformSegue ("moveMyTableViewSegue", this);
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

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			if ("moveToMapViewSegue" == segue.Identifier) {

				if (segue.DestinationViewController is MyMapViewController) {

					var dest = segue.DestinationViewController as MyMapViewController;


					dest.TitleString = "Bye! Bye!";
				
				}
			
			
			}


		}
	}
}
