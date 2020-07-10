using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Safaksayar.Views;
using Safaksayar.Models;
using Realms;
using System.Linq;

namespace Safaksayar
{
    public partial class App : Application
    {

        public static Realm RealmContext;
        public App()
        {

            InitializeComponent();

            var config = new RealmConfiguration() { SchemaVersion = 4 };

            RealmContext = Realm.GetInstance(config);
           
           
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
        }
    }
}
