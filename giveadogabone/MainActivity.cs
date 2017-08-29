using Android.App;
using Android.Widget;
using Android.OS;
using giveadogabone;
using System;
using Android.Content;

namespace giveadogabone
{
    [Activity(Label = "GIVEADOGABONE", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity 
    {
        public Core.GiveLogic logic = new Core.GiveLogic();
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

           
            SetContentView (Resource.Layout.Main);
            EditText name = FindViewById<EditText>(Resource.Id.UserInput);
            EditText pass = FindViewById<EditText>(Resource.Id.Pass);
            Button login = FindViewById<Button>(Resource.Id.LoginButton);


            ActionBar.Hide();
            logic.PopulateUsers();
            login.Click += delegate
              {


                  if (logic.Login(name.Text, pass.Text) == true)
                  {
                      var intent = new Intent(this, typeof(LoginActivity));
                      intent.PutExtra("name",name.Text);
                      StartActivity(intent);
                  }
                      
                  else
                      Toast.MakeText(this, "WRONG USERNAME/PASSWORD", ToastLength.Long).Show();
              };

        }
    }
}

