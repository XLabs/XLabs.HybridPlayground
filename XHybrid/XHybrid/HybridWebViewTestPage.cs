using System;

using Xamarin.Forms;

namespace XHybrid
{
	public class HybridWebViewTestPage : ContentPage
	{
		public HybridWebView hwv = new HybridWebView(new XLabs.Serialization.JsonNET.JsonSerializer()) { };

		public HybridWebViewTestPage()
		{
			var assembly = typeof(WebViewTestPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("XHybrid.PinGrid.html");
			string text = "";
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

			hwv.VerticalOptions = LayoutOptions.FillAndExpand;
			hwv.HorizontalOptions = LayoutOptions.FillAndExpand;
			hwv.Source = new HtmlWebViewSource
			{
				Html = text
			};

			StackLayout htmlStack = new StackLayout()
			{
				Children =
				{
					hwv
				}
				};

			hwv.RegisterNativeFunction("getPinGridValues", (input) => {
				return getPinGridValues(input);
			});

			Content = htmlStack;
		}

		public Func<string, object[]> getPinGridValues
		{
			//All the crypto work can be called here 
			get {
				return (data) => {
					int[] numberArray = new int[] { 0, 6, 7, 8, 9, 4 };
					return new object[] { numberArray };
				};
			}
		}
	}
}


