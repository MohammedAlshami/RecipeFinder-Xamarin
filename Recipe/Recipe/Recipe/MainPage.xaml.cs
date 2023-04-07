using Firebase.Storage;
using Recipe.Models.Ingredients;
using Recipe.Models.Recipes;
using Recipe.Views;
using Recipe.Views.Upload;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Recipe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnClicked(object sender, EventArgs e)
        {
            // Handle button click event here
            await Navigation.PushAsync(new RecipeSearch());

        }
    }
}

