using Recipe.Views;
using Recipe.Views.Navigation;
using Recipe.Views.Authentication;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Recipe.Views.Upload;
using Recipe.Views.Navigation;
using Xamarin.Forms.PlatformConfiguration;

namespace Recipe
{
    public partial class App : Application
    {
        public string UserEmail { get; set; }
        public App()
        {
            InitializeComponent();
            UserEmail = null;

            MainPage = new SplashPage();

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
