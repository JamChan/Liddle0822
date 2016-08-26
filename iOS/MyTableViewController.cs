using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;

using Debug = System.Diagnostics.Debug;

namespace Liddle.iOS
{
	public partial class MyTableViewController : UIViewController
	{
		public MyTableViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			//
			ShowTable ();
		}

		private void ShowTable () {

			var list = new List<Todo> ();

			list.Add (new Todo { Name = "了解IOC", Description = "控制反轉" });
			list.Add (new Todo { Name = "了解DI", Description = "依賴注入" });
			list.Add (new Todo { Name = "了解 UI Test", Description = "準備自動化 UI 測試" });
			list.Add (new Todo { Name = "了解 Unit Test", Description = "還可整合入 CI" });

			var todoSource = new TodoSource (list);
			myTable.Source = todoSource;

			todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) => {

				Debug.WriteLine ($"Name:{ e.SelectedTodo.Name }; Description:{ e.SelectedTodo.Description }");
			};

		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		class TodoSource : UITableViewSource { 

			private List<Todo> Todoes { get; set; }

			public event EventHandler<TodoSelectedEventArgs> TodoSelected;

			const string MyTableViewCellIdentifier = "MyTableViewCell";

			public TodoSource (IEnumerable<Todo> source) {

				Todoes = new List<Todo> ();
				Todoes.AddRange (source);

			}


			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return Todoes.Count;
			}
		
			public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				MyTableViewCell cell = tableView.DequeueReusableCell (MyTableViewCellIdentifier) as MyTableViewCell;

				var todo = Todoes [indexPath.Row];
				cell.UpdateUI (todo);

				return cell;
			}

			public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				
				tableView.DeselectRow (indexPath, true);

				var todo = Todoes [indexPath.Row];

				EventHandler<TodoSelectedEventArgs> handle = TodoSelected;

				if (null != handle) {
					handle (this, new TodoSelectedEventArgs { SelectedTodo = todo });
				}

			}
		}

		public class TodoSelectedEventArgs : EventArgs { 
		
			public Todo SelectedTodo { get; set; }
		
		}

	}
}


