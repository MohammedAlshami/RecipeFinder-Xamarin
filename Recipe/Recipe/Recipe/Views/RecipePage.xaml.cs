using Recipe.Models.Ingredients;
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
    public partial class RecipePage : ContentPage
    {
        readonly RecipeHandler recipeHandler = new RecipeHandler();
        readonly IngredientsHandler ingredients = new IngredientsHandler();
        Recipes recipe;

        public RecipePage(Recipes r)
        {
            InitializeComponent();
            recipeHandler = new RecipeHandler();
            this.recipe = r;    

        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            Find_Recipe(null, null);

        }
        private async void Find_Recipe(object sender, EventArgs e)
        {
            if (recipe != null)
            {
                Recipe_Name.Text = recipe.Name;
                DisplayStepsList(recipe.Steps);
                List<Ingredient> ingredientList = await ingredients.GetIngredients(recipe.Ingredients);
                foreach (var ingredient in ingredientList)
                {
                    var image = new Image { Source = ImageSource.FromUri(new Uri(ingredient.Image)), WidthRequest = 140, HeightRequest = 120, Aspect = Aspect.AspectFill };
                    var label = new Label { Text = ingredient.Name, HorizontalOptions = LayoutOptions.Center };
                    var ingredientLayout = new StackLayout { Orientation = StackOrientation.Vertical };
                    ingredientLayout.Children.Add(image);
                    ingredientLayout.Children.Add(label);
                    IngredientsLayout.Children.Add(ingredientLayout);
                }
                await DisplayAlert("Success", "Recipe Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Recipe Available", "OK");
            }

        }


        private void DisplayStepsList(List<string> stepsList)
        {
            StepsListStackLayout.Children.Clear();

            foreach (string step in stepsList)
            {
                var label = new Label
                {
                    Text = step,
                    FontSize = 18,
                    Margin = new Thickness(10, 5),
                    Padding = new Thickness(10, 5),
                    TextColor = Color.Black
                };

                var grid = new Grid
                {
                    ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = GridLength.Auto }
            }
                };
                grid.Children.Add(label, 0, 0);

                var frame = new Frame
                {
                    Content = grid,
                    Margin = new Thickness(20, 5, 20, 5),
                    Padding = new Thickness(10),
                    HasShadow = true,
                    CornerRadius = 10,
                    HeightRequest = 40 // Set the height of the frame to 80
                };

                StepsListStackLayout.Children.Add(frame);
            }
        }
    }
}