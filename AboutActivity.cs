
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

namespace simpleMath
{
    [Activity(Label = "AboutActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class AboutActivity : Activity
    {
        private Button btnHome;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AboutLayout);
            // Assign variables to the layout resources
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            //Event triggered when Home button is clicked
            //Home screen will be displayed
            btnHome.Click += delegate {
                var newActivity = new Intent(this, typeof(MainActivity));
                StartActivity(newActivity);
            };
        }
    }
}
