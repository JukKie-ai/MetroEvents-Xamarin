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
    public partial class ViewEvent : ContentPage {

        private ListView lV;
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
        public ViewEvent() {
            InitializeComponent();

            var db = new SQLiteConnection(dbPath);

            StackLayout stackLayout = new StackLayout();
            lV = new ListView();
            lV.ItemsSource = db.Table<Event>().OrderBy(x => x.Name).ToList();
            stackLayout.Children.Add(lV);

            Content = stackLayout;
        }
    }
}