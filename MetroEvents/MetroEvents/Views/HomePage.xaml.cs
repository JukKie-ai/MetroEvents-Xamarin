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
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
        }
        async void AddEvent_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new AddEvent());
        }

        async void ViewEvent_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new ViewEvent());
        }

        async void Logout_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new LoginPage());
        }


    }
}