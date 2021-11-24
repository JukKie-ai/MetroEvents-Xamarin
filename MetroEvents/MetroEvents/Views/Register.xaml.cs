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
    public partial class Register : ContentPage {
        public Register() {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbPath);

            db.CreateTable<RegisterUserTable>();

            var item = new RegisterUserTable() {
                Username = EntryUsername.Text,
                Password = EntryPassword.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Success", "User Registration Successfull!", "OK", "Cancel");

                if(result) {
                    await Navigation.PushAsync(new LoginPage());
                }
            });
        }

        async void Login_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}