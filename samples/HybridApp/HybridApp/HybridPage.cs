using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Platform.Device;

namespace HybridApp
{
    public class HybridPage : ContentPage
    {
        private readonly HybridWebView hybrid;

        public HybridPage()
        {
            var jsonSerializer = Resolver.Resolve<IJsonSerializer>();
            this.hybrid = new HybridWebView(jsonSerializer)
            {
                BackgroundColor = Color.Blue
            };

            var buttonHeight = Device.OnPlatform(100, 100, 100);

            var layout = new RelativeLayout();

            layout.Children.Add(this.hybrid,
                Constraint.Constant(0),
                Constraint.Constant(20),
                Constraint.RelativeToParent(p => p.Width),
                Constraint.RelativeToParent(p => p.Height - buttonHeight));

            this.Content = layout;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.hybrid.LoadFinished += OnLoadFinished;
            this.hybrid.LoadFromContent("WWW/hybrid.html");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.hybrid.LoadFinished -= OnLoadFinished;
        }

        private void OnLoadFinished(object sender, EventArgs args)
        {
            var os = Device.OnPlatform("iOS", "Droid", "Windows Phone");

            var device = Resolver.Resolve<IDevice>();

            this.hybrid.InjectJavaScript(
                string.Format("document.getElementById(\"os\").innerHTML = \"{0}\";", os));

            this.hybrid.CallJsFunction("myFunction", new { DeviceId = device.Id, Manufacturer = device.Manufacturer });
        }
    }
}

