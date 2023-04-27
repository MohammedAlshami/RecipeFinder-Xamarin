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
        private List<string> _items = new List<string>
        {
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media",
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media",
            "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F08b07641-40ec-48fb-8e44-9e492af6da8a.mp4?alt=media"
        };
        private int _currentIndex = 0;
        private MediaElement _currentVideo;

        public ExplorePage()
        {
            InitializeComponent();
            Carousel.CurrentItemChanged += Carousel_CurrentItemChanged;
            _currentVideo = new MediaElement();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carousel.ItemsSource = _items;
        }

        private void Carousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            // Get the newly displayed MediaElement
            var newVideo = (e.CurrentItem as Grid)?.Children.FirstOrDefault(c => c is MediaElement) as MediaElement;

            if (newVideo != null)
            {
                // Pause the currently playing video
                _currentVideo.Pause();

                // Set the new video as the current video
                _currentVideo = newVideo;

                // Start playing the new video
                _currentVideo.Play();
            }
        }

        private void Carousel_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.VerticalDelta > 0)
            {
                // Increment the current index and wrap around if necessary
                _currentIndex = (_currentIndex + 1) % _items.Count;

                // Set the position of the carousel view to the current index
                Carousel.Position = _currentIndex;
                Console.WriteLine("User swiped up");
            }
            else if (e.VerticalDelta < 0)
            {
                Console.WriteLine("User swiped down");
            }
        }
    }
}
