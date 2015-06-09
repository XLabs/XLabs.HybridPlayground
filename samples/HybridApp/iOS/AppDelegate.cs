using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Serialization.ServiceStack;
using XLabs.Forms.Controls;
using XLabs.Platform.Device;

namespace HybridApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var web = new HybridWebViewRenderer();

            var container = new SimpleContainer();

            container.Register<IJsonSerializer, JsonSerializer>();
            container.Register<IDevice>(AppleDevice.CurrentDevice);

            Resolver.SetResolver(container.GetResolver());

            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
            #if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
            #endif

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

