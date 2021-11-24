using MetroEvents.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MetroEvents.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e) {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbPath);

            var myquery = db.Table<RegisterUserTable>().Where(u => u.Username.Equals(EntryUsername.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

            if(myquery != null) {
                Application.Current.Properties["theUser"] = EntryUsername.Text;
                App.Current.MainPage = new NavigationPage(new HomePage());
            } else {
                Device.BeginInvokeOnMainThread(async () => {
                    var result = await this.DisplayAlert("Error", "User Not Found", "OK", "Cancel");

                    if (result) {
                        await Navigation.PushAsync(new LoginPage());
                    } else {
                        await Navigation.PushAsync(new LoginPage());
                    }
                });
            }
        }
        async void Register_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Register());
        }
    }
}