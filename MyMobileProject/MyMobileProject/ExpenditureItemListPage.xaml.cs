using MyMobileProjec;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace MyMobileProject
{
	
	public partial class ExpenditureItemListPage : ContentPage
	{
		public ExpenditureItemListPage ()
		{
			InitializeComponent ();

            
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenditureItemPage
            {
                BindingContext = new ExpenditureItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenditureItemPage
                {
                    BindingContext = e.SelectedItem as ExpenditureItem
                });
            }
        }

    }
}
