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
            new Ingredient { Name = "Potato", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Tomato_je.jpg/1082px-Tomato_je.jpg" },
            new Ingredient { Name = "Tomato", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Tomato_je.jpg/1082px-Tomato_je.jpg" },
            new Ingredient { Name = "Garlic", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Tomato_je.jpg/1082px-Tomato_je.jpg" },
            new Ingredient { Name = "Onion", Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/Tomato_je.jpg/1082px-Tomato_je.jpg" },
            };
            /*AddIngredients();*/ // Since this method is called from a constructor, we use Wait() instead of await.
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

    }
}
