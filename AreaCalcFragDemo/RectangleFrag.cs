﻿
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
	public class RectangleFrag : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, 
			ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate (Resource.Layout.RectangleFrag, container, false);

			// Get the height and width entered by the user and convert the data type
			EditText heightEditText = view.FindViewById<EditText> (Resource.Id.heightEditText);
			EditText widthEditText = view.FindViewById<EditText> (Resource.Id.widthEditText);

			Button button = view.FindViewById<Button> (Resource.Id.calculateButton);
			button.Click += delegate {
				double height = double.Parse (heightEditText.Text);
				double width = double.Parse (widthEditText.Text);
				AreaCalc calc = new AreaCalc();
				double result = calc.calcRectangleArea(height, width);
				if (null != this.Activity.FindViewById (Resource.Id.fragContainer2))	// if it's dual pane (landscape)
					((MainActivity)this.Activity).DisplayResult(result);
				else
					this.Activity.FindViewById<TextView>(Resource.Id.resultTextView).Text = result.ToString();
			};
			return view;

		}

	}
}

