
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

using Debug = System.Diagnostics.Debug;

namespace Liddle.Droid
{
	[Activity (Label = "MyListActivity")]
	public class MyListActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.table_mylistview);

			ShowTable ();
		}

		private void ShowTable ()
		{

			var list = new List<Todo> ();

			list.Add (new Todo { Name = "了解IOC", Description = "控制反轉" });
			list.Add (new Todo { Name = "了解DI", Description = "依賴注入" });
			list.Add (new Todo { Name = "了解 UI Test", Description = "準備自動化 UI 測試" });
			list.Add (new Todo { Name = "了解 Unit Test", Description = "還可整合入 CI" });

			var listView = FindViewById<ListView> (Resource.Id.table_mylistview_todolistview);

			listView.Adapter = new TodoAdapter( list, this) ;

			listView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				var selectedTodo = list [e.Position];

				Debug.WriteLine ($"Name:{ selectedTodo.Name }; Description:{ selectedTodo.Description }");
			
			};

		}

		class TodoAdapter : BaseAdapter<Todo> { 

			private List<Todo> Todoes { get; set; }
			private Activity Context { get; set; }

			public TodoAdapter (IEnumerable<Todo> source, Activity context) { 
			
				Todoes = new List<Todo> ();
				Todoes.AddRange (source);

				Context = context;
			}
		
			public override long GetItemId (int position)
			{
				return position;
			}

			public override Todo this [int position] => Todoes [position];

			public override int Count => Todoes.Count;

			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				var view = convertView;

				if (null == view) {

					view = this.Context.LayoutInflater.Inflate (Resource.Layout.table_mylistview_itemview, parent, false);
				
				}

				var todo = Todoes [position];

				view.FindViewById<TextView> (Resource.Id.table_mylistview_itemview_lbName).Text = todo.Name;
				view.FindViewById<TextView> (Resource.Id.table_mylistview_itemview_lbDescription).Text = todo.Description;

				return view;
			}
		}

	}
}

