using Recipe.Views.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigation : Shell
    {
        public BottomNavigation()
        {
            InitializeComponent();

        }
    }
}