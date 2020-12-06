using System;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Inscricao 
    {

        public int pessoajuridica_id { get; set; }

         
        public int segmento_id { get; set; }
         
        public PessoaJuridica pessoajuridica { get; set; }
         
        public Segmento segmento { get; set; }
         
        public bool flgativo { get; set; }
        public string nomeiniciativa { get; set; }
        public string objetivos { get; set; }
        public string publicoalvo { get; set; }
        
    }
}