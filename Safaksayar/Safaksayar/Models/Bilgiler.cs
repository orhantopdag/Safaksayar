using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Safaksayar.Models
{
  public  class Bilgiler : RealmObject, INotifyPropertyChanged
    {
        public string Ad { 
            get; 
            set; }
        public int Askerliksure { get; set; }
        public int Izinhak { get;
            set; }
        public int Kullanilanizin { 
            get;
            set; }

        public DateTimeOffset NihaiTarih
        {
            get;
            set;
        }
        public DateTimeOffset SulusTarih
        {
            get;
            set;
        }

        public int Yolizin { get; set; }
        public int Alinanceza { get; set; }
        public int Erkenterhis { get; set; }
        public string Askerlikyeri { get; set; }
        public string Memleket { get; set; }



    }
}
