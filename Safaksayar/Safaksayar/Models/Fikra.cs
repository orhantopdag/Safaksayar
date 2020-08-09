using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safaksayar.Models
{
   public class Fikra : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FikraAdi
        {
            get;
            set;
        }
        public string FikraIcerigi { get; set; }
    }
}
