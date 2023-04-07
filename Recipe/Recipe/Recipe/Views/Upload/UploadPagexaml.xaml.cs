using Firebase.Storage;
using Recipe.Models.Ingredients;
using Recipe.Models.Recipes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views.Upload
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadPagexaml : ContentPage
    {
        RecipeHandler recipeHandler = new RecipeHandler();
        private List<string> stepsList = new List<string>();
        List<string> selectedIngredients = new List<string>();
        IngredientsHandler ingredientsHandler;
        Dictionary<string, Dictionary<string, object>> loadedIngredients = new Dictionary<string, Dictionary<string, object>>();

        public UploadPagexaml()
        {

            ingredientsHandler = new IngredientsHandler();
            LoadAllIngredients();
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            /*            await DisplayAlert("Hello", "", "OK");
            */
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            GetSelectedIngredients();
            await recipeHandler.AddRecipe(new Recipes()
            {
                RecipeId = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Image = downloadLink.Text,
                Ingredients = selectedIngredients,
                Video = videoLink.Text,
                Steps = stepsList,
                Description = txtDescription.Text
            });
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            /*  txtImage.Text = string.Empty;*/
            /*txtVideo.Text = string.Empty;*/
            /*txtSteps.Text = string.Empty;*/
            txtDescription.Text = string.Empty;
            await DisplayAlert("Success", "Recipe Added Successfully", "OK");
        }

        async void Upload_Image(System.Object sender, System.EventArgs e)
        {
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null)
                return;

            /* generating random name for the file*/
            var fileExtension = Path.GetExtension(photo.FileName);
            var uniqueId = Guid.NewGuid().ToString();

            var task = new FirebaseStorage("realtimedatabasetest-f226a.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("DidYouSubscribe")
                .Child("ToMyChannelYet")
                .Child(uniqueId + fileExtension)
                .PutAsync(await photo.OpenReadAsync());

            task.Progress.ProgressChanged += (s, args) =>
            {
                progressBar.Progress = args.Percentage;
            };

            var downloadlink = await task;
            downloadLink.Text = downloadlink;
        }
        async void Upload_Video(System.Object sender, System.EventArgs e)
        {
            var video = await Xamarin.Essentials.MediaPicker.PickVideoAsync();

            if (video == null)
                return;

            /* generating random name for the file*/
            var fileExtension = Path.GetExtension(video.FileName);
            var uniqueId = Guid.NewGuid().ToString();

            var task = new FirebaseStorage("realtimedatabasetest-f226a.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("DidYouSubscribe")
                .Child("ToMyChannelYet")
                .Child(uniqueId + fileExtension)
                .PutAsync(await video.OpenReadAsync());

            task.Progress.ProgressChanged += (s, args) =>
            {
                videoprogressBar.Progress = args.Percentage;
            };

            var videolink = await task;
            videoLink.Text = videolink;
        }

        async void GetSteps(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new StepsPopup(stepsList));
            stepsList = (List<string>)result;
        }
        async void GetIngredient(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new IngredientsPopup(loadedIngredients));
            if (result != null)
            {
                loadedIngredients = result as Dictionary<string, Dictionary<string, object>>;
            }
        }

        private async void LoadAllIngredients()
        {
            var allIngredients = await ingredientsHandler.GetAllIngredients();

            // Load ingredients into a dictionary with default boolean value false
            foreach (var ingredient in allIngredients)
            {
                Dictionary<string, object> ingredientInfo = new Dictionary<string, object>();
                ingredientInfo.Add("image", ingredient.Image);
                ingredientInfo.Add("isSelected", false);
                loadedIngredients.Add(ingredient.Name, ingredientInfo);
                /*                await DisplayAlert("Ingredient Info", $"Image: {ingredientInfo["image"]}, IsSelected: {ingredientInfo["isSelected"]}", "OK");
                */

            }
        }
        private void GetSelectedIngredients()
        {

            foreach (var ingredient in loadedIngredients)
            {
                // Check if ingredient is selected (isSelected is true)
                if (ingredient.Value.ContainsKey("isSelected") && (bool)ingredient.Value["isSelected"])
                {
                    selectedIngredients.Add(ingredient.Key);
                }
            }
        }
    }
}