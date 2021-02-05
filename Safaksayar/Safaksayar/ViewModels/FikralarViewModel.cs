using Safaksayar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Safaksayar.ViewModels
{
    public class FikralarViewModel : BaseViewModel
    {

        public FikralarViewModel()
        {
            var Bilgiler1 = App.RealmContext.All<Bilgiler>().FirstOrDefault();
            var gecengunsayisi = DateTime.Now - Bilgiler1.SulusTarih;
            Fikralar =new ObservableCollection<Fikra>(App.RealmContext.All<Fikra>().ToList());
        }

        public ObservableCollection<Fikra> Fikralar { get; }
    }
}
