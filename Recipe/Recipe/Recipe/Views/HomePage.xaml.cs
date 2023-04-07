using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public HomePage()
        {
            InitializeComponent();
        }

        private void ChangeFrameHeight(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = true;
            HomeSearchOption.IsVisible = true;
            homeSearchFrame.WidthRequest = 290;
            homeSearchFrame.Margin = new Thickness(0, 25, 25, 10);
            HomeComponents.IsVisible = false;

        }

        private void backBtn(object sender, EventArgs e)
        {

            SearchBackBtn.IsVisible = false;
            HomeSearchOption.IsVisible = false;
            homeSearchFrame.WidthRequest = 340;
            homeSearchFrame.Margin = new Thickness(25, 25, 25, 10);
            HomeComponents.IsVisible = true;

        }
        private void SearchRecipes(object sender, EventArgs e)
        {
            HomeSearchOption.IsVisible = false;

        }



    }
}
