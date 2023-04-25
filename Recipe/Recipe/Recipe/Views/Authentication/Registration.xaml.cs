using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
/*using Recipe.Views.Authentication;
*/
namespace Recipe.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        AuthenticationHelper authenticationHelper;
        public Registration()
        {
            InitializeComponent();
            authenticationHelper = new AuthenticationHelper();
        }

        private void OnSignInTapped(object sender, EventArgs e)
        {
            signinConfig();
        }
        private void signinConfig()
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
            register_loginButton.IsVisible = true;
            register_signupButton.IsVisible = false;
            signupuserEmail.Text = "";
            signupuserPassword.Text = "";
            userConfirmPassword.Text = "";
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
            loginuserEmail.Text = "";
            loginuserPassword.Text = "";
            register_loginButton.IsVisible = false;
            register_signupButton.IsVisible = true;



        }

        private void OnForgotPasswordTapped(object sender, EventArgs e)
        {
            // Handle forgot password tapped event
        }

        private async void OnLoginButtonTapped(object sender, EventArgs e)
        {
            // Handle login button tapped event
            Console.WriteLine("Sign button invoked");

            string errorMessage = await authenticationHelper.SignInWithEmailPassword(loginuserEmail.Text, loginuserPassword.Text);
            if (errorMessage != null)
            {
                await DisplayAlert("Error", errorMessage, "OK");
            }

            Console.WriteLine("invoked_sign");
        }

        private async void OnSignupButtonTapped(object sender, EventArgs e)
        {
            // Handle login button tapped event
            Console.WriteLine("Sign up button invoked");

            // Check password length
            if (signupuserPassword.Text.Length < 6)
            {
                await DisplayAlert("Error", "Password must be at least 6 characters long", "OK");
                return;
            }

            // Check email format
            if (!IsValidEmail(signupuserEmail.Text))
            {
                await DisplayAlert("Error", "Invalid email address", "OK");
                return;
            }

            // Check password match
            if (signupuserPassword.Text != userConfirmPassword.Text)
            {
                await DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }

            string errorMessage = await authenticationHelper.RegisterWithEmailPassword(signupuserEmail.Text, signupuserPassword.Text);

            if (errorMessage != null)
            {
                await DisplayAlert("Error", errorMessage, "OK");
                signinConfig();
            }

            Console.WriteLine("invoked_sign");
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}
