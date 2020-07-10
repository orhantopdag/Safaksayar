using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Safaksayar.Models;
using Safaksayar.Views;
using System.Threading;
using Realms;
using System.Linq;

namespace Safaksayar.ViewModels
{
    public class ItemsViewModel :BaseViewModel
    {

        private Bilgiler bilgiler;
        public Bilgiler Bilgiler
        {
            get { return bilgiler; }
            set { bilgiler = value; OnPropertyChanged();
            }
        }
      

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
           
          

            //var realm = Realm.GetInstance();
           
           
            Bilgiler = App.RealmContext.All<Bilgiler>().FirstOrDefault();

           
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                dt = DateTime.Now;
                TimeText = (gh - dt).ToString();
                return true;
            });

            //MessagingCenter.Subscribe<NewItemPage, Bilgiler>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Bilgiler;
            //    Items.Add(newItem);
            //    //realm.Add(new Bilgiler { ad = item.ad, memleket = item.memleket });
            //    App.RealmContext.Write(() =>
            //    {
            //        var B = new Bilgiler();
            //        B.Ad = item.Ad;
            //        B.Memleket = item.Memleket;
            //        App.RealmContext.Add(B);
            //    });

            //});
        }

        async Task ExecuteLoadItemsCommand()
        {
            //IsBusy = true;

          
            //Bilgiler.Clear();


            

            //var items = App.RealmContext.All<Bilgiler>();
          
            //foreach (var item in items)
            //{
            //    Bilgiler.Add(item);
            //}
         
        }




        private string textDate;
        DateTime dt;
        DateTime gh = new  DateTime(2020, 1, 12);
      
        public string TimeText
        {
            get { return textDate; }
            set { textDate = value; OnPropertyChanged(); }
        }





    }
}