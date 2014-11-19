
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AreaCalcFragDemo
{
	enum CalculationType {Rectangle = 1, Triangle, Circle};

	public class SelectFrag : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, 
			ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.SelectFrag, container, false);
			return view;
		}

		public override void OnActivityCreated (Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);

			// Set isDualPane true for landscape orientation
			bool isDualPane = (null != this.Activity.FindViewById (Resource.Id.fragContainer2));

			Button rectangleButton = this.Activity.FindViewById<Button> (Resource.Id.rectangleButton);
			rectangleButton.Click += delegate {
				if(isDualPane) {
					var ft = FragmentManager.BeginTransaction ();
					var fragment2 = FragmentManager.FindFragmentById (Resource.Id.fragContainer2); 
					if (fragment2 != null)
						ft.Remove (fragment2);  // 3 different fragments could be loaded here, so remove whatever is there
					ft.Add (Resource.Id.fragContainer2, new RectangleFrag ());
					ft.Commit ();
				}
				else {
					var intent = new Intent ();
					intent.SetClass (this.Activity, typeof(CalculateActivity));
					intent.PutExtra ("calculation_type", (int)CalculationType.Rectangle);
					StartActivity (intent);
				}

			};

			Button triangleButton = this.Activity.FindViewById<Button> (Resource.Id.triangleButton);
			triangleButton.Click += delegate {
				if (isDualPane) {
					var ft = FragmentManager.BeginTransaction ();
					var fragment2 = FragmentManager.FindFragmentById (Resource.Id.fragContainer2); 
					if (fragment2 != null)
						ft.Remove (fragment2);  
					ft.Add (Resource.Id.fragContainer2, new TriangleFrag ());
					ft.Commit ();
				}
				else {
					var intent = new Intent ();
					intent.SetClass (this.Activity, typeof(CalculateActivity));
					intent.PutExtra ("calculation_type", (int)CalculationType.Triangle);
					StartActivity (intent);
				}
			};

			Button circleButton = this.Activity.FindViewById<Button> (Resource.Id.circleButton);
			circleButton.Click += delegate {
				if(isDualPane) {
					var ft = FragmentManager.BeginTransaction ();
					var fragment2 = FragmentManager.FindFragmentById (Resource.Id.fragContainer2); 
					if (fragment2 != null)
						ft.Remove (fragment2);  
					ft.Add (Resource.Id.fragContainer2, new CircleFrag ());
					ft.Commit ();
			}
				else {
					var intent = new Intent ();
					intent.SetClass (this.Activity, typeof(CalculateActivity));
					intent.PutExtra ("calculation_type", (int)CalculationType.Circle);
					StartActivity (intent);
				}
			};
		}
	}
}

