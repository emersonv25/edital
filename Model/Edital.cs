using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace edital.Model
{
    public class Edital
    {
        [Key]
        public int id { get; set; }
         
        public string nome { get; set; }
         
        public DateTime datainicio { get; set; }

        public DateTime? datafim { get; set; }
         
        public int vigencia { get; set; }

        public List<Segmento> segmentos { get; set; }
    }    
}