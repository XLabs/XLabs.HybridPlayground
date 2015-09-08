using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace XHybrid.WinPhone
{
    using XLabs.Forms.Controls;

    public partial class MainPage
    {
        public MainPage()
        {
            var hybrid = new HybridWebViewRenderer();
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new XHybrid.App());
        }
    }
}
