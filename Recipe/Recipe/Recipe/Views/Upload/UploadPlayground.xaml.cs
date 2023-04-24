using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Recipe.Views.Upload
{
    public partial class UploadPlayground : ContentPage
    {
        private List<string> _selectedIngredients = new List<string>();

        public UploadPlayground()
        {
            InitializeComponent();

            // Call this method to add dynamic ingredients
            AddDynamicIngredients();
        }

        private void AddDynamicIngredients()
        {
            // Sample list of ingredients
            string[] ingredientsList = { "Carrot", "Onion", "Potato", "Garlic", "Ginger", "Tomato", "Lemon", "Cucumber", "Eggplant", "Pepper", "Spinach" };

            // Create a counter for adding ingredients to the correct position
            int count = 0;

            // Loop through the list of ingredients and add them to the stack layout
            foreach (string ingredient in ingredientsList)
            {
                // Create the UI elements for each ingredient
                var frame = new Frame { Padding = 0, CornerRadius = 15, HeightRequest = 110, WidthRequest = 100 };
                var stackLayout = new StackLayout();
                var imageFrame = new Frame { Padding = 0, CornerRadius = 0, HeightRequest = 100, WidthRequest = 100 };
                var grid = new Grid();
                var image = new Image { Source = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/Resources%2Fupload%2Fingredients.jpg?alt=media", Aspect = Aspect.AspectFill };
                var backgroundFrame = new Frame { BackgroundColor = Color.Black, Opacity = 0.4, Padding = 0 };
                var addImage = new Image { Source = "upload_add", VerticalOptions = LayoutOptions.CenterAndExpand, WidthRequest = 45 };
                var label = new Label { Text = ingredient, TextColor = Color.Black, FontSize = 14, HorizontalTextAlignment = TextAlignment.Center, Margin = new Thickness(0, 0, 0, 5) };

                // Add the UI elements to the correct parent containers
                backgroundFrame.Content = grid;
                grid.Children.Add(image);
                grid.Children.Add(backgroundFrame);
                grid.Children.Add(addImage);
                imageFrame.Content = grid;
                stackLayout.Children.Add(imageFrame);
                stackLayout.Children.Add(label);
                frame.Content = stackLayout;

                // Add the frame to the correct position based on the count
                if (count % 3 == 0)
                {
                    var row = new StackLayout { Orientation = StackOrientation.Horizontal };
                    row.Children.Add(frame);
                    IngredientsStack.Children.Add(row);
                }
                else
                {
                    var row = (StackLayout)IngredientsStack.Children.Last();
                    row.Children.Add(frame);
                }

                // Increment the count for the next ingredient
                count++;

                // Add the on-click method to the frame
                frame.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        if (!_selectedIngredients.Contains(ingredient))
                        {
                            _selectedIngredients.Add(ingredient);
                            addImage.Source = "upload_remove";
                        }
                        else
                        {
                            _selectedIngredients.Remove(ingredient);
                            addImage.Source = "upload_add";
                        }
                    })
                });
            }
        }
    }
}
