
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

namespace AreaCalcFragDemo
{
	[Activity (Label = "CalculateActivity")]			
	public class CalculateActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.CalculateActivity);	// Reuse the portrait main activity layout

			var ft = FragmentManager.BeginTransaction ();
			var frag = FragmentManager.FindFragmentById (Resource.Id.fragContainer1); 
			if (frag != null)
				ft.Remove (frag);  // 3 different fragments could be loaded here, so remove whatever is there
			switch ((CalculationType)Intent.GetIntExtra ("calculation_type", 0)) {
			case CalculationType.Rectangle:
				ft.Add (Resource.Id.fragContainer1, new RectangleFrag ());
				break;
			case CalculationType.Triangle:
				ft.Add (Resource.Id.fragContainer1, new TriangleFrag ());
				break;
			case CalculationType.Circle:
				ft.Add (Resource.Id.fragContainer1, new CircleFrag ());
				break;
			default:
				break;
			}

			ft.Commit ();		}
	}
}

