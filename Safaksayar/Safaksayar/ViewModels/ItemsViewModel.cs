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
using Plugin.LocalNotifications;


namespace Safaksayar.ViewModels
{
    public class ItemsViewModel :BaseViewModel
    {
        //private bool isIndeterminate;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is indeterminate.
        /// </summary>
        /// <value><c>true</c> if this instance is indeterminate; otherwise, <c>false</c>.</value>
        //public bool IsIndeterminate
        //{
        //    get { return isIndeterminate; }
        //    set { isIndeterminate = value; OnPropertyChanged("IsIndeterminate"); }
        //}

        private float progress = 0.0f;


        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>The progress.</value>
        /// 


        public float Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                OnPropertyChanged("Progress");
            }
        }


        private float kalanprogress;
        public float KalanProgress
        {
            get { return kalanprogress; }
            set
            {
                kalanprogress = value;
                OnPropertyChanged("KalanProgress");
            }
        }


        private double speed = 100;



        /// <summary>
        /// Gets or sets the speed f.
        /// I could use an IValueConverter here to convert from double to int if I needed to
        /// </summary>
        /// <value>The speed f.</value>
        //public double SpeedF
        //{
        //    get { return speed; }
        //    set
        //    {
        //        if (Math.Abs(speed - value) < double.Epsilon)
        //            return;

        //        speed = value;
        //        OnPropertyChanged("Speed");
        //    }
        //}
        /// <summary>
        /// Get to beind to the actual speed
        /// </summary>
        /// <value>The speed.</value>
        //public int Speed
        //{
        //    get { return (int)speed; }
        //}


        //private Command toggleIndeterminateCommand;
        /// <summary>
        /// When triggered InDeterminate flag will be flipped
        /// </summary>
        /// <value>The toggle indeterminate command.</value>
        //public Command ToggleIndeterminateCommand
        //{
        //    get
        //    {
        //        return toggleIndeterminateCommand ??
        //      (toggleIndeterminateCommand = new Command(ExecuteToggleIndeterminateCommand));
        //    }
        //}


        //private void ExecuteToggleIndeterminateCommand()
        //{
        //    IsIndeterminate = !IsIndeterminate;
        //}

        private Command<string> addProgressCommand;
        /// <summary>
        /// Based on the "float" that is passed in via string progress will be added or subtracted
        /// </summary>
        /// <value>The add progress command.</value>
        public Command AddProgressCommand
        {
            get { return addProgressCommand ?? (addProgressCommand = new Command<string>(ExecuteAddProgressCommand)); }
        }


        private void ExecuteAddProgressCommand(string toAdd)
        {
            float addThis = 0.0F;
            if (float.TryParse(toAdd, out addThis))
                Progress += addThis;
        }

        /// <summary>
        /// Gets the default color of the progress bar
        /// </summary>
        /// <value>The color of the progress.</value>
        public Color ProgressColor
        {
            get { return Color.FromHex("3498DB"); }
        }

        /// <summary>
        /// Gets the default background color of the progress bar
        /// </summary>
        /// <value>The color of the progress background.</value>
        public Color ProgressBackgroundColor
        {
            get { return Color.FromHex("B4BCBC"); }
        }
        private Bilgiler bilgiler;
        public Bilgiler Bilgiler
        {
            get { return bilgiler; }
            set { bilgiler = value; OnPropertyChanged();
            }
        }
        private TimeSpan kalanZaman;
        public TimeSpan KalanZaman
        {
            get { return kalanZaman; }
            set { kalanZaman = value; OnPropertyChanged("KalanZaman"); }
        }

        private TimeSpan gecenZaman;
        public TimeSpan GecenZaman
        {
            get { return gecenZaman; }
            set { gecenZaman = value; OnPropertyChanged("GecenZaman"); }
        }

        public DateTime SulusTarihi
        {
            get { return Bilgiler.SulusTarih.DateTime; }
            set { Bilgiler.SulusTarih = DateTime.SpecifyKind(value, DateTimeKind.Local); OnPropertyChanged(); }
        }
      
        private bool isTrue;

        public bool IsTrue
        {
            get { return isTrue; }
            set { isTrue = value; OnPropertyChanged("IsTrue"); }
        }

        public DateTime TerhisTarihi
        {
            get { return Bilgiler.NihaiTarih.DateTime; }
            set { Bilgiler.NihaiTarih = DateTime.SpecifyKind(value, DateTimeKind.Local); OnPropertyChanged(); }
        }
        public string Memleket
        {
            get { return Bilgiler.Memleket; }
            set { Bilgiler.Memleket = value; OnPropertyChanged(); }
        }

        public string AskerlikYer
        {
            get { return Bilgiler.Askerlikyeri; }
            set { Bilgiler.Askerlikyeri = value; OnPropertyChanged(); }
        }


        public string TimeText
        {
            get { return textDate; }
            set { textDate = value; OnPropertyChanged(); }
        }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Safaksayar lite";
            Bilgiler = App.RealmContext.All<Bilgiler>().FirstOrDefault();        
            Progress= ((float)(DateTime.Now - bilgiler.SulusTarih).Days / (float)(bilgiler.NihaiTarih - bilgiler.SulusTarih).Days) *100;
            KalanProgress = 100 - progress;
            //CrossLocalNotifications.Current.Show("sfs","asd");
          
            TimeText = (bilgiler.NihaiTarih.DateTime - DateTime.Now).ToString(@"dd");
            KalanZaman = (bilgiler.NihaiTarih.DateTime - DateTime.Now);
            GecenZaman = (DateTime.Now - bilgiler.SulusTarih.DateTime);

            if (bilgiler!=null)
            {
                Device.StartTimer(TimeSpan.FromHours(1), () => {
                    
                    //TimeText = (bilgiler.NihaiTarih.DateTime-DateTime.Now ).ToString(@"dd\.hh\:mm\:ss");
                    TimeText = (bilgiler.NihaiTarih.DateTime - DateTime.Now).ToString(@"dd");
                    KalanZaman = (bilgiler.NihaiTarih.DateTime- DateTime.Now);
                    GecenZaman = (DateTime.Now - bilgiler.SulusTarih.DateTime);                                       
                    return true;
                });
            }
            

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


        private string textDate;
    }
}