using Recipe.Models.Ingredients;
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
	public partial class IngredientsAddPage : ContentPage
	{
        IngredientsHandler ingredientsHandler;
        List<Ingredient> allIngredients;
        StackLayout currentSubStack;
        List<string> addedIngredients = new List<string>();
        public IngredientsAddPage ()
        {
            InitializeComponent ();

            ingredientsHandler = new IngredientsHandler();
            LoadAllIngredients();
        }

        public async void OnAddIngredientButtonClicked(object sender, EventArgs e)
        {
            string message = "";
            foreach (string ingredientName in addedIngredients)
            {
                message += ingredientName + "\n";
            }

            await DisplayAlert("Added Ingredients", message, "OK");
        }

        private async void LoadAllIngredients()
        {
            allIngredients = await ingredientsHandler.GetAllIngredients();
            currentSubStack = null;

            // Set up the search functionality
            SearchBar.TextChanged += (sender, e) =>
            {
                var filteredIngredients = allIngredients.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
                LoadIngredients(filteredIngredients);
            };

            LoadIngredients(allIngredients);
        }
        private async void LoadIngredients(List<Ingredient> ingredients)
        {
            IngredientsStackLayout.Children.Clear();

            foreach (var ingredient in ingredients)
            {
                if (currentSubStack == null || currentSubStack.Children.Count >= 2)
                {
                    // Create a new horizontal stack layout when the previous one has 2 ingredients
                    currentSubStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Spacing = 20,
                        Margin = new Thickness(20, 10, 20, 0),
                        HorizontalOptions = LayoutOptions.CenterAndExpand

                    };
                    IngredientsStackLayout.Children.Add(currentSubStack);
                }

                // Create an image with a black overlay and a button wrapped in a frame
                // Create a new grid
                var grid = new Grid
                {
                    RowDefinitions = new RowDefinitionCollection
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, // Image row
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }  // Label row
                    }
                };
                var image = new Frame
                {
                    CornerRadius = 10,
                    HasShadow = false,
                    Padding = new Thickness(0),
                    Content = new Image
                    {
                        Source = ingredient.Image,
                        Aspect = Aspect.AspectFill,
                        HeightRequest = 100,
                        WidthRequest = 140
                    }
                };



                var nameLabel = new Label
                {
                    Text = ingredient.Name,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    Margin = new Thickness(0, 5, 0, 0),
                    TextColor = Color.Black,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                var button = new Button
                {
                    Text = "Add",
                    BackgroundColor = Color.Transparent,
                    TextColor = Color.Black,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
                };
                button.Clicked += (sender, args) =>
                {
                    if (button.Text == "Add")
                    {
                        // Add the ingredient to the list
                        addedIngredients.Add(nameLabel.Text);
                        button.Text = "Remove";
                    }
                    else
                    {
                        // Remove the ingredient from the listx
                        addedIngredients.Remove(nameLabel.Text);
                        button.Text = "Add";
                    }
                };


                Grid.SetRowSpan(button, 2);
                grid.Children.Add(image, 0, 0);
                grid.Children.Add(button, 0, 0);




                var frame = new Frame
                {
                    CornerRadius = 10,
                    HasShadow = true,
                    Padding = new Thickness(0),
                    Margin = new Thickness(5, 0, 5, 0),
                    BackgroundColor = Color.White,
                    Content = new StackLayout
                    {
                        Children = { grid, nameLabel, button },
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    }
                };

                // Add the frame to the horizontal stack layout

                currentSubStack.Children.Add(frame);
            }
        }
    }

}