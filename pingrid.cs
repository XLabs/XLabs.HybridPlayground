using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace XHybrid
{
    public class Pingrid : ContentPage
    {
        HybridWebView hwv;

        StackLayout htmlStack;

        public Pingrid()
        {
            Content = loadPinGrid();
        }

        public View loadPinGrid()
        {
            
            hwv = new HybridWebView(new JsonSerializer()) { };

#if __ANDROID__
            NavigationPage.SetHasNavigationBar(this, false);
#endif
            try
            {
                //removal of functions so no errors on the onappearing happening more than once
                hwv.RemoveAllFunctions();

                //register the pingrid generation function
                hwv.RegisterNativeFunction("getPinGridValues", input =>
                {
                    return getPinGridValues(input);
                });

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.InnerException + " " + ex.StackTrace);
            }

            hwv.VerticalOptions = LayoutOptions.FillAndExpand;
            hwv.HorizontalOptions = LayoutOptions.FillAndExpand;

            Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            htmlStack = new StackLayout()
            {
                Children =
                {
                    hwv
                },
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = htmlStack;
            return Content;
        }

        public Func<string, object[]> getPinGridValues
        {
            get
            {
                return (data) =>
                {
                    return new object[] { 1,2,3,4,5,6 };
                };
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            hwv.LoadFromContent("PinGrid.html");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Content = null;
        }
    }
}
