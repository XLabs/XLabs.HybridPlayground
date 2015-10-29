using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace mynamespace
{
    public class pins : ContentPage
    {
        public HybridWebView hwv = new HybridWebView(new JsonSerializer()) { };
        
        public pins()
        { }

        public View loadPins(Guid currentProfile)
        {
            try
            {
                hwv.RemoveAllFunctions();
                hwv.RegisterNativeFunction("getPinGridValues", input =>
                {
                    return getPinGridValues(input);
                });

		// The file associated with this can be whatever - makes no difference
		//using the previous example from the playground

		hwv.LoadFromContent("www/Pingrid.html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.InnerException + " " + ex.StackTrace);
            }
        }

        public Func<string, object[]> getPinGridValues
        {
            get
            {
                return (data) =>
                {
                    return new object[] { new[] { 0, 6, 7, 8, 9, 4 } };
                };
            }
        }

        protected override void OnAppearing()
        {           
            Content = loadPins(Guid.NewGuid());
        }
    }
}
