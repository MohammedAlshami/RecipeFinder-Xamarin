using Firebase.Database;
using Firebase.Database.Query;
using Recipe.Models.User;
using Recipe.Views.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private UploadPage upload;
        public ProfilePage()
        {
            InitializeComponent();
            upload= new UploadPage();
            SetUserInfo();

        }
        public async void SetUserInfo()
        {
            // Get a reference to the Firebase Realtime Database
            var firebase = new FirebaseClient("https://realtimedatabasetest-f226a-default-rtdb.asia-southeast1.firebasedatabase.app/");

            // Query the database for the user with the specified email address
            var users = await firebase
                .Child("Users")
                .OrderBy("Email")
                .EqualTo(((App)Application.Current).UserEmail)
                .OnceAsync<Users>();
            Console.WriteLine("Shamsi: " + ((App)Application.Current).UserEmail + "/ " + users.Count);
            // If the user is found, set the values in the XAML code
            var user = users.FirstOrDefault()?.Object;
            if (user != null)
            {
                FullName.Text = user.Name;
                userName.Text = user.Username;
                profile_picture.Source = user.Image;
            }
        }

        private void ProfileFrame_Tapped(object sender, EventArgs e)
        {
            // Handle profile setting frame tapped
        }

        private void UserManagementFrame_Tapped(object sender, EventArgs e)
        {
            // Handle user management frame tapped
        }
        private async void UploadFrame_Tapped(object sender, EventArgs e)
        {
            // Handle upload frame tapped
            // Code to handle the frame click event
            await Navigation.PushAsync(upload);
        }


        private void LogoutFrame_Tapped(object sender, EventArgs e)
        {
            // Handle logout frame tapped
        }
    }
}
