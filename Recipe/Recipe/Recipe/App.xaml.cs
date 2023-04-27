using Recipe.Views;
using Recipe.Views.Navigation;
using Recipe.Views.Authentication;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Recipe.Views.Upload;
using Recipe.Views.Navigation;
using Recipe.Views;
using Xamarin.Forms.PlatformConfiguration;
using Recipe.Models.Recipes;
using Recipe.Models.Ingredients;
using System.Collections.Generic;
using Recipe.Models;

namespace Recipe
{
    public partial class App : Application
    {
        public string UserEmail { get; set; }
        public App()
        {
/*            CreateRecipes();
            CreateIngredient();*/
            InitializeComponent();
            UserEmail = null;

            MainPage = new SplashPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected void RecipeDate()
        {

        }

 /*       protected async void CreateIngredient()
        {
            List<Ingredient> ingredients = new List<Ingredient>
    {
        new Ingredient { Name = "rice", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fraw-rice-732x549-thumbnail-732x549.webp?alt=media" },
        new Ingredient { Name = "coconut milk", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FMy-Obession-With-Coconut-Milk-2.jpg?alt=media" },
        new Ingredient { Name = "pandan leaves", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fpandan-1296x728-header.webp?alt=media" },
        new Ingredient { Name = "lemongrass", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FScreen-Shot-2021-10-07-at-11.08.27-PM.webp?alt=media" },
        new Ingredient { Name = "dried anchovies", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fdried-anchovies.jpg?alt=media" },
        new Ingredient { Name = "peanuts", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Foven-roasted-peanuts-4172872-step-01-7548c7aae0e849a8b5a368d985caba2d.jpg?alt=media" },
        new Ingredient { Name = "cucumber", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fcucumbers2.jpg?alt=media" },
        new Ingredient { Name = "sambal", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fmalaysian-sambal-sauce-3030364-hero-02-abcaaf29182f43ac9938cdcb39272c82.jpg?alt=media" },
        new Ingredient { Name = "eggs", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FBrown-eggs.webp?alt=media" },
        new Ingredient { Name = "fried chicken", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2F8805-CrispyFriedChicken-mfs-3x2-072-d55b8406d4ae45709fcdeb58a04143c2.jpg?alt=media" },
        new Ingredient { Name = "ground beef", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FScreen-Shot-2021-10-07-at-11.08.27-PM.webp?alt=media" },
        new Ingredient { Name = "salt", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FTooMuchSodiuml-1051727580-770x533-1-650x428.jpg?alt=media" },
        new Ingredient { Name = "pepper", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fspice-story-black-pepper.jpg?alt=media" },
        new Ingredient { Name = "hamburger buns", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fbeautiful-burger-buns-alt.jpg?alt=media" },
        new Ingredient { Name = "lettuce", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fromaine-lettuce-1296x728-body.webp?alt=media" },
        new Ingredient { Name = "tomato", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FTomato_je.jpg?alt=media" },
        new Ingredient { Name = "onion", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2FScreen-Shot-2021-10-07-at-11.08.27-PM.webp?alt=media" },
        new Ingredient { Name = "ketchup", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fhomemade-tomato-ketchup-recipe.jpg?alt=media" },
        new Ingredient { Name = "mustard", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Fhomemade-yellow-mustard-fp.jpg?alt=media" },
        new Ingredient { Name = "mayonnaise", Image = "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/ingredients%2Feasy-mayonnaise-immersion-blender-1-2.jpg?alt=media" }
    };

            IngredientsHandler ingredientsHandler = new IngredientsHandler();
            foreach (Ingredient ingredient in ingredients)
            {
                await ingredientsHandler.AddIngredient(ingredient.Name, ingredient.Image);
            }

        }
        protected async void CreateRecipes()
        {
            List<Recipes> recipes = new List<Recipes> {
                    CreateRecipe(
                        "Chocolate Chip Cookies",
                        new List<string> { "flour", "sugar", "butter", "eggs", "vanilla extract", "chocolate chips" },
                        "https://joyfoodsunshine.com/wp-content/uploads/2016/01/best-chocolate-chip-cookies-recipe-ever-no-chilling-1.jpg",
                        "",
                        new List<string> {
                            "Preheat the oven to 350 degrees F",
                            "Mix the flour, sugar, and butter in a large bowl",
                            "Add the eggs and vanilla extract to the mixture and stir well",
                            "Stir in the chocolate chips",
                            "Drop spoonfuls of the cookie dough onto a baking sheet",
                            "Bake in the preheated oven for 10-12 minutes, or until lightly golden brown"
                        },
                        new List<string> { "cookies", "dessert", "chocolate" }
                    ),
                        CreateRecipe(
        "Pad Thai",
        new List<string> { "rice noodles", "chicken", "shrimp", "bean sprouts", "garlic", "shallots", "tamarind paste", "fish sauce", "peanuts", "lime" },
        "https://www.feastingathome.com/wp-content/uploads/2016/04/pad-thai-2.jpg",
        "",
        new List<string> {
            "Soak rice noodles in cold water for 30 minutes.",
            "Stir-fry chicken and shrimp until cooked, then set aside.",
            "Stir-fry garlic and shallots until fragrant.",
            "Add noodles, tamarind paste, fish sauce, and sugar. Stir-fry until noodles are cooked.",
            "Add bean sprouts, chives, and peanuts. Stir-fry for 1-2 minutes.",
            "Taste and adjust seasoning as needed.",
            "Garnish with lime wedges and more peanuts.",
            "Serve hot with chili flakes or sauce on the side.",
            "Enjoy the tangy, sweet, and savory flavors of Pad Thai!",
            "Serves 4-6 people."
        },
        new List<string> { "Thai", "noodles", "stir-fry", "spicy", "tangy", "sweet", "savory", "peanuts", "lime", "bean sprouts" }
    ),
                        CreateRecipe(
    "Tom Yum Soup",
    new List<string> { "lemongrass", "galangal", "kaffir lime leaves", "Thai chilies", "garlic", "shallots", "shrimp", "mushrooms", "fish sauce", "lime juice" },
    "https://rasamalaysia.com/wp-content/uploads/2020/12/tom-yum3.jpg",
    "",
    new List<string> {
        "In a pot, bring water to a boil and add lemongrass, galangal, kaffir lime leaves, Thai chilies, garlic, and shallots.",
        "Let it simmer for 10 minutes to infuse the flavors into the broth.",
        "Add shrimp and mushrooms to the pot and simmer for 2-3 minutes, or until the shrimp turn pink and are cooked through.",
        "Add fish sauce and lime juice to the soup and stir to combine.",
        "Taste and adjust seasoning as needed.",
        "Garnish with cilantro and serve hot with steamed rice or noodles."
    },
    new List<string> { "Thai", "soup", "shrimp", "lemongrass", "galangal", "kaffir lime", "spicy", "sour", "aromatic" }
),CreateRecipe(
    "Green Curry",
    new List<string> { "chicken", "coconut milk", "green curry paste", "Thai eggplant", "bamboo shoots", "Thai basil", "kaffir lime leaves", "fish sauce", "palm sugar", "green chili" },
    "https://hot-thai-kitchen.com/wp-content/uploads/2022/04/green-curry-new-sq-3.jpg",
    "",
    new List<string> {
        "In a pot, heat coconut milk over medium heat until it starts to bubble.",
        "Add green curry paste to the pot and stir until fragrant.",
        "Add chicken to the pot and stir until cooked through.",
        "Add Thai eggplant, bamboo shoots, kaffir lime leaves, and green chili to the pot.",
        "Simmer for 5-7 minutes until vegetables are tender.",
        "Add fish sauce and palm sugar to the pot and stir until dissolved.",
        "Add Thai basil leaves to the pot and turn off heat.",
        "Stir the curry to combine all ingredients.",
        "Serve hot with steamed rice."
    },
    new List<string> { "Thai", "curry", "chicken", "coconut milk", "spicy", "fragrant", "vegetables", "herbs" }
),CreateRecipe(
    "Papaya Salad",
    new List<string> { "green papaya", "carrots", "long beans", "tomatoes", "garlic", "Thai chili", "lime", "fish sauce", "palm sugar", "peanuts" },
    "https://www.seriouseats.com/thmb/yKNZ9ICJC5ZNhzcYHdHENxogpFw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/20210928-Som-Tam-Thai-green-papaya-salad-vicky-wasik-24-f0d666fc609f49a0b9f34897bd2c6303.jpg",
    "",
    new List<string> {
        "Peel and shred the green papaya and carrots into thin strips. Set aside.",
        "Trim and cut the long beans into 2-3 inch pieces.",
        "Cut the tomatoes into wedges.",
        "In a mortar and pestle, pound garlic and Thai chili until finely chopped.",
        "Add peanuts to the mortar and pestle and crush lightly.",
        "Add the long beans to the mortar and pestle and gently pound until bruised.",
        "Add the papaya and carrots to the mortar and pestle, along with fish sauce, palm sugar, and lime juice. Mix well.",
        "Taste and adjust seasoning as needed.",
        "Add tomatoes and toss lightly.",
        "Serve immediately with extra peanuts and lime wedges on the side."
    },
    new List<string> { "Thai", "salad", "papaya", "vegetables", "spicy", "sour", "salty", "crunchy", "peanuts" }
),CreateRecipe(
    "Massaman Curry",
    new List<string> { "beef", "potatoes", "onion", "peanuts", "coconut milk", "massaman curry paste", "tamarind paste", "palm sugar", "fish sauce", "bay leaves" },
    "https://www.wellplated.com/wp-content/uploads/2022/08/best-massaman-curry-recipe.jpg",
    "",
    new List<string> {
        "Cut the beef into bite-sized pieces and set aside.",
        "Peel and cut the potatoes into bite-sized pieces. Set aside.",
        "Peel and slice the onion into thin wedges.",
        "In a pot, heat some oil and fry the massaman curry paste for 2-3 minutes or until fragrant.",
        "Add the beef and cook until browned.",
        "Add the coconut milk, tamarind paste, palm sugar, and fish sauce. Stir well.",
        "Add the potatoes, onion, and bay leaves. Stir well and bring to a boil.",
        "Reduce heat to low, cover the pot, and simmer for 30-40 minutes or until the beef and potatoes are tender.",
        "Add the peanuts and stir well.",
        "Taste and adjust seasoning as needed.",
        "Serve hot with steamed rice."
    },
    new List<string> { "Thai", "curry", "beef", "potatoes", "spicy", "creamy", "nutty", "comfort food" }
),CreateRecipe(
    "Nasi Lemak",
    new List<string> { "rice", "coconut milk", "pandan leaves", "lemongrass", "dried anchovies", "peanuts", "cucumber", "sambal", "eggs", "fried chicken" },
    "https://asianinspirations.com.au/wp-content/uploads/2019/04/R02156_Mums-NasiLemak.jpg",
    "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/Videos%2FSambal%20TERBAIK%20Untuk%20Nasi%20Lemak..mp4?alt=media",
    new List<string> {
        "Rinse the rice and soak it in water for 30 minutes.",
        "Drain the rice and add it to a pot with coconut milk, pandan leaves, and lemongrass.",
        "Add water to the pot and bring to a boil.",
        "Reduce heat to low, cover the pot, and simmer for 20-25 minutes or until the rice is cooked.",
        "While the rice is cooking, fry the dried anchovies and peanuts separately and set aside.",
        "Slice the cucumber and set aside.",
        "Fry the eggs and set aside.",
        "Fry the chicken and set aside.",
        "To serve, scoop the rice onto a plate and top it with the fried anchovies, peanuts, cucumber, sambal, fried egg, and fried chicken.",
        "Enjoy the fragrant and flavorful Nasi Lemak!"
    },
    new List<string> { "Malaysian", "rice", "coconut", "spicy", "fried chicken", "eggs", "anchovies", "peanuts", "comfort food" }
),
                        CreateRecipe(
    "Rendang",
    new List<string> { "beef", "coconut milk", "lemongrass", "galangal", "kaffir lime leaves", "turmeric", "ginger", "garlic", "shallots", "chili peppers" },
    "https://big.com.my/wp-content/uploads/2019/05/rendang-web.jpg",
    "",
    new List<string> {
        "Cut the beef into small cubes and set aside.",
        "Blend the lemongrass, galangal, kaffir lime leaves, turmeric, ginger, garlic, shallots, and chili peppers into a paste.",
        "In a large pot, simmer the coconut milk over medium heat until the oil separates from the cream.",
        "Add the spice paste to the pot and stir well. Cook for a few minutes until fragrant.",
        "Add the beef to the pot and stir well to coat it with the spices.",
        "Add enough water to the pot to cover the beef.",
        "Simmer the beef and spices over low heat for 3-4 hours or until the meat is tender and the sauce has thickened.",
        "Serve hot with rice or bread.",
        "Enjoy the rich and aromatic flavors of Rendang!"
    },
    new List<string> { "Indonesian", "beef", "coconut milk", "spicy", "lemongrass", "galangal", "kaffir lime", "comfort food" }
),
CreateRecipe(
    "Laksa",
    new List<string> { "rice noodles", "coconut milk", "chicken", "shrimp", "tofu puffs", "bean sprouts", "lemongrass", "galangal", "chili peppers", "shallots" },
    "https://images.deliveryhero.io/image/foodpanda/recipes/asam-laksa-recipe-1.jpg",
    "",
    new List<string> {
        "Soak the rice noodles in cold water for 30 minutes.",
        "Blend the lemongrass, galangal, chili peppers, and shallots into a paste.",
        "In a large pot, simmer the paste in coconut milk over medium heat until fragrant.",
        "Add chicken and shrimp to the pot and cook until done.",
        "Add the tofu puffs to the pot and simmer for a few more minutes.",
        "Drain the rice noodles and add them to the pot along with bean sprouts.",
        "Simmer for a few more minutes until the noodles are cooked.",
        "Serve hot and enjoy the spicy and flavorful taste of Laksa!"
    },
    new List<string> { "Malaysian", "noodles", "coconut milk", "spicy", "lemongrass", "galangal", "chicken", "shrimp" }
),
CreateRecipe(
    "Satay",
    new List<string> { "chicken thighs", "lemongrass", "galangal", "turmeric", "cumin", "coriander", "garlic", "soy sauce", "coconut milk", "peanut sauce" },
    "https://rasamalaysia.com/wp-content/uploads/2019/04/chicken-satay-thumb.jpg",
    "",
    new List<string> {
        "Slice chicken thighs into thin strips and marinate in a mixture of chopped lemongrass, galangal, turmeric, cumin, coriander, garlic, soy sauce, and coconut milk for at least 2 hours.",
        "Thread the chicken strips onto skewers and grill over medium heat for 5-7 minutes on each side.",
        "Serve hot with a side of peanut sauce for dipping!",
        "Enjoy the fragrant and flavorful taste of Satay!"
    },
    new List<string> { "Indonesian", "chicken", "skewers", "lemongrass", "galangal", "turmeric", "peanut sauce" }
),
CreateRecipe(
    "Mee Goreng Mamak",
    new List<string> { "yellow noodles", "chicken", "shrimp", "tofu", "bean sprouts", "tomatoes", "potatoes", "onion", "garlic", "soy sauce" },
    "https://resepichenom.com/media/Mee_Goreng_Mamak_IG2.jpg",
    "",
    new List<string> {
        "Boil the yellow noodles until cooked, then drain and set aside.",
        "Stir-fry the chicken and shrimp until cooked, then set aside.",
        "Stir-fry tofu, bean sprouts, tomatoes, potatoes, onion, and garlic until fragrant.",
        "Add the cooked noodles, chicken, and shrimp to the wok and stir-fry everything together.",
        "Add soy sauce to taste and continue stir-frying until everything is heated through.",
        "Serve hot and enjoy the delicious flavors of Mee Goreng Mamak!"
    },
    new List<string> { "Malaysian", "noodles", "stir-fry", "spicy", "chicken", "shrimp" }
),
CreateRecipe(
    "Hummus",
    new List<string> { "chickpeas", "tahini", "garlic", "lemon juice", "olive oil", "cumin", "salt", "water" },
    "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2022/08/Hummus-main-1.jpg",
    "",
    new List<string> {
        "In a food processor, combine chickpeas, tahini, garlic, lemon juice, olive oil, cumin, and salt.",
        "Blend until smooth, adding water as needed to achieve desired consistency.",
        "Taste and adjust seasoning as needed.",
        "Serve chilled with pita bread, vegetables, or crackers.",
        "Enjoy the creamy and flavorful taste of hummus!"
    },
    new List<string> { "dip", "Middle Eastern", "vegan", "vegetarian", "healthy", "snack" }
)
,CreateRecipe(
    "Falafel",
    new List<string> { "dried chickpeas", "onion", "garlic", "parsley", "coriander", "cumin", "baking powder", "flour", "salt", "vegetable oil" },
    "https://i2.wp.com/www.downshiftology.com/wp-content/uploads/2019/07/Falafel-7.jpg",
    "",
    new List<string> {
        "Soak the chickpeas in water overnight.",
        "Drain the chickpeas and pat them dry with a paper towel.",
        "In a food processor, pulse the chickpeas, onion, garlic, parsley, coriander, cumin, baking powder, flour, and salt until a coarse mixture forms.",
        "Transfer the mixture to a bowl and refrigerate for 30 minutes.",
        "Form the mixture into small balls or patties.",
        "In a deep skillet or pot, heat the vegetable oil over medium heat.",
        "Fry the falafel until golden brown on all sides, about 3-4 minutes.",
        "Serve hot with tahini sauce, pita bread, and fresh vegetables.",
        "Enjoy the crispy and flavorful taste of falafel!"
    },
    new List<string> { "Middle Eastern", "vegetarian", "chickpeas", "fried", "tahini sauce" }
)
,
CreateRecipe(
    "Shawarma",
    new List<string> { "chicken thighs", "pita bread", "cucumber", "tomatoes", "red onion", "lettuce", "garlic", "lemon juice", "olive oil", "tahini" },
    "https://www.lemonblossoms.com/wp-content/uploads/2020/06/Chicken-Shawarma-Recipe-S5.jpg",
    "",
    new List<string> {
        "Slice chicken thighs into thin strips and marinate in garlic, lemon juice, and olive oil for at least an hour.",
        "Heat a skillet over high heat and cook the chicken strips until browned and cooked through.",
        "Warm the pita bread in the oven or on a grill.",
        "Slice cucumber, tomatoes, and red onion into thin slices.",
        "Mix tahini with lemon juice and water until desired consistency is achieved.",
        "Assemble the shawarma by spreading tahini sauce on the pita bread, then adding the cooked chicken, sliced vegetables, and lettuce.",
        "Fold the shawarma and serve hot."
    },
    new List<string> { "Middle Eastern", "chicken", "pita bread", "tahini", "garlic" }
)
,
CreateRecipe(
    "Tabouleh",
    new List<string> { "bulgur wheat", "tomatoes", "cucumber", "green onions", "parsley", "mint", "lemon juice", "olive oil", "salt", "pepper" },
    "https://tmbidigitalassetsazure.blob.core.windows.net/rms3-prod/attachments/37/1200x1200/Tabouleh_EXPS_TOHFM21_250394_E09_22_8b.jpg",
    "",
    new List<string> {
        "Soak the bulgur wheat in water for 20-30 minutes.",
        "Drain the bulgur wheat and set it aside.",
        "Chop the tomatoes, cucumber, and green onions into small pieces.",
        "Finely chop the parsley and mint.",
        "In a large bowl, mix together the bulgur wheat, chopped vegetables, parsley, and mint.",
        "Add lemon juice, olive oil, salt, and pepper to taste.",
        "Toss everything together until well combined.",
        "Cover the bowl with plastic wrap and refrigerate for at least an hour before serving.",
        "Serve chilled and enjoy the fresh and tangy taste of Tabouleh!"
    },
    new List<string> { "Lebanese", "bulgur wheat", "vegetarian", "salad", "fresh" }
)
,
CreateRecipe(
    "Baba Ghanoush",
    new List<string> { "eggplant", "tahini", "garlic", "lemon juice", "olive oil", "salt", "parsley" },
    "https://cookieandkate.com/images/2017/10/baba-ganoush-recipe-2.jpg",
    "",
    new List<string> {
        "Preheat oven to 400 degrees F.",
        "Cut the eggplant in half lengthwise, then score the flesh deeply in a crisscross pattern.",
        "Place the eggplant halves cut side up on a baking sheet lined with parchment paper.",
        "Roast the eggplant in the oven for 35-45 minutes or until tender.",
        "Remove from the oven and let cool for 10-15 minutes.",
        "Scoop out the flesh of the eggplant with a spoon and place it in a food processor.",
        "Add tahini, garlic, lemon juice, olive oil, and salt to the food processor.",
        "Blend everything together until smooth and creamy.",
        "Transfer the mixture to a bowl and garnish with parsley and a drizzle of olive oil.",
        "Serve at room temperature with pita bread or crackers and enjoy the rich and smoky taste of Baba Ghanoush!"
    },
    new List<string> { "Lebanese", "eggplant", "vegetarian", "dip", "smoky" }
)
,
CreateRecipe(
    "Pizza",
    new List<string> { "pizza dough", "tomato sauce", "mozzarella cheese", "toppings of your choice" },
    "https://www.allrecipes.com/thmb/iXKYAl17eIEnvhLtb4WxM7wKqTc=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/240376-homemade-pepperoni-pizza-Beauty-3x4-1-6ae54059c23348b3b9a703b6a3067a44.jpg",
    "",
    new List<string> {
        "Preheat the oven to 450 degrees F.",
        "Roll out the pizza dough to the desired size and thickness.",
        "Spread tomato sauce evenly over the dough, leaving a small border around the edges.",
        "Sprinkle mozzarella cheese over the sauce, then add toppings of your choice.",
        "Bake in the preheated oven for 10-12 minutes, or until the crust is golden brown and the cheese is melted and bubbly.",
        "Slice and serve hot, and enjoy your homemade pizza!"
    },
    new List<string> { "Italian", "pizza", "cheese", "tomato sauce", "baked", "dinner" }
)
,
CreateRecipe(
    "burgers",
    new List<string> { "ground beef", "salt", "pepper", "hamburger buns", "lettuce", "tomato", "onion", "ketchup", "mustard", "mayonnaise" },
    "https://www.tastingtable.com/img/gallery/what-makes-restaurant-burgers-taste-different-from-homemade-burgers-upgrade/l-intro-1662064407.jpg",
    "https://firebasestorage.googleapis.com/v0/b/realtimedatabasetest-f226a.appspot.com/o/Videos%2Fvideoplayback%20(2).mp4?alt=media",
    new List<string> {
        "Preheat the grill or a grill pan over medium-high heat.",
        "Season the ground beef with salt and pepper, and form into patties.",
        "Grill the patties for 4-5 minutes per side, or until they are cooked to your desired doneness.",
        "Toast the hamburger buns on the grill for 1-2 minutes, until they are lightly browned.",
        "Assemble the burgers by placing a patty on a bun, and adding lettuce, tomato, and onion as desired.",
        "Add ketchup, mustard, and mayonnaise to taste, then place the top bun on the burger.",
        "Serve hot and enjoy your delicious homemade hamburgers!"
    },
    new List<string> { "American", "hamburger", "grilled", "beef", "lettuce", "tomato", "onion" }
),
CreateRecipe(
    "Fish and Chips",
    new List<string> { "cod fillets", "potatoes", "flour", "baking powder", "salt", "pepper", "egg", "milk", "vegetable oil", "lemon wedges" },
    "https://forkandtwist.com/wp-content/uploads/2021/04/IMG_0102-500x500.jpg",
    "",
    new List<string> {
        "Peel and slice the potatoes into thin chips.",
        "Rinse the cod fillets and pat them dry with paper towels.",
        "In a bowl, mix flour, baking powder, salt, and pepper.",
        "In another bowl, whisk egg and milk.",
        "Dredge the cod fillets in the flour mixture, then dip them in the egg mixture.",
        "Coat the fillets again with the flour mixture.",
        "Heat vegetable oil in a deep fryer or large pan to 375°F (190°C).",
        "Fry the potatoes for 2-3 minutes, then remove and drain on paper towels.",
        "Fry the fish for 4-5 minutes, or until golden brown and crispy.",
        "Serve the fish and chips with lemon wedges and enjoy!"
    },
    new List<string> { "British", "fish", "potatoes", "deep-fried", "crispy" }
),
CreateRecipe(
    "Caesar Salad",
    new List<string> { "romaine lettuce", "croutons", "Parmesan cheese", "lemon juice", "Dijon mustard", "Worcestershire sauce", "garlic", "anchovy fillets", "olive oil", "egg yolk" },
    "https://assets.bonappetit.com/photos/624215f8a76f02a99b29518f/1:1/w_2800,h_2800,c_limit/0328-ceasar-salad-lede.jpg",
    "",
    new List<string> {
        "To make the dressing, whisk together lemon juice, Dijon mustard, Worcestershire sauce, garlic, and anchovy fillets.",
        "Slowly whisk in olive oil until the dressing is emulsified.",
        "Whisk in egg yolk until smooth and creamy.",
        "Tear romaine lettuce into bite-sized pieces and add to a large mixing bowl.",
        "Drizzle the dressing over the lettuce and toss to coat.",
        "Top with croutons and shaved Parmesan cheese.",
        "Serve and enjoy the classic taste of Caesar Salad!"
    },
    new List<string> { "salad", "Caesar Salad", "lettuce", "Parmesan cheese", "lemon juice", "anchovy fillets" }
),
CreateRecipe(
    "Steak",
    new List<string> { "steak", "salt", "pepper", "butter", "garlic", "rosemary" },
    "https://www.seriouseats.com/thmb/WzQz05gt5witRGeOYKTcTqfe1gs=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/butter-basted-pan-seared-steaks-recipe-hero-06-03b1131c58524be2bd6c9851a2fbdbc3.jpg",
    "",
    new List<string> {
        "Remove the steak from the refrigerator and let it sit at room temperature for 30 minutes.",
        "Preheat a skillet over medium-high heat.",
        "Season the steak generously with salt and pepper on both sides.",
        "Add butter, garlic, and rosemary to the skillet and cook until fragrant.",
        "Add the steak to the skillet and cook for 3-5 minutes on each side for medium-rare.",
        "Remove the steak from the skillet and let it rest for 5-10 minutes.",
        "Slice the steak against the grain and serve hot with your favorite sides."
    },
    new List<string> { "steak", "beef", "garlic", "rosemary" }
),
CreateRecipe(
    "Kung Pao Chicken",
    new List<string> { "chicken breast", "peanuts", "green onions", "dried red chili peppers", "garlic", "ginger", "soy sauce", "vinegar", "sugar", "cornstarch" },
    "https://www.onceuponachef.com/images/2018/05/Kung-Pao-Chicken-16-scaled.jpg",
    "",
    new List<string> {
        "Cut the chicken breast into small cubes and marinate with soy sauce, vinegar, sugar, and cornstarch for at least 30 minutes.",
        "Heat some oil in a wok over high heat and stir-fry the chicken until cooked. Set aside.",
        "In the same wok, stir-fry the dried red chili peppers until fragrant.",
        "Add the chopped garlic and ginger to the wok and stir-fry until fragrant.",
        "Add the chicken back into the wok along with the peanuts and green onions.",
        "Stir-fry everything together for a few more minutes until the flavors are well combined.",
        "Serve hot with steamed rice and enjoy the spicy and savory taste of Kung Pao Chicken!"
    },
    new List<string> { "Chinese", "stir-fry", "spicy", "chicken", "peanuts" }
)
,
CreateRecipe(
    "Dumplings",
    new List<string> { "ground pork", "wonton wrappers", "cabbage", "scallions", "ginger", "soy sauce", "sesame oil", "cornstarch" },
    "https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Xiaolongbao-breakfast.jpg/1200px-Xiaolongbao-breakfast.jpg",
    "",
    new List<string> {
        "Finely chop cabbage and scallions, then mix with ground pork and minced ginger in a bowl.",
        "Add soy sauce, sesame oil, and cornstarch to the mixture and stir well.",
        "Take a wonton wrapper and place a small spoonful of the filling in the center.",
        "Wet the edges of the wrapper with water and fold over to seal, making sure to press out any air pockets.",
        "Repeat with the remaining wrappers and filling until all the dumplings are made.",
        "Bring a pot of water to a boil and add the dumplings, making sure they don't stick together.",
        "Boil for 3-5 minutes or until the dumplings float to the surface and the filling is cooked through.",
        "Serve hot with soy sauce or other dipping sauces of your choice.",
        "Enjoy the savory and delicious taste of homemade dumplings!"
    },
    new List<string> { "Chinese", "dumplings", "pork", "cabbage", "ginger", "soy sauce" }
)
,
CreateRecipe(
    "Fried Rice",
    new List<string> { "cooked rice", "eggs", "peas", "carrots", "onion", "garlic", "soy sauce", "sesame oil", "vegetable oil", "salt" },
    "https://houseofnasheats.com/wp-content/uploads/2023/01/Chicken-Fried-Rice-Recipe-Square-1.jpg",
    "",
    new List<string> {
        "Heat the vegetable oil in a wok or large skillet over medium-high heat.",
        "Add the onion and garlic and stir-fry until fragrant and translucent.",
        "Add the peas and carrots and stir-fry for 1-2 minutes, until slightly softened.",
        "Push the vegetables to the side of the wok or skillet and crack the eggs into the empty space.",
        "Scramble the eggs until set and then mix with the vegetables.",
        "Add the cooked rice to the wok or skillet and stir-fry for a few minutes, breaking up any clumps with a spatula.",
        "Add soy sauce, sesame oil, and salt to taste and stir-fry for another minute.",
        "Serve hot and enjoy the savory flavors of Fried Rice!"
    },
    new List<string> { "Chinese", "rice", "stir-fry", "vegetables", "soy sauce" }
)
,
CreateRecipe(
    "Mapo Tofu",
    new List<string> { "firm tofu", "ground pork", "doubanjiang", "Sichuan peppercorns", "garlic", "ginger", "green onions", "chicken stock", "soy sauce", "cornstarch" },
    "https://omnivorescookbook.com/wp-content/uploads/2022/05/220510_Mapo-Tofu_550.jpg",
    "",
    new List<string> {
        "Prepare the tofu by cutting it into small cubes and blanching in hot water for 2 minutes. Drain and set aside.",
        "In a wok or large pan, heat oil and stir-fry the ground pork until it's no longer pink.",
        "Add the garlic, ginger, and Sichuan peppercorns and stir-fry until fragrant.",
        "Add the doubanjiang and stir-fry until the oil is red and fragrant.",
        "Pour in the chicken stock and bring it to a boil. Add the tofu cubes and simmer for 5 minutes.",
        "In a small bowl, mix together cornstarch and water to make a slurry. Pour the slurry into the pan and stir until the sauce thickens.",
        "Add green onions and a dash of soy sauce to taste.",
        "Serve hot with steamed rice and enjoy the spicy and savory taste of Mapo Tofu!"
    },
    new List<string> { "Chinese", "tofu", "spicy", "Sichuan peppercorns", "ground pork" }
)
,
CreateRecipe(
    "Chow Mein",
    new List<string> { "egg noodles", "chicken", "shrimp", "carrots", "cabbage", "bean sprouts", "soy sauce", "sesame oil", "garlic", "ginger" },
    "https://theviewfromgreatisland.com/wp-content/uploads/2022/01/chow-mein-2588-January-06-2022-3.jpg",
    "",
    new List<string> {
        "Cook the egg noodles according to package instructions, then drain and set aside.",
        "Stir-fry the chicken and shrimp until cooked, then set aside.",
        "Stir-fry garlic and ginger until fragrant.",
        "Add the sliced carrots and cabbage to the wok and stir-fry until tender.",
        "Add the bean sprouts and stir-fry for a few more minutes.",
        "Add the cooked egg noodles, chicken, and shrimp to the wok and stir-fry everything together.",
        "Season with soy sauce and sesame oil to taste, and continue stir-frying until everything is heated through.",
        "Serve hot and enjoy the delicious flavors of Chow Mein!"
    },
    new List<string> { "Chinese", "noodles", "stir-fry", "chicken", "shrimp" }
)
,
CreateRecipe(
    "Kimchi",
    new List<string> { "napa cabbage", "carrots", "scallions", "garlic", "ginger", "red pepper flakes", "fish sauce", "sugar", "water", "sea salt" },
    "https://www.maangchi.com/wp-content/uploads/2014/06/whole-cabbage-kimchi.jpg",
    "",
    new List<string> {
        "Chop the cabbage into bite-sized pieces and place them in a large bowl.",
        "Add 1/4 cup of sea salt and enough water to cover the cabbage. Mix well and let sit for 2 hours.",
        "Drain the cabbage and rinse it well. Squeeze out any excess water and place it back in the bowl.",
        "Add grated carrots and sliced scallions to the bowl.",
        "In a separate bowl, mix together minced garlic, grated ginger, red pepper flakes, fish sauce, sugar, and water to make the seasoning paste.",
        "Pour the seasoning paste over the vegetables and mix well.",
        "Pack the kimchi tightly into a jar and let it ferment for 1-5 days, depending on how sour you like it.",
        "After it has fermented, store it in the refrigerator and enjoy as a side dish or in other dishes!"
    },
    new List<string> { "Korean", "spicy", "cabbage", "fermented", "side dish" }
)
,
CreateRecipe(
    "Bibimbap",
    new List<string> { "rice", "carrots", "spinach", "bean sprouts", "shiitake mushrooms", "zucchini", "ground beef", "eggs", "soy sauce", "sesame oil" },
    "https://assets.bonappetit.com/photos/624f3dc73a6e981591892a9d/1:1/w_2800,h_2800,c_limit/0407-bibimbap-at-home-lede.jpg",
    "",
    new List<string> {
        "Cook rice according to package instructions.",
        "Julienne the carrots, blanch the spinach and bean sprouts, slice the shiitake mushrooms and zucchini.",
        "Heat up a pan, add some oil and sauté the ground beef until cooked.",
        "Add soy sauce and sesame oil to the cooked beef and mix well.",
        "In a separate pan, fry the eggs sunny-side up.",
        "Place cooked rice in a large bowl, arrange the vegetables and beef over the rice.",
        "Top with the fried egg and serve with gochujang sauce.",
        "Mix everything together before eating and enjoy the deliciousness of Bibimbap!"
    },
    new List<string> { "Korean", "rice bowl", "vegetables", "beef", "eggs", "spicy" }
)
,
CreateRecipe(
    "Korean Fried Chicken",
    new List<string> { "chicken wings", "cornstarch", "flour", "baking powder", "salt", "garlic powder", "paprika", "soy sauce", "rice vinegar", "honey", "gochujang", "sesame seeds", "scallions" },
    "https://www.kitchensanctuary.com/wp-content/uploads/2019/08/Korean-Fried-Chicken-square-FS-New-7377.jpg",
    "",
    new List<string> {
        "Preheat the oven to 400 degrees F.",
        "Mix cornstarch, flour, baking powder, salt, garlic powder, and paprika in a bowl.",
        "Add chicken wings to the bowl and toss until well coated with the flour mixture.",
        "Arrange chicken wings on a baking sheet and bake for 40-45 minutes or until crispy and golden brown.",
        "While the chicken is baking, make the sauce by combining soy sauce, rice vinegar, honey, gochujang, and sesame seeds in a saucepan.",
        "Heat the sauce over medium heat until the honey is dissolved and the sauce is smooth.",
        "When the chicken wings are done, transfer them to a large bowl and pour the sauce over them.",
        "Toss the chicken wings until they are evenly coated with the sauce.",
        "Garnish with sliced scallions and enjoy the crispy, spicy, and delicious Korean Fried Chicken!"
    },
    new List<string> { "Korean", "chicken wings", "spicy", "crispy", "sesame", "honey" }
),
CreateRecipe(
    "Bulgogi",
    new List<string> { "sirloin steak", "soy sauce", "sugar", "pear", "garlic", "sesame oil", "scallions", "carrots", "onions", "mushrooms" },
    "https://assets.bonappetit.com/photos/57acd741f1c801a1038bc801/1:1/w_2560%2Cc_limit/basic-bulgogi.jpg",
    "",
    new List<string> {
        "Slice the steak thinly and place in a bowl.",
        "In a blender or food processor, blend together the soy sauce, sugar, pear, garlic, and sesame oil until smooth.",
        "Pour the marinade over the steak and mix well. Cover and refrigerate for at least 30 minutes, or overnight.",
        "Heat a large skillet or wok over high heat.",
        "Add the marinated steak and cook, stirring frequently, until browned and cooked through.",
        "Add sliced scallions, carrots, onions, and mushrooms and stir-fry until the vegetables are tender.",
        "Serve hot with rice and enjoy the savory and sweet flavors of Bulgogi!"
    },
    new List<string> { "Korean", "beef", "marinated", "stir-fry", "salty", "sweet" }
),
CreateRecipe(
    "Japchae",
    new List<string> { "sweet potato noodles", "beef", "spinach", "carrots", "onions", "mushrooms", "garlic", "soy sauce", "sugar", "sesame oil" },
    "https://drivemehungry.com/wp-content/uploads/2020/06/japchae-korean-glass-noodles-19.jpg",
    "",
    new List<string> {
        "Boil sweet potato noodles for 6-7 minutes, or until cooked but still chewy.",
        "Rinse the noodles in cold water and drain.",
        "Cut beef into thin strips and marinate in a mixture of soy sauce, sugar, and garlic.",
        "Slice onions, carrots, and mushrooms into thin strips.",
        "Heat up a pan with some oil and stir-fry the beef until browned.",
        "Remove the beef and stir-fry the onions, carrots, and mushrooms until softened.",
        "Add the spinach and stir-fry until wilted.",
        "Add the cooked noodles and stir-fry everything together.",
        "Add soy sauce, sugar, and sesame oil to taste and stir-fry for another minute.",
        "Serve hot or cold and enjoy the deliciousness of Japchae!"
    },
    new List<string> { "Korean", "noodles", "beef", "vegetables", "soy sauce", "sesame oil" }
)


        };
            RecipeHandler recipeHandler = new RecipeHandler();
            foreach (Recipes rec in recipes)
            {
                await recipeHandler.AddRecipe(rec);
            }

        }
        public Recipes CreateRecipe(string name, List<string> ingredients, string image, string video, List<string> steps, List<string> keywords)
        {
            var recipe = new Recipes
            {
                Name = name,
                Ingredients = ingredients,
                Image = image,
                Video = video,
                Steps = steps,
                Keywords = keywords
            };

            // Perform any additional initialization or processing here if needed

            return recipe;
        }*/

    }
}
