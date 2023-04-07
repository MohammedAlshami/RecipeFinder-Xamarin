using Recipe.Models.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views.Upload
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsPopup : Popup
    {
        IngredientsHandler ingredientsHandler;
        Dictionary<string, Dictionary<string, object>> loadedIngredients;

        StackLayout currentSubStack = null;

        public IngredientsPopup(Dictionary<string, Dictionary<string, object>> Ingredients)
        {
            InitializeComponent();
            ingredientsHandler = new IngredientsHandler();
            loadedIngredients = Ingredients;
            DisplayLoadedIngredients();
        }

        private void DisplayLoadedIngredients()
        {
            IngredientsStack.Children.Clear();

            foreach (var key in loadedIngredients.Keys)
            {
                var ingredientInfo = loadedIngredients[key];

                var frame = new Frame
                {
                    WidthRequest = 100,
                    HeightRequest = 100,
                    Margin = new Thickness(5),
                    BackgroundColor = (bool)ingredientInfo["isSelected"] ? Color.FromHex("#2196F3") : Color.LightGray,
                    CornerRadius = 5
                };

                var nameLabel = new Label
                {
                    Text = key,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    FontSize = 12,
                    TextColor = (bool)ingredientInfo["isSelected"] ? Color.White : Color.Black
                };

                var image = new Image
                {
                    Source = (string)ingredientInfo["image"],
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = 50,
                    HeightRequest = 50
                };

                var addButton = new Button
                {
                    Text = (bool)ingredientInfo["isSelected"] ? "Remove" : "Add",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.EndAndExpand,
                    FontSize = 12,
                    TextColor = Color.White,
                    BackgroundColor = Color.FromHex("#2196F3"),
                    CornerRadius = 5
                };

                addButton.Clicked += async (sender, e) =>
                {
                    var button = (Button)sender;
                    var selected = !(bool)ingredientInfo["isSelected"];
                    ingredientInfo["isSelected"] = selected;
                    button.Text = selected ? "Remove" : "Add";
                    frame.BackgroundColor = selected ? Color.FromHex("#2196F3") : Color.LightGray;
                    nameLabel.TextColor = selected ? Color.White : Color.Black;

                    await button.ScaleTo(0.9, 50, Easing.CubicOut);
                    await button.ScaleTo(1, 50, Easing.CubicIn);

                };

                frame.Content = new StackLayout
                {
                    Children = { nameLabel, image, addButton }
                };

                IngredientsStack.Children.Add(frame);
            }
        }

        private async void OnAddIngredientButtonClicked(object sender, EventArgs e)
        {
            Dismiss(loadedIngredients);
            // Pass loadedIngredients or addedIngredients to the appropriate method as needed.
        }
    }
}
