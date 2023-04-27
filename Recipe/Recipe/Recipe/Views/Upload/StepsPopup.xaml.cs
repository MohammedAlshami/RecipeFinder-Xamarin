using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class StepsPopup : Popup
    {
        private List<string> stepsList;


        public StepsPopup(List<string> steps)
        {
            InitializeComponent();
            stepsList = steps;
            DisplayStepsList();
        }
        private void AddStepButton_Clicked(object sender, EventArgs e)
        {
            string newStep = StepsEntry.Text;
            if (!string.IsNullOrEmpty(newStep))
            {
                stepsList.Add(newStep);
                StepsEntry.Text = "";
                DisplayStepsList();
            }
        }

        private void DisplayStepsList()
        {
            StepsListStackLayout.Children.Clear();

            var stepCount = 1;
            foreach (string step in stepsList)
            {
                var label = new Label
                {
                    Text = (stepCount++) + ". " + step,
                    FontSize = 15,
                    Margin = new Thickness(10, 5),
                    Padding = new Thickness(10, 5),
                    TextColor = Color.Black
                };

                var deleteButton = new ImageButton
                {
                    Source = "step_remove_red",
                    WidthRequest = 30,
                    HeightRequest = 30,
                    BackgroundColor = Color.Transparent,
                    Margin = new Thickness(10, 5)
                };
                deleteButton.Clicked += (sender, e) =>
                {
                    var button = (ImageButton)sender;
                    var frame_1 = (Frame)button.Parent.Parent;
                    var content = frame_1.Content;

                    if (content is Grid grid1)
                    {
                        var label1 = (Label)grid1.Children[0];
                        string[] parts = label1.Text.Split(new char[] { ' ' }, 2);
                        string resultString = parts[1];
                        stepsList.Remove(resultString);
                        StepsListStackLayout.Children.Remove(frame_1);
                    }
                };
                var grid = new Grid
                {
                    ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = GridLength.Auto }
            }
                };
                grid.Children.Add(label, 0, 0);
                grid.Children.Add(deleteButton, 1, 0);

                var frame = new Frame
                {
                    Content = grid,
                    Margin = new Thickness(10),
                    Padding = new Thickness(10),
                    HasShadow = true,
                    CornerRadius = 10
                };

                StepsListStackLayout.Children.Add(frame);
            }
        }

        void OnCloseButtonClick(object sender, EventArgs e)
        {
            Dismiss(stepsList);
        }
    }
}