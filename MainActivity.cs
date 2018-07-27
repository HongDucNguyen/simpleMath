using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace simpleMath
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Button btnAddition, btnSubstraction, btnMultiplication, btnDivision,btnAbout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get the buttons from the layout resource,
            btnAddition = FindViewById<Button>(Resource.Id.btnAdd);
            btnSubstraction = FindViewById<Button>(Resource.Id.btnSub);
            btnMultiplication = FindViewById<Button>(Resource.Id.btnMulti);
            btnDivision = FindViewById<Button>(Resource.Id.btnDiv);
            btnAbout = FindViewById<Button>(Resource.Id.btnAbt);
            //Assign event to the buttons
            btnAddition.Click += OnButtonClicked;
            btnSubstraction.Click += OnButtonClicked;
            btnMultiplication.Click += OnButtonClicked;
            btnDivision.Click += OnButtonClicked;
            btnAbout.Click += OnButtonClicked;
        }

        //Function to implement when a button is clicked
        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //If the button Addition is clicked, Addition activity will be opened
            if(button == btnAddition){
                var newActivity = new Intent(this, typeof(AdditionActivity));
                StartActivity(newActivity);
            }

        }

    }
}

