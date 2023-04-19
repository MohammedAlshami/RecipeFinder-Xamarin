﻿using Recipe.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());//Very important add this..

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
