using System;

using Xamarin.Forms;

namespace XHybrid
{
    using System.IO;
    using System.Reflection;
    using XLabs.Forms.Controls;

    public class HybridWebViewTestPage : ContentPage
	{
		private readonly HybridWebView hwv = new HybridWebView();

		public HybridWebViewTestPage()
		{
			hwv.VerticalOptions = LayoutOptions.FillAndExpand;
			hwv.HorizontalOptions = LayoutOptions.FillAndExpand;

            

			StackLayout htmlStack = new StackLayout
			{
				Children =
				{
					hwv
				}
			};

			hwv.RegisterNativeFunction("getPinGridValues", input => 
                new object[]{ new[] { 0, 6, 7, 8, 9, 4 } });

			Content = htmlStack;
		}

        #region Overrides of Page

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page"/> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            hwv.LoadFromContent("www/PinGrid.html");
        }

        #endregion
	}
}


