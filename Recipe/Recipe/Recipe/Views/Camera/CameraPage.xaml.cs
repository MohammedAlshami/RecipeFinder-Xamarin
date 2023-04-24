using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media;
using Xamarin.Essentials;

namespace Recipe.Views.Camera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();
        }

        private async void OnTakePhotoClicked()
        {
            var cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            var storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", "No camera available.", "OK");
                    return;
                }

                var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (photo == null)
                    return;

                imagePreview.Source = ImageSource.FromStream(() =>
                {
                    var stream = photo.GetStream();
                    photo.Dispose();
                    return stream;
                });
            }
            else
            {
                await DisplayAlert("Permissions Denied", "Unable to take photos without camera and storage permissions.", "OK");
            }
        }

        private async void OnSelectPhotoClicked()
        {
            var galleryStatus = await Permissions.RequestAsync<Permissions.StorageRead>();

            if (galleryStatus != PermissionStatus.Granted)
            {
                await DisplayAlert("Permissions Denied", "Unable to access photo gallery without storage permission.", "OK");
                return;
            }

            var pickPhoto = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                CompressionQuality = 75
            });

            if (pickPhoto == null)
                return;

            imagePreview.Source = ImageSource.FromStream(() =>
            {
                var stream = pickPhoto.GetStream();
                return stream;
            });
        }

        private void TakePhotoButton_Clicked(object sender, EventArgs e)
        {
            OnTakePhotoClicked();
        }

        private void SelectPhotoButton_Clicked(object sender, EventArgs e)
        {
            OnSelectPhotoClicked();
        }
    }
}
