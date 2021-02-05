using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Safaksayar.Models;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using Safaksayar.Dto;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Safaksayar.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        Fikralarhepsi _fikralar;
        Bilgiler BilgilerModel { get; set; }
        public MainPage()

        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            if (!App.RealmContext.All<Fikra>().Any())
            {
                FillJokes();
            }
            if (!App.RealmContext.All<Bilgiler>().Any())
            {
                this.Navigation.PushModalAsync(new NavigationPage(new BilgiGir()));
                //Xamarin.Forms.Device.BeginInvokeOnMainThread(async () => {
                //    await Navigation.PushModalAsync(new NavigationPage(new BilgiGir()));
                

                //});
            }
            

            else
            {
                BilgilerModel = App.RealmContext.All<Bilgiler>().FirstOrDefault();
            }

           
        }

      

        private void FillJokes()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fikralar.xml");

            var assembly = typeof(MainPage).GetTypeInfo().Assembly;

            Stream stream2 = this.GetType().Assembly.
               GetManifestResourceStream("Safaksayar." + "Fikralar.xml");

           



            if (Device.OS == TargetPlatform.Android) {
                var folderPath = DependencyService.Get<IFileSystem>().GetExternalStorage();
                var folderPath2 = DependencyService.Get<IFileSystem>().GetExternalStorage2();

                var filepath = Path.Combine(folderPath2, "Fikralar.xml");

                using ( System.IO.StreamReader reader = new System.IO.StreamReader(filepath))
                {
                    XmlSerializer serializer2 = new XmlSerializer(typeof(Fikralarhepsi));
                    _fikralar= (Fikralarhepsi)serializer2.Deserialize(reader);
                }
            }
            else
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream2))
                {
                    XmlSerializer serializer2 = new XmlSerializer(typeof(Fikralarhepsi));
                    _fikralar = (Fikralarhepsi)serializer2.Deserialize(reader);
                }

            }



            //FileStream fileStream = new FileStream(filePath, FileMode.Open);
            //XmlSerializer serializer = new XmlSerializer(typeof(Fikralarhepsi));
            //var k = (Fikralarhepsi)serializer.Deserialize(fileStream);

            //fileStream.Close();


            App.RealmContext.Write(() =>
            {
                int nextID = 0;
                foreach (var item in _fikralar.Fikralar)
                {
                    if (!App.RealmContext.All<Fikra>().Any())
                    {
                        nextID = 0;
                    }
                    else
                    {
                        nextID = (int)(App.RealmContext.All<Fikra>().ToList().Max(x => x.Id)) + 1;
                    }
                    

                    Fikra f = new Fikra {Id=nextID, FikraAdi = item.FikraAdi, FikraIcerigi = item.FikraIcerigi };


                    App.RealmContext.Add(f);
                }


            });
        }

        //public async Task NavigateFromMenu(int id, MenuPage x)
        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Updater:

                        MenuPages.Add(id, new NavigationPage(new  BilgiGir(BilgilerModel)));
                        break;

                    case (int)MenuItemType.fikra:

                        MenuPages.Add(id, new NavigationPage(new FikralarPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);
                //x.ListViewMenu.SelectedItem = x.ListViewMenu.ItemsSource.OfType<HomeMenuItem>().ToList()[id];
                IsPresented = false;
            }
        }
    }
}