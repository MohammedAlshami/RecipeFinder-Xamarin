using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Storage;
using Recipe.Models.Ingredients;
using Recipe.Models.Recipes;
using System.IO;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using Recipe.Views.Profile;

namespace Recipe.Views.Upload
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadPage : ContentPage
	{

        // Variables 
        RecipeHandler recipeHandler = new RecipeHandler();
        // Steps
        List<string> stepsList;

        // links
        private string videolink = null, thumbnail = null;

        // Ingredients
        Dictionary<string, Dictionary<string, object>> loadedIngredients;
        private List<string> _selectedIngredients = new List<string>();

        // initializing popups first to make the app faster
        private UploadIngredients _ingredientPopup;

        public UploadPage (string yes="0")
		{
			InitializeComponent ();
            if (yes == "1") {
                backbuttonlogo.IsVisible = true;
            }
            _ingredientPopup = new UploadIngredients(_selectedIngredients);

            stepsList = new List<string> ();
           loadedIngredients = new Dictionary<string, Dictionary<string, object>>();



        }
        public UploadPage()
        {
            InitializeComponent();

            _ingredientPopup = new UploadIngredients(_selectedIngredients);

            stepsList = new List<string>();
            loadedIngredients = new Dictionary<string, Dictionary<string, object>>();

        }
        private async void AddIngredients(object sender, EventArgs e)
        {
            // TODO: Implement the AddIngredients function here

        }

        async void GetSteps(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new StepsPopup(stepsList));
            stepsList = (List<string>)result;
            if (stepsList != null && stepsList.Count >0)
            {
                stepIcon.Source = "upload_edit";

            }
            else if (stepsList.Count == 0)
            {
                stepIcon.Source = "upload_add";

            }
        }
        async void UploadThumbnail(System.Object sender, System.EventArgs e)
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


            thumbnail = await task;

            thumbnailImage.Source = thumbnail;
            thumbnaiIcon.Source = "upload_edit";

        }

        async void GetIngredient(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(_ingredientPopup);
            if (result != null)
            {
                _selectedIngredients = result as List<string>;
             
             
            }

            if (_selectedIngredients != null && _selectedIngredients.Count > 0)
            {
                ingredientsIcon.Source = "upload_edit";

            }
        }
        async void Upload_Video(System.Object sender, System.EventArgs e)
        {

            uploadLabel.IsVisible = false;
            uploadProgressBar.IsVisible = true;
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

            for (int i = 0; i <= 100; i += 5)
            {
                uploadProgressBar.Progress = i / 100.0;
                await Task.Delay(50);
            }

            videolink = await task;
            videoIcon.Source = "upload_edit";
            uploadProgressBar.Progress = 100;

        }
        private List<string> AddKeywordsToList()
        {
            string keywordsText = keywords.Text;
            List<string> keywordsList = new List<string>();

            if (!string.IsNullOrEmpty(keywordsText))
            {
                string[] keywordsArray = keywordsText.Split(new char[] { ' ', '#', ',' }, StringSplitOptions.RemoveEmptyEntries);
                keywordsList = keywordsArray.ToList();
            }

            return keywordsList;
        }



        private void onUploadButtonClick(object sender, EventArgs e)
        {
            // Your implementation here
            // do checking

            // upload
            if (AreFieldsValid())
            {
                var recipe = new Recipes
                {
                    Name = recipeTitle.Text,
                    Ingredients = _selectedIngredients,
                    Image = thumbnail,
                    Video = videolink,
                    Steps = stepsList,
                    Keywords = AddKeywordsToList()
                };
                recipeHandler.AddRecipe(recipe);
            }
            
        }
        private async void backBtn(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
            }
            catch (Exception ex)
            {
                // Handle the exception here
                Console.WriteLine($"Exception while navigating to BottomNavigation page: {ex.Message}");
            }

        }

        private bool AreFieldsValid()
        {
            
      

            if (string.IsNullOrEmpty(videolink))
            {
                DisplayAlert("Error", "Please add the video.", "OK");
                return false;
            }else
            {
                if (stepsList == null || stepsList.Count < 2)
                {
                    DisplayAlert("Error", "Please add at least 2 steps to the list.", "OK");
                    return false;
                }else
                {
                    if (_selectedIngredients == null || _selectedIngredients.Count < 2)
                    {
                        DisplayAlert("Error", "Please add at least 2 ingredients to the list.", "OK");
                        return false;
                    }else
                    {
                        if (string.IsNullOrEmpty(thumbnail))
                        {
                            DisplayAlert("Error", "Please add the thumbnail.", "OK");
                            return false;
                        }else
                        {
                            if (string.IsNullOrEmpty(recipeTitle.Text))
                            {
                                DisplayAlert("Error", "Please enter a recipe title.", "OK");
                                return false;
                            }else
                            {
                                if (string.IsNullOrEmpty(keywords.Text))
                                {
                                    DisplayAlert("Error", "Please enter some keywords.", "OK");
                                    return false;
                                }
                            }

                        }
                    }

                }
            }
            
            

            // Check if other fields are not null or empty as well

            return true;
        }


    }
}