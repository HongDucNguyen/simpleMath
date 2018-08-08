
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
    [Activity(Label = "MultiplicationActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class MultiplicationActivity : Activity
    {
        private Button btnHome, btnNext, btnDone;
        private TextView txtQuestion, txtJudgement;
        private EditText txtAnswer;
        private int x, y;
        private bool btnNextEnable = false, btnDoneEnable = true;// boolean to enable button next and button done
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "Calculation" layout resource
            SetContentView(Resource.Layout.CalculationLayout);
            // Assign variables to the layout resources
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);
            btnDone = FindViewById<Button>(Resource.Id.btnDone);

            txtQuestion = FindViewById<TextView>(Resource.Id.txtQuestion);
            txtJudgement = FindViewById<TextView>(Resource.Id.txtJudgement);
            txtAnswer = FindViewById<EditText>(Resource.Id.txtAnswer);
            //If app state changes, retrieve saved information
            //If app state doesn't change, start new screen with new value.
            if (savedInstanceState != null)
            {
                x = savedInstanceState.GetInt("x value", 0);
                y = savedInstanceState.GetInt("y value", 0);
                txtAnswer.Text = savedInstanceState.GetString("answer", "");
                txtJudgement.Text = savedInstanceState.GetString("judgement", "");
                if (txtJudgement.Text == "Please answer!")
                {
                    txtJudgement.SetTextColor(Android.Graphics.Color.Black);
                }
                else if (txtJudgement.Text == "Correct!!!")
                {
                    txtJudgement.SetTextColor(Android.Graphics.Color.DarkGreen);
                }
                else if (txtJudgement.Text == "Incorrect!!!")
                {
                    txtJudgement.SetTextColor(Android.Graphics.Color.Red);
                }
                txtQuestion.Text = x.ToString() + " x " + y.ToString() + " = ?";
                btnNextEnable = savedInstanceState.GetBoolean("nextEnable", false);
                btnDoneEnable = savedInstanceState.GetBoolean("doneEnable", true);
                CheckEnable();
            }
            else
            {
                GetQuestion();
                CheckEnable();
            }
            //Event is triggered when Done button is clicked.
            //Answer value will be checked and judgement will be displayed accordingly
            //If no answer, remind text will appear.
            //If answer is correct, correct text will appear
            //If answer is incorrect, incorrect text will appear
            btnDone.Click += delegate {
                if (txtAnswer.Text == "")
                {
                    txtJudgement.Text = "Please answer!";
                    txtJudgement.SetTextColor(Android.Graphics.Color.Black);
                }
                else
                {
                    int tmp = Int32.Parse(txtAnswer.Text);
                    if (tmp == x * y)
                    {
                        txtJudgement.Text = "Correct!!!";
                        txtJudgement.SetTextColor(Android.Graphics.Color.DarkGreen);
                    }
                    else
                    {
                        txtJudgement.Text = "Incorrect!!!";
                        txtJudgement.SetTextColor(Android.Graphics.Color.Red);
                    }
                    btnDoneEnable = false;
                    btnNextEnable = true;
                }
                CheckEnable();
            };
            //Event is triggered when Next button is clicked
            //Next question will appear.
            btnNext.Click += delegate {
                GetQuestion();
                txtJudgement.Text = "";
                txtAnswer.Text = "";
                btnDoneEnable = true;
                btnNextEnable = false;
                CheckEnable();
            };
            //Event triggered when Home button is clicked
            //Home screen will be displayed
            btnHome.Click += delegate {
                var newActivity = new Intent(this, typeof(MainActivity));
                StartActivity(newActivity);
            };
        }
        //Function generate question which will be displayed on screen
        private void GetQuestion()
        {
            Random randomNumber = new Random();
            x = randomNumber.Next(1, 12);
            y = randomNumber.Next(1, 12);
            txtQuestion.Text = x.ToString() + " x " + y.ToString() + " = ?";
        }
        //Save data when app state changes 
        protected override void OnSaveInstanceState(Bundle savedState)
        {
            base.OnSaveInstanceState(savedState);
            savedState.PutInt("x value", x);
            savedState.PutInt("y value", y);
            savedState.PutString("judgement", txtJudgement.Text);
            savedState.PutString("answer", txtAnswer.Text);
            savedState.PutBoolean("nextEnable", btnNextEnable);
            savedState.PutBoolean("doneEnable", btnDoneEnable);
        }
        //Function to check button Next and Done is enable or not
        //If enable, button will be visible
        //If not, button will be invisible
        private void CheckEnable()
        {
            if (btnNextEnable)
            {
                btnNext.Visibility = ViewStates.Visible;
            }
            else
            {
                btnNext.Visibility = ViewStates.Invisible;
            }
            if (btnDoneEnable)
            {
                btnDone.Visibility = ViewStates.Visible;
            }
            else
            {
                btnDone.Visibility = ViewStates.Invisible;
            }
        }
    }
}
