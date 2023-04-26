using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Xamarin.Forms;
using Firebase.Auth.Repository;
using Firebase.Database;
using Recipe.Models.Recipes;
using Recipe.Models.User;

using Firebase.Database.Query;
using System.Linq;
using Firebase.Storage;
using System.Xml;

namespace Recipe.Views.Authentication
{
    public class AuthenticationHelper
    {

        string webAPIKey = "AIzaSyBLv1DiRB6egmpaoIKfjODXZF5fYheQKIM";
        FirebaseAuthClient authProvider;

        FirebaseClient firebase = new FirebaseClient("https://realtimedatabasetest-f226a-default-rtdb.asia-southeast1.firebasedatabase.app/");

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
        public async Task<bool> SignInWithEmailPassword(string email, string password)
        {
            try
            {
                // Authenticate with Firebase 
                await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                // Sign-in failed
                string errorMessage = $"Sign-in failed: {ex.Message}";
                Console.WriteLine(errorMessage);
                return false;
            }
        }

        public async Task<bool> RegisterWithEmailPassword(string email, string password)
        {
            try
            {
                // Create a new user with the email and password
                await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                // Registration succeeded
                Console.WriteLine("User registration successful");
                await AddUser(email);
                return true;
            }
            catch (Exception ex)
            {
                // Registration failed
                string errorMessage = $"Registration failed: {ex.Message}";
                Console.WriteLine(errorMessage);
                return false;
            }
        }
        public async Task AddUser(string email)
        {
            // Generate random username and name
            string username = RandomString(8);
            string name = RandomString(10);
            string imageUrl = await GetRandomImageUrlFromStorageAsync();
            var user = new Users
            {
                Email = email,
                Name = name,
                Username = username,
                Image = imageUrl // Add code to set the user's profile picture
            };

            await firebase
                .Child("Users")
                .PostAsync(user);
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task<string> GetRandomImageUrlFromStorageAsync()
        {
            var dummyImageUrls = new List<string>
    {
                "https://dummyimage.com/600x400/000/fff",
                "https://dummyimage.com/600x400/00ff00/000",
                "https://dummyimage.com/600x400/ff0000/fff",
                "https://dummyimage.com/600x400/0000ff/fff"
            };

            var random = new Random();
            string imageUrl = dummyImageUrls[random.Next(dummyImageUrls.Count)];
            return imageUrl;
        }



    }

}
