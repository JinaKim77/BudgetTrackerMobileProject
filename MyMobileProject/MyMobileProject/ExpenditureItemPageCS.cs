using MyMobileProjec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyMobileProject
{
	public class ExpenditureItemPageCS : ContentPage
	{
		public ExpenditureItemPageCS ()
		{
            Title = "expenditure Item";

           

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var expenditureItem = (ExpenditureItem)BindingContext;
                await App.Database.SaveItemAsync(expenditureItem);
                await Navigation.PopAsync();


            };



            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var expenditureItem = (ExpenditureItem)BindingContext;
                await App.Database.DeleteItemAsync(expenditureItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            var speakButton = new Button { Text = "Speak" };
            speakButton.Clicked += (sender, e) =>
            {
                var expenditureItem = (ExpenditureItem)BindingContext;
                DependencyService.Get<ITextToSpeech>().Speak(expenditureItem.Name + " " + expenditureItem.Notes);
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton,
                    speakButton
                }
            };
        }
    }
}
