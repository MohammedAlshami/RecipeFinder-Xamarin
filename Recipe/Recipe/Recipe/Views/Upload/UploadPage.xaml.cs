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

namespace Recipe.Views.Upload
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UploadPage : ContentPage
	{

        // Variables 

        // Steps
        List<string> stepsList;

        // Ingredients
        Dictionary<string, Dictionary<string, object>> loadedIngredients;
        public UploadPage ()
		{
			InitializeComponent ();
            stepsList = new List<string> ();
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


            var downloadlink = await task;
            thumbnailImage.Source = downloadlink;
        }

        async void GetIngredient(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new IngredientsPopup(loadedIngredients));
            if (result != null)
            {
                loadedIngredients = result as Dictionary<string, Dictionary<string, object>>;
            }
        }


    }
}