using Recipe.Models;
using Recipe.Models.Recipes;
using Recipe.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        RecipeHandler recipehandler;
        private int currentIndex = 0;
        private List<string> images = new List<string>
    {
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-1-800x800.png?alt=media&token=3e4b40ee-9521-4480-83f6-047da6bffa84",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-2-800x800.png?alt=media&token=8992b558-2649-41d5-89e1-cd6ecefaca36",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-3-800x800.png?alt=media&token=1cd416a9-8a7c-4c95-b07a-1cc54d2f8f9c",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-4-800x800.png?alt=media&token=73dd18a6-4e75-47f2-9607-ca52b1211e70",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-5-800x800.png?alt=media&token=61141606-5caa-46a5-b7e1-73b32ac3975d",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-6-800x800.png?alt=media&token=2337171e-8a33-4d82-a068-c895daa33983",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-7-800x800.png?alt=media&token=6dfb8e3d-f941-4ce3-8ade-7c4382759448",
        "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DisplayImages%2FFood-Facts-Feature.png?alt=media&token=4136ca48-4de6-4211-a999-9e42269ca652"

    };
        public HomePage()
        {
            InitializeComponent();
            recipehandler = new RecipeHandler();

       
       

                
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carousel.ItemsSource = images;
            Device.StartTimer(TimeSpan.FromSeconds(6), () =>
            {
                // Increment the current index and wrap around if necessary
                currentIndex = (currentIndex + 1) % images.Count;

                // Set the position of the carousel view to the current index
                Carousel.Position = currentIndex;

                return true;
            });
        }

        private void ChangeFrameHeight(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = true;
            Aboutmea.IsVisible = false;
            HomeSearchOption.IsVisible = true;
            homeSearchFrame.WidthRequest = 290;
            homeSearchFrame.Margin = new Thickness(0, 25, 25, 10);
            HomeComponents.IsVisible = false;

        }

        private void backBtn(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = false;
            Aboutmea.IsVisible = true;

            HomeSearchOption.IsVisible = false;
            homeSearchFrame.WidthRequest = 280;
            homeSearchFrame.Margin = new Thickness(10, 20, 60, 0);
            HomeComponents.IsVisible = true;

        }
        private async void SearchRecipes(object sender, TextChangedEventArgs args)
        {
            HomeSearchOption.IsVisible = false;

            var searchQuery = HomeSearchBar.Text;
            searchStack.Children.Clear();
            Console.WriteLine($"Text Searched: {searchQuery}");

            List<Recipes> filteredRecipes = await recipehandler.GetRecipes(searchQuery); // Call the GetRecipes function to get the filtered recipes
            if (filteredRecipes != null && filteredRecipes.Count > 0)
            {
                searchStack.Children.Clear();
                // Add filtered recipes to the stack as UI elements
                foreach (var recipe in filteredRecipes)
                {
                    Frame frame = new Frame
                    {
                        HeightRequest = 25,
                        Margin = new Thickness(40, 0, 40, 0),
                        HasShadow = true,
                        CornerRadius = 10
                    };

                    Label nameLabel = new Label { Text = recipe.Name, FontSize = 18 };

                    frame.Content = nameLabel; // Set the label as content of the frame

                    ContentView contentView = new ContentView
                    {
                        Content = frame
                    };

                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, eArgs) => MyFunctionAsync(searchQuery);
                    contentView.GestureRecognizers.Add(tapGestureRecognizer);

                    searchStack.Children.Add(contentView); // Add the content view to the main recipe stack
                }
            }
            else
            {
                Console.WriteLine("No recipes found.");
            }
        }

        private async Task MyFunctionAsync(string recipe)
        {
            // Code to handle the frame click event
            await Device.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new RecipeSearch(recipe));
            });
        }
        private async void OnStackLayoutTapped(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string parameter = button.CommandParameter as string;
            Console.WriteLine($"HomeError: {parameter}");
            var recipe = await recipehandler.GetRecipeByName(parameter);
            await Device.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new RecipePage(recipe));
            });
        }
        private async void OnSearchOption(object sender, EventArgs e)
        {
            Frame lblClicked = (Frame)sender;
            var item = (TapGestureRecognizer)lblClicked.GestureRecognizers[0];
            var id = item.CommandParameter as string;
            await MyFunctionAsync(id);
            /*string labelText = (Frame.BindingContext as string) ?? string.Empty;*/
        }
        private async void OnSearchOptioncus(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string parameter = button.CommandParameter as string;
            await MyFunctionAsync(parameter);
            /*string labelText = (Frame.BindingContext as string) ?? string.Empty;*/
        }

        async void something(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new Me());
          
        }






    }
}
