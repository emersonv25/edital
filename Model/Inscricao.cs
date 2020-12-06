using System;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Inscricao 
    {

        public Inscricao(){}
        public Inscricao(int pessoajuridica_id, int segmento_id, PessoaJuridica pessoajuridica, Segmento segmento, bool flgativo, string nomeiniciativa, string objetivos, string publicoalvo){}

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