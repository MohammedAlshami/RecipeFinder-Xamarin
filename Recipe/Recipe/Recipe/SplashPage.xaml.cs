using Recipe.Views.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashPage : ContentPage
	{

        public SplashPage()
        {
            var splashImage = new Image
            {
                Source = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/Resources%2FLogo.png?alt=media",
                HeightRequest = 150,
                WidthRequest = 150,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children = { splashImage }
            };

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(3000);

            Application.Current.MainPage = new BottomNavigation();
        }
    }
}