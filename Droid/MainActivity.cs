using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Liddle.Droid
{
	[Activity (Label = "Liddle", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// 
			var btnMap = FindViewById<Button> (Resource.Id.main_menuview_btnMap);
			btnMap.Click += (sender, e) => {

				StartActivity ( typeof(MyMapActivity) );

			};


			var btnWeb = FindViewById<Button> (Resource.Id.main_menuview_btnWeb);
			btnWeb.Click += (sender, e) => {
				Intent webActivity = new Intent (this, typeof (MyWebActivity));

				webActivity.PutExtra ("url", "https://stackoverflow.com");

				StartActivity (webActivity);
			};


			var btnTable = FindViewById<Button> (Resource.Id.main_menuview_btnTable);
			btnTable.Click += (sender, e) => {

				StartActivity (typeof (MyListActivity));

			};

		}
	}
}


