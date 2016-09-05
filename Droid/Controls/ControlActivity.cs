
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

using static System.Diagnostics.Debug;

namespace Liddle.Droid
{
	[Activity (Label = "ControlActivity")]
	public class ControlActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView ( Resource.Layout.control_controlsview );

			var array = new [] { "AAA", "BBB" };


			var selectContent = FindViewById<Spinner> (Resource.Id.control_controlsview_select);

			selectContent.Adapter = new ArrayAdapter<string> (this, 
			                                                  Android.Resource.Layout.SimpleSpinnerItem, 
			                                                  array);

			selectContent.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {


				WriteLine ($"{ array[e.Position] } selected");
			
			};
		}
	}
}

