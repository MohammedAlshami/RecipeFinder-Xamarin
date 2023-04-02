using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Models.Recipes
{
    public class Recipes
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public List<string> Steps { get; set; }
        public string Description { get; set; }
    }
}
