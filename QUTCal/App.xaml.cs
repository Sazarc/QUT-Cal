using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QUTCal
{
    public partial class App : Application
    {
        public App()
        {
            // Register SyncFusion.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTQ3ODA2QDMxMzcyZTMyMmUzMEk2YTcrRHBHZDZaYW9iWk81ZWU3UE1FbmRqMHBydWtBWVloNUtvWVRHeDQ9");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#003B62"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
