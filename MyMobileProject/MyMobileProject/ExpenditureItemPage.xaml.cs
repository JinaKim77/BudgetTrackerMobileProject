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

        
        async void Button_Clicked(object sender, EventArgs e)  //save
        {
        
            bool isCategoryEnpty, isValueEmpty;
            isCategoryEnpty = String.IsNullOrEmpty(entryCategory.Text);
            isValueEmpty = String.IsNullOrEmpty(EntryValue.Text);

            if (isCategoryEnpty || isValueEmpty)
            {
                await DisplayAlert("Error", "You have to type category and amount", "OK");
            }
            else
            {
                var expenditureItem = (ExpenditureItem)BindingContext;
                await App.Database.SaveItemAsync(expenditureItem);
                await App.Database.SaveItemAsyncs(expenditureItem);
                await Navigation.PopAsync();
                await DisplayAlert("Success", "All Vaues stored", "OK");
            }
        }

        async void Button_Clicked_1(object sender, EventArgs e)  //delete
        {


            bool isCategoryEnpty, isValueEmpty;
            isCategoryEnpty = String.IsNullOrEmpty(entryCategory.Text);
            isValueEmpty = String.IsNullOrEmpty(EntryValue.Text);

           
            if (isCategoryEnpty || isValueEmpty )
            {
                await DisplayAlert("Error", "delete what? ", "OK");
            }
            else
            {
                var expenditureItem = (ExpenditureItem)BindingContext;
                await App.Database.DeleteItemAsync(expenditureItem);
                await DisplayAlert("Success", "All Vaues delete", "OK");
                await Navigation.PopAsync();
            }
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