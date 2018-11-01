using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RatingSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestRateStar : ContentPage
    {
        public List<Image> ListOfButtons { get; set; } = new List<Image>();
        public int Count { get; set; } = 0;
        public int index { get; set; } = 8;


        public TestRateStar()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Handle when your app starts

            for (var i = 0; i < index; i++)
            {
                ListOfButtons.Add(new Image()
                {
                    StyleId = i.ToString(),
                    HeightRequest = 40,                   
                    WidthRequest = 50,
                    BackgroundColor = Color.White
                });
                Grid.SetColumn(ListOfButtons[i], i);


                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
                ListOfButtons[i].GestureRecognizers.Add(tapGestureRecognizer);


                xGrid.Children.Add(ListOfButtons[i]);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Count++;
            var imageSender = (Image)sender;

            var index = Convert.ToInt32(imageSender.StyleId.ToString());
            for (var i = 0; i < index + 1; i++)
            {
                //Oranje
                ListOfButtons[i].Source = "DroidLightOrange.png";
                ListOfButtons[i].BackgroundColor = Color.Orange;          
            }

            for (var i = index + 1; i < 8; i++)
            {
                //Grijs
                ListOfButtons[i].Source = "DroidWit.png";
                ListOfButtons[i].BackgroundColor = Color.White;            
            }
        }
    }
}