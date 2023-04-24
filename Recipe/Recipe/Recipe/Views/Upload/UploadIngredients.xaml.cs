using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Recipe.Models.Ingredients;
using System.Threading.Tasks;

using System.Text;
using Xamarin.CommunityToolkit.Extensions;

using Xamarin.Forms.Xaml;
using Firebase.Storage;
using System.IO;

namespace Recipe.Views.Upload
{
    public partial class UploadIngredients : Popup
    {
        private List<string> _selectedIngredients;
        private IngredientsHandler ingredientsHandler;
        private List<Ingredient> testIngredients;

        public UploadIngredients(List<string> selectedIngredients)
        {
            InitializeComponent();
            ingredientsHandler = new IngredientsHandler();
            _selectedIngredients = selectedIngredients;
            LoadIngredientsAsync();

        }

        private async Task LoadIngredientsAsync()
        {
           testIngredients = await ingredientsHandler.GetAllIngredients();
            AddDynamicIngredients(testIngredients);
        }


        private async void FilterIngredients(object sender, TextChangedEventArgs e)
        {
            // Get the search text from the SearchBar
            string searchText = e.NewTextValue;

            // Filter the ingredients based on the search text
            var filteredIngredients = testIngredients.Where(i => i.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

            // Call the AddDynamicIngredients method to update the UI with the filtered ingredients
            AddDynamicIngredients(filteredIngredients);
        }


        private void AddDynamicIngredients(List<Ingredient> ingredientsList)
        {
            IngredientsStack.Children.Clear();

            // Create a counter for adding ingredients to the correct position
            int count = 0;

            var temp_horizontal_stacklayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            // Loop through the list of ingredients and add them to the stack layout
            foreach (Ingredient ingredient in ingredientsList)
            {
                if (count % 3 == 0)
                {
                    temp_horizontal_stacklayout = new StackLayout { Orientation = StackOrientation.Horizontal };
                    IngredientsStack.Children.Add(temp_horizontal_stacklayout);
                }

                var mainFrame = new Frame
                {
                    Padding = new Thickness(0),
                    CornerRadius = 15,
                    HeightRequest = 110,
                    WidthRequest = 100,
                    Margin = new Thickness(5, 0, 0, 5),
                    HasShadow = true
                };

                var innerStack = new StackLayout();
                var grid = new Grid();

                // grid components
                var ingredientImage = new Image
                {
                    Source = ingredient.Image,
                    Aspect = Aspect.AspectFill
                };

                var innerFrame = new Frame
                {
                    Padding = new Thickness(0),
                    CornerRadius = 0,
                    HeightRequest = 100,
                    WidthRequest = 100
                };
                var overlay = new Frame
                {
                    Padding = new Thickness(0),
                    CornerRadius = 0,
                    Opacity = 0.4,
                    BackgroundColor = Color.Black,
                };
                var addImage = new Image
                {
                    Source = _selectedIngredients.Contains(ingredient.Name) ? "upload_remove" : "upload_add",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 45
                };

                var label = new Label
                {
                    Text = ingredient.Name,
                    TextColor = Color.Black,
                    FontSize = 14,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 5)
                };

                // Adding the components

                // Adding grid components
                grid.Children.Add(ingredientImage);
                grid.Children.Add(overlay);
                grid.Children.Add(addImage);

                // adding grid to inner frame
                innerFrame.Content = grid;

                // adding frame and label to inner stacklayout
                innerStack.Children.Add(innerFrame);
                innerStack.Children.Add(label);
                mainFrame.Content = innerStack;
                temp_horizontal_stacklayout.Children.Add(mainFrame);

                // Increment the count for the next ingredient
                count++;

                // Add the on-click method to the frame
                mainFrame.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        if (!_selectedIngredients.Contains(ingredient.Name))
                        {
                            _selectedIngredients.Add(ingredient.Name);
                            addImage.Source = "upload_remove";
                        }
                        else
                        {
                            _selectedIngredients.Remove(ingredient.Name);
                            addImage.Source = "upload_add";
                        }
                    })
                });
            }
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            Dismiss(_selectedIngredients);
        }
    }
  
}
