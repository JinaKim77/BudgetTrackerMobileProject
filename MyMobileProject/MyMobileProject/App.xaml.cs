using MyMobileProjec;
using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyMobileProject
{
    public partial class App : Application
    {
        static ExpenditureItemDatabase database;

        public App()
        {
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("CadetBlue"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.CadetBlue, BackgroundColor = Color.Olive, BarTextColor = Color.White, Title = "Hello" };
            //nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            //nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static ExpenditureItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExpenditureItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
