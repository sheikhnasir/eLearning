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

namespace eLearning.MyCode
{
    [Activity(Label = "@string/title_mylogin", Theme = "@style/AppTheme", MainLauncher = true)]
    public class mylogin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
        
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_login);

            Button loginbtn = FindViewById<Button>(Resource.Id.btnLogin);
            Button clearbtn = FindViewById<Button>(Resource.Id.btnClear);
            EditText txtUser = FindViewById<EditText>(Resource.Id.txtUsername);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            // Create your application here
        }
    }
}