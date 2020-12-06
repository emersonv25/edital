using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace edital.Model
{
    public class Edital
    {
    
        public Edital()
        { 

        }

        public Edital(string nome, int vigencia, DateTime datainicio, DateTime datafim){
            this.nome = nome;
            this.vigencia = vigencia;
            this.datainicio = datainicio;
            this.datafim = datafim;
        }

        public Edital(int id, string nome, int vigencia, DateTime datainicio, DateTime datafim){
            this.id = id;
            this.nome = nome;
            this.vigencia = vigencia;
            this.datainicio = datainicio;
            this.datafim = datafim;
        }

        public Edital(int id, string nome, int vigencia, DateTime datainicio, DateTime datafim, List<Segmento> segmentos){
            this.id = id;
            this.nome = nome;
            this.vigencia = vigencia;
            this.datainicio = datainicio;
            this.datafim = datafim;
            this.segmentos = segmentos;

        }


        [Key]
        public int id { get; set; }
         
        public string nome { get; set; }
         
        public DateTime datainicio { get; set; }

        public DateTime? datafim { get; set; }
         
        public int vigencia { get; set; }

        public List<Segmento> segmentos { get; set; }
    }    
}