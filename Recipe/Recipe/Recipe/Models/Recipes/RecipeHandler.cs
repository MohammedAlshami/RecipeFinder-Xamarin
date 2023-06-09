﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Recipe.Models.Ingredients;
using Xamarin.Essentials;

namespace Recipe.Models.Recipes
{
    public class RecipeHandler
    {
        FirebaseClient firebase = new FirebaseClient("https://realtimedatabasetest-f226a-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task<List<Recipes>> GetAllRecipes()
        {
            return (await firebase
              .Child("Recipe")
              .OnceAsync<Recipes>()).Select(item => new Recipes
              {
                  RecipeId = item.Object.RecipeId,
                  Name = item.Object.Name,
                  Ingredients = item.Object.Ingredients,
                  Image = item.Object.Image,
                  Video = item.Object.Video,
                  Steps = item.Object.Steps,
                  Description = item.Object.Description
              }).ToList();
        }

        public async Task AddRecipe(Recipes recipe)
        {
    /*        var recipe = new Recipes
            {
                RecipeId = 1,
                Name = "Spaghetti",
                Ingredients = new List<string> { "Potato", "Tomato", "Garlic", "Onion" },
                Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F64ddb43f-1641-490e-b2ea-a3b559191d18.jpg?alt=media&token=bedb5fde-8deb-44ab-b486-3afb7809a8f5",
                Video = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/DidYouSubscribe%2FToMyChannelYet%2F250f4cea-f328-4945-8ebe-94a77c2ec35b.mp4?alt=media&token=610a6422-db62-4b70-85e6-8e9af5ba373e",
                Steps = new List<string> { "Step 1", "Step 2", "Step 3" },
                Description = "A classic Italian dish."
            };*/

            await firebase
              .Child("Recipe")
              .PostAsync(recipe);
        }

        public async Task<Recipes> GetRecipe(int recipeId)
        {
            var allRecipes = await GetAllRecipes();
            return allRecipes.Where(a => a.RecipeId == recipeId).FirstOrDefault();
        }
        public async Task<Recipes> GetRecipeByName(string name)
        {
            var recipe = (await firebase
                .Child("Recipe")
                .OrderBy("Name")
                .EqualTo(name)
                .OnceAsync<Recipes>())
                .FirstOrDefault();

            if (recipe != null)
            {
                return new Recipes
                {
                    RecipeId = recipe.Object.RecipeId,
                    Name = recipe.Object.Name,
                    Ingredients = recipe.Object.Ingredients,
                    Image = recipe.Object.Image,
                    Video = recipe.Object.Video,
                    Steps = recipe.Object.Steps,
                    Description = recipe.Object.Description
                };
            }

            return null;
        }


        public async Task<List<Recipes>> GetRecipes(string searchQuery)
        {
            var recipes = await firebase
                .Child("Recipe")
                .OnceAsync<Recipes>();

            foreach (var recipe in recipes)
            {
                Console.WriteLine($"Recipe name: {recipe.Object.Name}");
                Console.WriteLine("Keywords:");
                if (recipe.Object.Keywords != null)
                {
                    foreach (var keyword in recipe.Object.Keywords)
                    {
                        Console.Write(keyword + " ");
                    }
                }
            }

            var matchingRecipes = new List<Recipes>();
            foreach (var recipe in recipes.Select(r => r.Object))
            {
                if (recipe.Keywords != null && recipe.Keywords.Any(k => k.ToLower().Contains(searchQuery.ToLower())))
                {
                    matchingRecipes.Add(recipe);
                }
            }

            return matchingRecipes;
        }



    }


}
