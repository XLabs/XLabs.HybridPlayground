using System;
using System.Collections.Generic;
using System.Text;

namespace XHybrid
{
    using Xamarin.Forms;
    using XLabs.Forms.Controls;
    using XLabs.Ioc;
    using XLabs.Serialization;

    public class HybridSample : ContentPage
    {
        private readonly HybridWebView hybrid;
        public HybridSample()
        {
            this.Content = this.hybrid = new HybridWebView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            this.hybrid.RegisterCallback("dataCallback", t =>
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.DisplayAlert("Data callback", t, "OK");
                })
            );

            //hwv.RegisterNativeFunction("funcCallback", s => new object[] {"Func return data for " + s});

            this.hybrid.RegisterCallback("sendObject", s =>
            {
                var serializer = Resolver.Resolve<IJsonSerializer>();

                var o = serializer.Deserialize<SendObject>(s);

                this.DisplayAlert("Object", string.Format("JavaScript sent x: {0}, y: {1}", o.X, o.Y), "OK");
            });

            this.hybrid.RegisterNativeFunction("funcCallback", t =>
            {
                return new[] { "From Func callback: " + t };
            });
        }

        #region Overrides of Page
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.hybrid.LoadFromContent("www/WebHybridTest.html");
        }

        #endregion
    }

    public class SendObject
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
