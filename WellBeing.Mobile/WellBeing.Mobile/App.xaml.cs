using System;
using WellBeing.Mobile.Services;
using WellBeing.Mobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WellBeing.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
