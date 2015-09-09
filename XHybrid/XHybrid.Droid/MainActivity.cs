using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XHybrid.Droid
{
    [Activity(Label = "XHybrid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            XLabs.Forms.Controls.HybridWebViewRenderer.GetWebViewClientDelegate = r => new CustomClient(r);
            XLabs.Forms.Controls.HybridWebViewRenderer.GetWebChromeClientDelegate = r => new CustomChromeClient();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new XHybrid.App());
        }
    }
}

