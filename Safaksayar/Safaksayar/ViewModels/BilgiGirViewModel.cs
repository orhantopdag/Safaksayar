
using Safaksayar.Models;
using Safaksayar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Safaksayar.ViewModels
{
    public class ComboObject
    {
        public string yazisi { get; set; }
        public int sayisi { get; set; }
        public ComboObject()
        {

        }
        public ComboObject(string yazi,int sayi)
        {
         
            yazisi = yazi;
            sayisi = sayi;
        }

      
    }

  public  class BilgiGirViewModel : BaseViewModel
    {

        private Bilgiler Bg;
        public ICommand KaydetCommand { get; set; }
        public List<String> Iller { get; set; }
        public List<ComboObject> TihList { get; set; }
        public List<ComboObject> AskerlikSureList { get; set; }
        public List<ComboObject> YolIzinList { get; set; }
        public string Ad
        {
            get { return Bg.Ad; }
            set
            {
                if (value == Bg.Ad) return;
                Bg.Ad = value;
                base.OnPropertyChanged("Ad");
            }
        }


        public Xamarin.Forms.INavigation  nav;
        public string Sehir
        {
            
            get { return Bg.Askerlikyeri;  }
            set { Bg.Askerlikyeri = value; OnPropertyChanged(); }
        }

        public string Memleket
        {

            get { return Bg.Memleket; }
            set { Bg.Memleket = value; OnPropertyChanged(); }
        }

        public ComboObject Tih
        {
        
            set {
                if (value!=null)
                {
                    Bg.Izinhak = value.sayisi; OnPropertyChanged();
                }
                
               
            }
        }
        public int  AlinanCeza
        {
            get { return Bg.Alinanceza; }
            set { Bg.Alinanceza = value; OnPropertyChanged(); }
        }

        public int KullanilanIzin
        {
            get { return Bg.Kullanilanizin; }
            set { Bg.Kullanilanizin = value; OnPropertyChanged(); }
        }

        public int ErkenTerhis
        {
            get { return Bg.Erkenterhis; }
            set { Bg.Erkenterhis = value; OnPropertyChanged(); }
        }

        public ComboObject Yolizin
        {
            
            set {
                if (value!=null)
                {
                    Bg.Yolizin = value.sayisi; OnPropertyChanged();
                }
               
            }
        }
        public ComboObject AskerlikSure
        {

            set
            {
                if (value!=null)
                {
                    Bg.Askerliksure = value.sayisi; OnPropertyChanged();
                }
            }
               
        }
        public  void OpenMainPage(object obj)
        {
            try
            {
                App.RealmContext.Write(() =>
                {
                    Bilgiler asd = new Bilgiler();
                    asd.Memleket = " ";
                    App.RealmContext.Add(asd);
                });

            }
            catch (Exception ex)
            {

             
            }
           
            nav.PopModalAsync();
           
        }

      
        public BilgiGirViewModel()
        {
        
            Bg = new Bilgiler();
            Iller  = new List<string>(){
                "", "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin",
"Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
"Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
"Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
"Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
"Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
"Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
"Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak",
"Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };
            TihList = new List<ComboObject>(){
              new ComboObject(){ yazisi="6 Gün",sayisi=6 },
                new ComboObject(){ yazisi= "12 Gün",sayisi=12 },
                 new ComboObject(){yazisi="18 Gün",sayisi=18 },
                new ComboObject("24 Gün",24),
                new ComboObject("1 Gün(Bedelli)",1) };
            AskerlikSureList = new List<ComboObject>(){
                new ComboObject("6 Ay",6),new ComboObject("18 Ay",18),new ComboObject("15 Ay",15),new ComboObject("12 Ay",12),new ComboObject("9 Ay",9),new ComboObject("3 Ay",3),new ComboObject("1 Ay (Bedelli)",1) };
            YolIzinList = new List<ComboObject>(){
               new ComboObject("1 (Terhis)",1),new ComboObject("1+1 (İzin)",2),new ComboObject("2 (Terhis)",2),new ComboObject("2+2 (İzin)",2),new ComboObject("3 (Terhis)",3),new ComboObject("3+3 (İzin)",6) };

            KaydetCommand = new Command(OpenMainPage, x => true);
        }
       
        

    }
}
