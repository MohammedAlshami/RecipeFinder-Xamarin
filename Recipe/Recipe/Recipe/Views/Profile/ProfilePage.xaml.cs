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
        }

        private void ProfileFrame_Tapped(object sender, EventArgs e)
        {
            // Handle profile setting frame tapped
        }

        private void UserManagementFrame_Tapped(object sender, EventArgs e)
        {
            // Handle user management frame tapped
        }
        private void UploadFrame_Tapped(object sender, EventArgs e)
        {
            // Handle upload frame tapped
            // Code to handle the frame click event
            Navigation.PushAsync(upload);
        }


        private void LogoutFrame_Tapped(object sender, EventArgs e)
        {
            // Handle logout frame tapped
        }
    }
}
