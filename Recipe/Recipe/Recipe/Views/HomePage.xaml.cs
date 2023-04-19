using Recipe.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        RecipeHandler recipehandler;
        public HomePage()
        {
            InitializeComponent();
            recipehandler = new RecipeHandler();

       
       

                
        }

        private void ChangeFrameHeight(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = true;
            HomeSearchOption.IsVisible = true;
            homeSearchFrame.WidthRequest = 290;
            homeSearchFrame.Margin = new Thickness(0, 25, 25, 10);
            HomeComponents.IsVisible = false;

        }

        private void backBtn(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = false;
            HomeSearchOption.IsVisible = false;
            homeSearchFrame.WidthRequest = 340;
            homeSearchFrame.Margin = new Thickness(25, 25, 25, 10);
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





    }
}
