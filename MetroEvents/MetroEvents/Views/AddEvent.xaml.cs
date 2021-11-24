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
    public partial class AddEvent : ContentPage {
        public AddEvent() {
            InitializeComponent();
        }

        private void AddEvent_Clicked(object sender, EventArgs e) {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dbPath);

            var user = Application.Current.Properties["theUser"].ToString();

            db.CreateTable<Event>();

            var item = new Event() {
                Name = entryEName.Text,
                Address = entryAName.Text,
                Date = entryDName.Text,
                User = user,
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () => {
                var result = await this.DisplayAlert("Success", "Event Added Successfull!", "OK", "Cancel");

                if (result) {
                    await Navigation.PushAsync(new HomePage());
                }
            });
        }

        async void GoBack_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new HomePage());
        }
    }
}