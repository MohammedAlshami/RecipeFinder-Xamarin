using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void OnSignInTapped(object sender, EventArgs e)
        {
            register_signin.IsEnabled = false;
            register_signup.IsEnabled = true;
            register_signin.Children[1].IsVisible = true;
            register_signup.Children[1].IsVisible = false;
            signin_name.TextColor = Color.White;
            signup_name.TextColor = Color.Default;
            register_loginFrame.IsVisible = true;
            register_signupFrame.IsVisible = false;
            register_forgot.IsVisible = true;
            registerBtnLabel.Text = "Sign In";


        }

        private void OnSignUpTapped(object sender, EventArgs e)
        {
            register_signin.IsEnabled = true;
            register_signup.IsEnabled = false;
            register_signin.Children[1].IsVisible = false;
            register_signup.Children[1].IsVisible = true;
            signin_name.TextColor = Color.Default;
            signup_name.TextColor = Color.White;
            register_loginFrame.IsVisible = false;
            register_signupFrame.IsVisible = true;
            register_forgot.IsVisible = false;
            registerBtnLabel.Text = "Sign Up";




        }

        private void OnForgotPasswordTapped(object sender, EventArgs e)
        {
            // Handle forgot password tapped event
        }

        private void OnLoginButtonTapped(object sender, EventArgs e)
        {
            // Handle login button tapped event
        }
    }
}
