using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using Android.Net.Wifi;

namespace WhatsTheWifi
{
    [Activity(Label = "WhatsTheWifi", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        WifiManager wifiManager = Application.Context.GetSystemService(Context.WifiService) as WifiManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            Button createButton = FindViewById<Button>(Resource.Id.Create);
            string name = FindViewById<EditText>(Resource.Id.Name).Text;
            string password = FindViewById<EditText>(Resource.Id.Password).Text;
            ImageView qrView = FindViewById<ImageView>(Resource.Id.QrView);


            MobileBarcodeScanner.Initialize(Application);

            EnableWifi();


            button.Click += async(sender, e) =>
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();

                if (result != null)
                {
                    string[] info = SeperateIdAndPassword(result.Text);

                    string SSID = info[0];
                    string Password = info[1];


                    AddWifiNetwork(SSID, Password);
                }
            };



            //Show
            createButton.Click += (sender, e) =>
            {
                CreateQRCode(qrView, name, password);
            };
        }

        private void EnableWifi()
        {

            if (!wifiManager.IsWifiEnabled)
            {
                wifiManager.SetWifiEnabled(true);
            }
        }

        private void AddWifiNetwork(string name, string password)
        {
            var networkSSID = name;
            var networkPass = password;
            var config = new WifiConfiguration();

            config.Ssid = '"' + networkSSID + '"';
            config.PreSharedKey = '"' + networkPass + '"';

            wifiManager.AddNetwork(config);
        }

        private string[] SeperateIdAndPassword(string concatenated)
        {
            char[] delimiterChars = { '/' };
            string[] answers = concatenated.Split(delimiterChars);

            return answers;
        }



        private void CreateQRCode(ImageView qrView, string name, string password)
        {
            var barcodeWriter = new ZXing.Mobile.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 600,
                    Height = 600
                }
            };
            var barcode = barcodeWriter.Write( name + "/" + password );

            qrView.SetImageBitmap(barcode);
        }
    }
}

