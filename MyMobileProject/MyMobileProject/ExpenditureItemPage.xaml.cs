using MyMobileProjec;
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

	public partial class ExpenditureItemPage : ContentPage
	{

        public bool ShouldReactToTextChanges { get; set; }


        public ExpenditureItemPage ()
		{
			InitializeComponent ();
            ShouldReactToTextChanges = true;

        }

        private int i;
        async void Button_Clicked(object sender, EventArgs e)  //save
        {
            var expenditureItem = (ExpenditureItem)BindingContext;
            await App.Database.SaveItemAsync(expenditureItem);
            await DisplayAlert("Success", "All Vaues stored", "OK");
            await Navigation.PopAsync();



        }

        async void Button_Clicked_1(object sender, EventArgs e)  //delete
        {
            var expenditureItem = (ExpenditureItem)BindingContext;
            await App.Database.DeleteItemAsync(expenditureItem);
            await DisplayAlert("Success", "All Vaues delete", "OK");
            await Navigation.PopAsync();
        }

        async void Button_Clicked_2(object sender, EventArgs e)  //cancel
        {
            await Navigation.PopAsync();
        }

        void Button_Clicked_3(object sender, EventArgs e)  //speak
        {
            var expenditureItem = (ExpenditureItem)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(expenditureItem.Name + " " + expenditureItem.Notes);
            
        }

        public static int DumbParse(string input)
        {
            if (input == null) return 0;

            var number = 0;
            int multiply = 1;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(input[i]))
                {
                    number += (input[i] - '0') * (multiply);
                    multiply *= 10;
                }
            }
            return number;
        }

        public static void ConvertNumber(int value)
        {
            string number = value.ToString().Replace(",", "").Replace(".", "");
            if (number.Equals(""))
                number = "000";

            number = number.PadLeft(3, '0');
            if (number.Length > 3 && number.Substring(0, 1).Equals("0"))
            {
                number = number.Substring(1, number.Length - 1);
            }

            double finalValue = Convert.ToDouble(number) / 100;

            //return string.Format(new CultureInfo("en-US"), "{0:N}", finalValue);
        }
        
    }
}