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
        string searchquery;

        public RecipeSearch(string searchQuery)
        {
            InitializeComponent();
            recipeHandler = new RecipeHandler();
            this.searchquery = searchQuery;
            displayRecipesAsync();
            Console.WriteLine(searchQuery);

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }

        private async Task displayRecipesAsync()
        {
            RecipeList.Children.Clear();
            List<Recipes> allRecipes = await recipeHandler.GetRecipes(searchquery); // Call the GetRecipes function to get the filtered recipes

            // Display recipe names and images
            if (allRecipes != null && allRecipes.Count > 0)
            {
                // Create a horizontal stack layout to hold the recipe frames
                var rowStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 0),
                    Spacing = 20
                };

                foreach (var recipe in allRecipes)
                {
                    // Create a frame to hold the recipe details
                    var frame = new Frame
                    {
                        CornerRadius = 15,
                        HasShadow = true,
                        HeightRequest = 200,
                        WidthRequest = 150,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Padding = 0
                    };
                    // Add a tap gesture recognizer to the frame
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, eArgs) => MyFunctionAsync(recipe);

                    frame.GestureRecognizers.Add(tapGestureRecognizer);


                    // Create a grid layout to hold the recipe image and name
                    var gridLayout = new Grid
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 0
                    };

                    // Create an image view for the recipe image
                    var recipeImage = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(recipe.Image)), // Set the image source based on your recipe model
                        Aspect = Aspect.AspectFill
                    };

                    // Create a label for the recipe name
                    var recipeName = new Label
                    {
                        Text = recipe.Name,
                        FontSize = 15,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        LineBreakMode = LineBreakMode.WordWrap,
                        TextColor = Color.Black,
                        Padding = new Thickness(0, 5, 0, 0)
                    };

                    // Add the image view and label to the grid layout
                    gridLayout.Children.Add(recipeImage, 0, 0);
                    gridLayout.Children.Add(recipeName, 0, 1);

                    // Set the grid layout as the content of the frame
                    frame.Content = gridLayout;

                    // Add the frame to the row stack layout
                    rowStackLayout.Children.Add(frame);

                    // If two frames have been added to the row stack layout, create a new row
                    if (rowStackLayout.Children.Count == 2)
                    {
                        RecipeList.Children.Add(rowStackLayout);
                        rowStackLayout = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = new Thickness(20, 0, 20, 10),
                            Spacing = 20
                        };
                    }
                }

                // Add any remaining frames to the last row
                if (rowStackLayout.Children.Count > 0)
                {
                    RecipeList.Children.Add(rowStackLayout);
                }
            }
            else
            {
                var noResultsLabel = new Label { Text = "No recipes found", FontSize = 18, HorizontalOptions = LayoutOptions.CenterAndExpand };
                RecipeList.Children.Add(noResultsLabel);
            }
        }
        private async Task MyFunctionAsync(Recipes recipe)
        {
            // Code to handle the frame click event
            await Device.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new RecipePage(recipe));
            });
        }


    }
}
