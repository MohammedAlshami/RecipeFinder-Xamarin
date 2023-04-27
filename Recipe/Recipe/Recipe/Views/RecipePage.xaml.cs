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
            recipe_video.Stop();
            Find_Recipe(null, null);

        }
        private async void Find_Recipe(object sender, EventArgs e)
        {
            if (recipe != null)
            {
                Recipe_Name.Text = recipe.Name;
                thumbnail.Source = recipe.Image;
                recipe_video.Source = recipe.Video;
                DisplayStepsList(recipe.Steps);
                List<Ingredient> ingredientList = await ingredients.GetIngredients(recipe.Ingredients);
                foreach (var ingredient in ingredientList)
                {
                    var image = new Image { Source = ImageSource.FromUri(new Uri(ingredient.Image)), WidthRequest = 110, HeightRequest = 90, Aspect = Aspect.AspectFill };

                    var frame = new Frame
                    {
                        CornerRadius = 15,
                        HasShadow = true,
                        Padding = new Thickness(0, 0, 0, 0),
                        Margin = new Thickness(5),
                        Content = image

                    };
                    var label = new Label { Text = ingredient.Name, HorizontalOptions = LayoutOptions.Center };
                    var ingredientLayout = new StackLayout { Orientation = StackOrientation.Vertical };
                    ingredientLayout.Children.Add(frame);
                    ingredientLayout.Children.Add(label);
                    IngredientsLayout.Children.Add(ingredientLayout);
                }

            }
            else
            {
                await DisplayAlert("Success", "No Recipe Available", "OK");
            }

        }


        private void DisplayStepsList(List<string> stepsList)
        {
            StepsListStackLayout.Children.Clear();
            var count = 1;
            foreach (string step in stepsList)
            {
                var label = new Label
                {
                    Text = (count++) +" . " + step,
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
        private async void backbtn(object sender, EventArgs e)
        {
            await Device.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new HomePage());
            });

        }
        private int clicked = 0;
        private async void OnVideoClicked(object sender, EventArgs e)
        {
            if (clicked == 0)
            {
                recipe_overlay.IsVisible = false;
                recipe_play.IsVisible = false;
                thumbnail.IsVisible = false;
                clicked = 1;
                recipe_video.Play();
            }
            else
            {
                recipe_overlay.IsVisible = true;
                recipe_play.IsVisible = true;
                clicked = 0;
                recipe_video.Pause();

            }


        }
    }
}