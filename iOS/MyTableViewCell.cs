using System;

using Foundation;
using UIKit;

namespace Liddle.iOS
{
	public partial class MyTableViewCell : UITableViewCell
	{
		protected MyTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI(Todo todo){

			lbName.Text = todo.Name;
			lbDescription.Text = todo.Description;
		}
	}
}
