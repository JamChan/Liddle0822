// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Liddle.iOS
{
	[Register ("MyWebViewController")]
	partial class MyWebViewController
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint btnGoBottomConstraint { get; set; }

		[Outlet]
		UIKit.UIWebView myWebView { get; set; }

		[Outlet]
		UIKit.UITextField txtUrl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGoBottomConstraint != null) {
				btnGoBottomConstraint.Dispose ();
				btnGoBottomConstraint = null;
			}

			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (myWebView != null) {
				myWebView.Dispose ();
				myWebView = null;
			}

			if (txtUrl != null) {
				txtUrl.Dispose ();
				txtUrl = null;
			}
		}
	}
}
