using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using UIKit;
using Xamarin.Forms;

namespace SampleApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("81d4965b-d0a3-4321-b6dd-7035d4b40b08",
                   typeof(Analytics), typeof(Crashes));
            

                        global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            MessagingCenter.Subscribe<object>(this, MainPage.Crash, o =>
            {
                throw new Exception("来自Native层的Crash");
            });
            return base.FinishedLaunching(app, options);
        }
    }
}
