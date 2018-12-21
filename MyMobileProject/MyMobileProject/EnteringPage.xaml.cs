using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMobileProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnteringPage : ContentPage
    {
        public EnteringPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            bool isUserEmpty;
            isUserEmpty = String.IsNullOrEmpty(Name.Text);

            string dateString = DateTime.Today.ToShortDateString();
            string str = "Hello " + Name.Text + ". Today is " + dateString + ".";
            str += " How are you today?";

            if (isUserEmpty)
            {
                DisplayAlert("Error", "You have to tell me your name", "Good luck");
            }

            else
            {
                DisplayAlert("Welcome", str, "OK");
                Navigation.PushAsync(new MainPage());
            }
        }
    }
}