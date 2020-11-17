using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace edital.Model
{
    public class Segmento
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string segmento { get; set; }
        public string descricao { get; set; }   
        [Required]     
        public Edital edital { get; set; }
        public List<Inscricao> inscricoes { get; set; }
    }
}