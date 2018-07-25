
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
    [Activity(Label = "AdditionActivity", Theme = "@style/AppTheme.NoActionBar")]

    public class AdditionActivity : Activity
    {
        Button btnHome, btnNext, btnDone;
        TextView txtQuestion;
        EditText txtAnswer;
        int x, y, z;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Addition);
            // Assign variables to the layout resources
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);
            btnDone = FindViewById<Button>(Resource.Id.btnDone);

            txtQuestion = FindViewById<TextView>(Resource.Id.txtQuestionAddition);
            txtAnswer = FindViewById<EditText>(Resource.Id.txtAnswerAddition);
            Random randomNumber = new Random();
            x = randomNumber.Next(0, 99);
            y = randomNumber.Next(0, 99);
            txtQuestion.Text = x.ToString() + " + " + y.ToString() + " = ?";

            btnNext.Click += delegate {
                
                x = randomNumber.Next(0, 99);
                y = randomNumber.Next(0, 99);
                txtQuestion.Text = x.ToString() + " + " + y.ToString() + " = ?";
            };
        }
    }
}
