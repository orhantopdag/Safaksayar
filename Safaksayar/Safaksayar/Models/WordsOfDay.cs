using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safaksayar.Models
{
  public class WordsOfDay : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Icerik { get; set; }
    }
}
