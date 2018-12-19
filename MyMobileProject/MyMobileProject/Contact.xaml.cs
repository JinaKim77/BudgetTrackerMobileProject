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
	public partial class Contact : ContentPage
	{
		public Contact ()
		{
			InitializeComponent ();
		}

        private void BtnStore_Clicked(object sender, EventArgs e)
        {
            // Store all  Values  
            Application.Current.Properties["ID"] = txtId.Text;
            Application.Current.SavePropertiesAsync();

            Application.Current.Properties["Name"] = txtName.Text;
            Application.Current.SavePropertiesAsync();

            Application.Current.Properties["IsMVP"] = switch1.IsToggled;
            //string line = string.Format("{0},{1}", txtId.Text, txtName.Text);

            //for retriving saved value
            //var currentuserID = (Application.Current.Properties["ID"].ToString());
            //var currentuserName = (Application.Current.Properties["Name"].ToString());
            //Navigation.PushAsync(new Member(currentuserID, currentuserName));


            //clear out the boxes
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;

            //display when clicked
            DisplayAlert("Success", "All Vaues stored", "OK");

            //Navigation.PushAsync(new LogIn());

            //svae values to members page
            //Navigation.PushAsync(new DisplayAll(txtId.Text));



            //member.Add(new Member(txtId.Text, txtName.Text));

            //store the information!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //// var fileName = Path.Combine(documents,"Mycontacts.txt");
            //File.WriteAllText(fileName,line);
        }

        private void Switch1_Toggled(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["IsMVP"] = switch1.IsToggled;
        }


        private void BtnGet_Clicked(object sender, EventArgs e)
        {
            //Get all Values  
            if (Application.Current.Properties.ContainsKey("ID"))
            {

                lblId.Text = Application.Current.Properties["ID"].ToString();
                lblName.Text = Application.Current.Properties["Name"].ToString();
                lblIsMVP.Text = Application.Current.Properties["IsMVP"].ToString();

            }

            // Navigation.PushAsync(new Member(lblId.Text, lblName.Text));
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            //Remove all Properties  
            if (Application.Current.Properties.ContainsKey("ID"))
            {
                Application.Current.Properties.Remove("ID");
                Application.Current.Properties.Remove("Name");
                Application.Current.Properties.Remove("IsMVP");
                ClearAll();
                DisplayAlert("Success", "All Vaues Removed", "OK");
            }
        }

        public void ClearAll()
        {
            lblId.Text = string.Empty;
            lblName.Text = string.Empty;
            lblIsMVP.Text = string.Empty;
        }

        private void BtnRemove_Clicked(object sender, EventArgs e)
        {
            //Clear all Properties  
            Application.Current.Properties.Clear();
            ClearAll();
            DisplayAlert("Success", "All Vaues Cleared", "OK");
        }
    }
}