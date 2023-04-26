using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.UI.Views;
namespace Recipe.Views.Explore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorePage : ContentPage
    {
        public ExplorePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carousel.ItemsSource = new List<string>
        {
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media",
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media",
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media"
        };
        }
    }
}
