using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Safaksayar.Dto
{
    [XmlRoot("Fikralarhepsi")]
   public class Fikralarhepsi
    {

  
   
            public Fikralarhepsi() { this.Fikralar = new List<FikraDto>(); }

            [XmlElement("FikraDto")]
            public List<FikraDto> Fikralar { get; set; }
        
    }
}
