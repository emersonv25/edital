using System;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Inscricao 
    {
        [Required]
        public int pessoajuridica_id { get; set; }

        [Required]
        public int segmento_id { get; set; }
        [Required]
        public PessoaJuridica pessoajuridica { get; set; }
        [Required]
        public Segmento segmento { get; set; }
        [Required]
        public bool flgativo { get; set; }
        public string nomeiniciativa { get; set; }
        public string objetivos { get; set; }
        public string publicoalvo { get; set; }
        
    }
}