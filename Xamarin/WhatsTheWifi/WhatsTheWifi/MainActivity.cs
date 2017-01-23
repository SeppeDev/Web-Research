using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using Android.Net.Wifi;
using Android.Print;
using static Android.Print.PrintDocumentAdapter;
using Android.Print.Pdf;
using Android.Webkit;

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
            //WebView webView = FindViewById<WebView>(Resource.Id.webView);

            Button backgroundButton = FindViewById<Button>(Resource.Id.Background);
            Android.Graphics.Bitmap image = CreateQRCode(qrView, name, password);


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
                image = CreateQRCode(qrView, name, password);

                qrView.SetImageBitmap(image);

                //webview.AddView(qrView);
            };


            //Print
            //var printMgr = (PrintManager)GetSystemService(Context.PrintService);
            //printMgr.Print("Print QRcode", qrView.CreatePrintDocumentAdapter(), null);


            //Change Lockscreen background
            backgroundButton.Click += (sender, e) =>
            {
                ChangeBackground(image);
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



        private Android.Graphics.Bitmap CreateQRCode(ImageView qrView, string name, string password)
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

            return barcode;
        }


        /*public override void OnLayout (PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras, string name)
        {
            document = new PrintedPdfDocument(context, newAttributes);

            CalculateScale (newAttributes);

            var printInfo = new PrintDocumentInfo
                .Builder(name + ".pdf")
                .SetContentType(PrintContentType.Document)
                .SetPageCount(1)
                .Build();

            callback.OnLayoutFinished(printInfo, true);
        }

        private override void OnWrite (PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
        {
            PrintedPdfDocument.Page page = PrintedPdfDocument.StartPage(0);

            page.Canvas.Scale(scale, scale);

            view.Draw(page.Canvas);

            document.FinishPage(page);

            WritePrintedPdfDoc(destination);

            document.Close();

            document.Dispose();

            callback.OnWriteFinished(pages);
        }*/

        private void ChangeBackground(Android.Graphics.Bitmap image)
        {
            WallpaperManager myWallpaperManager =
            WallpaperManager.GetInstance(Application.Context);

            myWallpaperManager.SetBitmap(image);
        }
    }
}

