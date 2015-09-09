using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XHybrid
{
    using XLabs.Forms.Controls;
    using XLabs.Ioc;
    using XLabs.Serialization;
    using XLabs.Serialization.ServiceStack;

    public class App : Application
    {
        public App ()
        {
            SetIoc();
            // The root page of your application
			MainPage = new HybridWebViewTestPage();
        }

        protected override void OnStart ()
        {



        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }

        private void SetIoc()
        {
            if (Resolver.IsSet) return;

            var resolverContainer = new SimpleContainer();

            resolverContainer.Register<IJsonSerializer, JsonSerializer>();

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}
