using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
using Recipe.Views.Upload;
using Recipe.Views.Navigation;
/*using Recipe.Views.Authentication;
*/
namespace Recipe.Views.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        AuthenticationHelper authenticationHelper;
        BottomNavigation _bottomNavigation;
        public Registration()
        {
            InitializeComponent();
            authenticationHelper = new AuthenticationHelper();
            _bottomNavigation = new BottomNavigation();
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
            /*            ShellNavigationState state = Shell.Current.GoToAsync(new BottomNavigation());
            */
      

            // Navigate to the BottomNavigation page using the Shell Navigation API
            Console.WriteLine("Sign button invoked");

            bool errorMessage = await authenticationHelper.SignInWithEmailPassword(loginuserEmail.Text, loginuserPassword.Text);
            if (errorMessage == false)
            {
                await DisplayAlert("Error", "Wrong Email or Password. Try Again!!", "OK");
                loginuserEmail.Text = "";
                loginuserPassword.Text = "";
            }
            else
            {
                Console.WriteLine("invoked_sign");
                ((App)Application.Current).UserEmail = loginuserEmail.Text;
                try
                {
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                catch (Exception ex)
                {
                    // Handle the exception here
                    Console.WriteLine($"Exception while navigating to BottomNavigation page: {ex.Message}");
                }

            }



        }

        private async void OnSignupButtonTapped(object sender, EventArgs e)
        {
            // Handle login button tapped event
            Console.WriteLine("Sign up button invoked");



            // Check email format
            if (!IsValidEmail(signupuserEmail.Text))
            {
                await DisplayAlert("Error", "Invalid email address", "OK");
                signupuserEmail.Text = "";
                signupuserPassword.Text = "";
                userConfirmPassword.Text = "";
                return;
            } else
            {
                // Check password length
                if (signupuserPassword.Text.Length < 6)
                {
                    await DisplayAlert("Error", "Password must be at least 6 characters long", "OK");
                    signupuserPassword.Text = "";
                    userConfirmPassword.Text = "";
                    return;
                } else
                {
                    // Check password match
                    if (signupuserPassword.Text != userConfirmPassword.Text)
                    {
                        await DisplayAlert("Error", "Passwords do not match", "OK");
                        userConfirmPassword.Text = "";

                        return;
                    }
                }


            }

      
       


            bool errorMessage = await authenticationHelper.RegisterWithEmailPassword(signupuserEmail.Text, signupuserPassword.Text);

     
            if (errorMessage == false)
            {
                await DisplayAlert("Error", "Email Already Exist. Try another email!!", "OK");

            }
            else
            {
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
