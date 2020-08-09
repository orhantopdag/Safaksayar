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

        Bilgiler BilgilerModel { get; set; }
        public MainPage()

        {
            InitializeComponent();
        
            MasterBehavior = MasterBehavior.Popover;


            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fikralar.xml");
            //List<FikraDto> list = new List<FikraDto>();
            //list.Add(new FikraDto {FikraAdi="sdfsd",FikraIcerigi="asuhgfkjsdbk" });
            //list.Add(new FikraDto { FikraAdi = "sdgfsdhsd", FikraIcerigi = "sdfagafdh" });
            //list.Add(new FikraDto { FikraAdi = "jjguy", FikraIcerigi = "tdthdu" });
            //Fikralarhepsi sdf = new Fikralarhepsi();
            //sdf.Fikralar = list;
            //FileStream fileStream = new FileStream(filePath, FileMode.Create);


            //XmlSerializer serializer = new XmlSerializer(typeof(Fikralarhepsi));
            //serializer.Serialize(fileStream, sdf);
            ////BinaryFormatter bf = new BinaryFormatter();
            ////bf.Serialize(fileStream, list);
            //fileStream.Close();
            string resPrefix = "";
            if (Device.OS == TargetPlatform.iOS) { }

else if (Device.OS == TargetPlatform.Android)
            {

            }

            else if (Device.OS == TargetPlatform.Windows)
            {
                resPrefix = "Safaksayar.UWP";
            }
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            
            Stream stream2 = this.GetType().Assembly.
               GetManifestResourceStream("Safaksayar." + "Fikralar.xml");
            
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream2))
            {
               XmlSerializer serializer2 = new XmlSerializer(typeof(Fikralarhepsi));
               var sounds = (Fikralarhepsi)serializer2.Deserialize(reader);
            }

            FileStream fileStream = new FileStream(filePath, FileMode.Open);
         XmlSerializer serializer = new XmlSerializer(typeof(Fikralarhepsi));
           var k= (Fikralarhepsi)serializer.Deserialize(fileStream);
            //Debug.WriteLine("1st Item: " + list[0] + "\n2nd Item: " + list[1]);
            fileStream.Close();


            //MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
            if (!App.RealmContext.All<Fikra>().Any())
            {
                //XmlSerializer serializer = new XmlSerializer(typeof(Fikralarhepsi));
                string path = Assembly.GetExecutingAssembly() + "\\Fikralar.xml";

             
                using (Stream reader = new FileStream("Fikralar.xml", FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                  //  var k = (Fikralarhepsi)serializer.Deserialize(reader);
                }

                //using (TextReader reader = new StringReader("Fikralar.xml"))
                //{
                //    Fikralarhepsi result = (Fikralarhepsi)serializer.Deserialize(reader);
                //}

                //Assembly assembly = typeof(App).GetTypeInfo().Assembly;
                //Stream stream = assembly.GetManifestResourceStream("Fikralar.xml");
                TextReader reader2 = new StringReader("Fikralar.xml");

           
                //System.IO.StreamReader reader = new System.IO.StreamReader(stream);
                //List<FikraDto> sounds;
                //using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                //{
                //    XmlSerializer serializer = new XmlSerializer(typeof(List<FikraDto>));
                //    sounds = (List<FikraDto>)serializer.Deserialize(reader);
                //}

                //if (sounds == null)
                //{
                //    sounds = new List<FikraDto>();
                //}

                //XmlSerializer serializer = new XmlSerializer(typeof(Fikralarhepsi));
                var root = (Fikralarhepsi)serializer.Deserialize(reader2);
                var sounds = root == null ? new List<FikraDto>() : root.Fikralar;

                App.RealmContext.Write(() =>
                {


                    //Fikra f =
                   

                    //App.RealmContext.Add(f);
                });
            }


            if (!App.RealmContext.All<Bilgiler>().Any())
            {
                this.Navigation.PushModalAsync(new NavigationPage(new BilgiGir()));
            }
            else
            {
                BilgilerModel = App.RealmContext.All<Bilgiler>().FirstOrDefault();
            }
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