using Recipe.Views;
using Recipe.Views.Navigation;
using Recipe.Views.Authentication;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Recipe.Views.Upload;

namespace Recipe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new UploadPlayground();//Very important add this..

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
