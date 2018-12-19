﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyMobileProjec;

namespace MyMobileProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class ExpenditureItemListPage : ContentPage
	{
		public ExpenditureItemListPage ()
		{
			InitializeComponent ();

            
        }

        public void getTotalExpenses()
        {
            

            double total = 0;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }


        // work when toolbar item checked
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenditureItemPage
            {
                BindingContext = new ExpenditureItem()
            });
        }


        //when item is selected
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenditureItemPage
                {
                    BindingContext = e.SelectedItem as ExpenditureItem
                });
            }
        }

        

        private void AddExpenditure_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ExpenditureItemPage());
        }

       
    }
}