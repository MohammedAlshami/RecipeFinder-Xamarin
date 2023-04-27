using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Me : Popup
    {
        public Me()
        {
            InitializeComponent();
        }
        private void OnFrameTapped(object sender, EventArgs e)
        {
            string url = "https://github.com/MohammedAlshami"; // replace with your URL
            Device.OpenUri(new Uri(url));
        }

    }
}