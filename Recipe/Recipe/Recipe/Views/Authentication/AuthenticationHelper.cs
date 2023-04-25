using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Xamarin.Forms;
using Firebase.Auth.Repository;

namespace Recipe.Views.Authentication
{
    public class AuthenticationHelper
    {

        string webAPIKey = "AIzaSyBLv1DiRB6egmpaoIKfjODXZF5fYheQKIM";
        FirebaseAuthClient authProvider;
        public AuthenticationHelper()
        {
            // Initialize Firebase with your web API key
            try
            {
                authProvider = new FirebaseAuthClient(new FirebaseAuthConfig()
                {
                    ApiKey = webAPIKey,
                    AuthDomain = "realtimedatabasetest-f226a.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
               
                        new EmailProvider()
                        // ...
                        }
                });

            } catch(Exception ex)
            {
                Console.WriteLine($"Authentication failed: {ex.Message}");

            }
        }
        public async Task<string> SignInWithEmailPassword(string email, string password)
        {
            try
            {
                // Authenticate with Firebase 
                await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return "User account has been logged in Successfully";
            }
            catch (Exception ex)
            {
                // Sign-in failed
                string errorMessage = $"Sign-in failed: {ex.Message}";
                Console.WriteLine(errorMessage);
                return errorMessage;
            }
        }

        public async Task<string> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                // Create a new user with the email and password
                await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                // Registration succeeded
                Console.WriteLine("User registration successful");
                return "Successful registeration";
            }
            catch (Exception ex)
            {
                // Registration failed
                string errorMessage = $"Registration failed: {ex.Message}";
                Console.WriteLine(errorMessage);
                return errorMessage;
            }
        }






    }

}
