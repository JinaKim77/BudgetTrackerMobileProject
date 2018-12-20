using MyMobileProjec;
using System;
using Xamarin.Forms;


namespace MyMobileProject
{
	public partial class ExpenditureItemPage : ContentPage
	{

        public ExpenditureItemPage ()
		{
			InitializeComponent ();
    
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (ExpenditureItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (ExpenditureItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void OnSpeakClicked(object sender, EventArgs e)
        {
            var todoItem = (ExpenditureItem)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        }
    }
}
