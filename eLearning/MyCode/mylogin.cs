using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Org.Apache.Http.Client;

namespace eLearning.MyCode
{
    [Activity(Label = "@string/title_mylogin", Theme = "@style/AppTheme", MainLauncher = true)]
    public class mylogin : Activity
    {
        [Obsolete]
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

            loginbtn.Click += async delegate
             {
                 String Baseurl = "http://projectvsc.azurewebsites.net/api/values/" + txtUser + "/" + txtPassword;
                 UserInfo userInfo = new UserInfo(txtUser.ToString());
                 using (var client = new HttpClient())
                 {
                     client.BaseAddress = new Uri(Baseurl);

                     client.DefaultRequestHeaders.Clear();
                     //Define request data format  
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                     //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                     HttpResponseMessage Res = await client.GetAsync("api/Employee/GetAllEmployees");

                     //Checking the response is successful or not which is sent using HttpClient  
                     if (Res.IsSuccessStatusCode)
                     {
                         //Storing the response details recieved from web api   
                         var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                         //Deserializing the response recieved from web api and storing into the Employee list  
                         userInfo = JsonConvert.DeserializeObject<UserInfo>(EmpResponse);

                     }
                     //returning the employee list to view  
                    // return View(userInfo);
                 }



                 Intent successLogin = new Intent(this, typeof(MainActivity));
                 StartActivity(typeof(MainActivity));
                 StartActivity(successLogin);
             };
        }
    }
}