using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Models.Ingredients
{
    class IngredientsHandler
    {
        FirebaseClient firebase;
        List<Ingredient> ingredients;
        public IngredientsHandler()
        {
            firebase = new FirebaseClient("https://realtimedatabasetest-f226a-default-rtdb.asia-southeast1.firebasedatabase.app/");
            ingredients = new List<Ingredient>(){
             new Ingredient { Name = "Beef", Image = "https://upload.wikimedia.org/wikipedia/commons/6/64/Beef_cuts_%28english%29.svg" },
            new Ingredient { Name = "Chicken", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Roast_chicken_with_lemon_and_herbs_%281%29.jpg/1024px-Roast_chicken_with_lemon_and_herbs_%281%29.jpg" },
            new Ingredient { Name = "Pork", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/Blade_steak.jpg/1280px-Blade_steak.jpg" },
            new Ingredient { Name = "Salmon", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Atlantic_salmon_%28Salmo_salar%29.jpg/1024px-Atlantic_salmon_%28Salmo_salar%29.jpg" }


            };
           /* AddIngredients();*/ // Since this method is called from a constructor, we use Wait() instead of await.
        }

        public async Task AddIngredient(string name, string imageUrl)
        {
            var ingredient = new Ingredient { Name = name, Image = imageUrl };
            await firebase
                .Child("Ingredients")
                .PostAsync(ingredient);
        }
        public async Task AddIngredients()
        {
            foreach (var ingredient in ingredients)
            {
                await AddIngredient(ingredient.Name, ingredient.Image);
            }
        }
        public async Task<List<Ingredient>> GetIngredients(List<string> ingredientNames)
        {
            var ingredients = new List<Ingredient>();
            foreach (var name in ingredientNames)
            {
                var result = await firebase
                    .Child("Ingredients")
                    .OrderBy("Name")
                    .EqualTo(name)
                    .OnceAsync<Ingredient>();

                ingredients.AddRange(result.Select(i => i.Object));
            }

            return ingredients;
        }
        public async Task<List<Ingredient>> GetAllIngredients()
        {
            var result = await firebase
                .Child("Ingredients")
                .OrderBy("Name")
                .OnceAsync<Ingredient>();

            return result.Select(i => i.Object).ToList();
        }


    }
}
