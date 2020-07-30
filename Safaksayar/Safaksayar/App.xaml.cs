using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Safaksayar.Views;
using Safaksayar.Models;
using Realms;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace Safaksayar
{
    public partial class App : Application
    {

        public static Realm RealmContext;
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental" });
            InitializeComponent();

            var config = new RealmConfiguration() { SchemaVersion = 4 };

            RealmContext = Realm.GetInstance(config);
            var userSelectedCulture = new CultureInfo("tr-TR");

            Thread.CurrentThread.CurrentCulture = userSelectedCulture;

            MainPage = new MainPage();
            
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            var userSelectedCulture = new CultureInfo("tr-TR");

            Thread.CurrentThread.CurrentCulture = userSelectedCulture;
        }
    }
}
