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

namespace giveadogabone
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        public Core.GiveLogic logic = new Core.GiveLogic();
        protected override void OnCreate(Bundle bundle)
        {
            //logic.PopulateUsers();
            String user = Intent.GetStringExtra("name");

            User currentUser = logic.findUser(user);
            
            Toast.MakeText(this, currentUser.bones.ToString(), ToastLength.Long).Show();
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.loginpage);
            Button logout = FindViewById<Button>(Resource.Id.logout);
            Button givebone = FindViewById<Button>(Resource.Id.giveBone);
            TextView welcome = FindViewById<TextView>(Resource.Id.welcome);
            TextView bones = FindViewById<TextView>(Resource.Id.bone);

            if (currentUser.bones != 0)
                bones.Text = "YOU GOT A BONE!";
            welcome.Text = "Welcome" + " " + user;

            givebone.Click += delegate
              {
                  logic.givebone();
                  givebone.Text = "YOU GAVE A BONE!";
                  givebone.Enabled = false;
              };
            

            logout.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };
        }
        
    }
}