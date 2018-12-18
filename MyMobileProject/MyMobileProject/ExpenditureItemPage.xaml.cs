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
		public ExpenditureItemPage ()
		{
			InitializeComponent ();

          
		}

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
    }
}