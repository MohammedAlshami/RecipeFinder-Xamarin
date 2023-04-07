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

            var recipes = new List<Recipes>
            {
                new Recipes
                {
                    Name = "Spaghetti Bolognese",
                    Ingredients = new List<string>
                    {
                        "spaghetti", "minced beef", "onion", "garlic", "tomato sauce"
                    },
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Spaghetti_Bolognese.jpg/440px-Spaghetti_Bolognese.jpg",
                    Video = "https://www.youtube.com/watch?v=AJmC6zX9Ouc",
                    Steps = new List<string>
                    {
                        "Cook spaghetti according to package directions",
                        "Brown minced beef in a pan",
                        "Add chopped onion and garlic to the pan and cook until softened",
                        "Add tomato sauce and simmer for 10 minutes",
                        "Serve the sauce over the cooked spaghetti"
                    },
                    Description = "A classic Italian dish of spaghetti with a rich meaty tomato sauce",
                    Keywords = new List<string> { "spaghetti", "bolognese", "meat", "tomato" }
                },
                new Recipes
                {
                    Name = "Chicken Curry",
                    Ingredients = new List<string>
                    {
                        "chicken", "onion", "garlic", "curry powder", "coconut milk"
                    },
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/Chicken_Curry_Rice_Dinner.jpg/440px-Chicken_Curry_Rice_Dinner.jpg",
                    Video = "https://www.youtube.com/watch?v=rCpOaNJHltQ",
                    Steps = new List<string>
                    {
                        "Heat oil in a pan",
                        "Add chopped onion and garlic to the pan and cook until softened",
                        "Add curry powder and cook for 1 minute",
                        "Add chicken to the pan and cook until browned",
                        "Add coconut milk and simmer for 20 minutes",
                        "Serve with rice"
                    },
                    Description = "A spicy Indian dish of chicken cooked in a creamy coconut milk sauce",
                    Keywords = new List<string> { "chicken", "curry", "spicy", "indian" }
                } };
     /*       foreach (var recipe in recipes)
            {
                recipehandler.AddRecipe(recipe);
            }*/

                
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
        private async void SearchRecipes(object sender, TextChangedEventArgs e)
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
                        Margin = new Thickness(25, 10, 25, 10),
                        HasShadow = true,
                        CornerRadius = 15,
                    };

                    Label nameLabel = new Label { Text = recipe.Name, FontSize = 18 };

                    frame.Content = nameLabel; // Set the label as content of the frame

                    searchStack.Children.Add(frame); // Add the frame to the main recipe stack
                }
            }
            else
            {
                Console.WriteLine("No recipes found.");
            }

          

        }




    }
}
