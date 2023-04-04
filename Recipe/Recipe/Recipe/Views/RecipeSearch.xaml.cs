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
        private List<Recipes> allRecipes;
        public RecipeSearch ()
		{
			InitializeComponent ();
            recipeHandler = new RecipeHandler();

        }

        protected override async void OnAppearing()
    {
        base.OnAppearing();
        allRecipes = await recipeHandler.GetAllRecipes();
    }

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        RecipeList.Children.Clear();
        string searchText = SearchBar.Text.ToLower();
        var filteredRecipes = allRecipes.Where(r => r.Name.ToLower().Contains(searchText) || r.Ingredients.Any(i => i.ToLower().Contains(searchText)));
        foreach (var recipe in filteredRecipes)
        {
            var recipeImage = new Image { Source = recipe.Image, Aspect = Aspect.AspectFill, HeightRequest = 150, Margin = new Thickness(0, 10, 0, 0) };
            var recipeName = new Label { Text = recipe.Name, FontSize = 18, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center };

            var recipeContent = new StackLayout { Children = { recipeImage, recipeName } };
            var frame = new Frame
            {
                CornerRadius = 15,
                HasShadow = false,
                Padding = new Thickness(0),
                BackgroundColor = Color.White,
                Content = recipeContent,
                HeightRequest = 100,
                WidthRequest = 100
            };
            var recipeStack = new StackLayout { Children = { frame }, Margin = new Thickness(10, 0, 10, 10) };
            RecipeList.Children.Add(recipeStack);
        }
    }
}
}