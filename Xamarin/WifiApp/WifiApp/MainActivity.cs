using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Net.Wifi;

namespace WifiApp
{
    [Activity(Label = "WifiApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //My code
            Button enableButton = FindViewById<Button>(Resource.Id.enableButton);
            Button disableButton = FindViewById<Button>(Resource.Id.disableButton);

            enableButton.Click += (object sender, EventArgs e) =>
            {
                var wifiManager = Application.Context.GetSystemService(Context.WifiService) as WifiManager;

                if (wifiManager != null)
                {
                    wifiManager.SetWifiEnabled(true);
                }
            };

            disableButton.Click += (object sender, EventArgs e) =>
            {
                var wifiManager = Application.Context.GetSystemService(Context.WifiService) as WifiManager;

                if (wifiManager != null)
                {
                    wifiManager.SetWifiEnabled(false);
                }
            };
        }
    }
}

