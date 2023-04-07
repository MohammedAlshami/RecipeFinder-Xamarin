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
    public partial class RecipeSearch : ContentPage
    {
        private RecipeHandler recipeHandler;
        public RecipeSearch()
        {
            InitializeComponent();
            recipeHandler = new RecipeHandler();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
            RecipeList.Children.Clear();
            string searchText = SearchBar.Text.ToLower();
            List<Recipes> allRecipes = await recipeHandler.GetRecipes(searchText);

            // Display recipe names
            if (allRecipes != null && allRecipes.Count > 0)
            {
                foreach (var recipe in allRecipes)
                {
                    // Create a frame to hold the recipe details
                    var frame = new Frame
                    {
                        WidthRequest = 100,
                        HeightRequest = 100,
                        CornerRadius = 15,
                        HasShadow = true,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    };

                    // Create a stack layout to hold the recipe image and name
                    var stackLayout = new StackLayout
                    {
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    };

                    // Create an image view for the recipe image
                    var recipeImage = new Image
                    {
                        Source = recipe.Image, // Set the image source based on your recipe model
                        WidthRequest = 50,
                        HeightRequest = 50
                    };

                    // Create a label for the recipe name
                    var recipeName = new Label
                    {
                        Text = recipe.Name,
                        FontSize = 18,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center,
                    };

                    // Add the image view and label to the stack layout
                    stackLayout.Children.Add(recipeImage);
                    stackLayout.Children.Add(recipeName);

                    // Set the stack layout as the content of the frame
                    frame.Content = stackLayout;

                    // Add the frame to the recipe list
                    RecipeList.Children.Add(frame);
                }
            }
            else
            {
                var noResultsLabel = new Label { Text = "No recipes found", FontSize = 18, HorizontalOptions = LayoutOptions.CenterAndExpand };
                RecipeList.Children.Add(noResultsLabel);
            }
        }
    }
}
