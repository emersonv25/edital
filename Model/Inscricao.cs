using System;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Inscricao  
    {

        public Inscricao(){}

        public Inscricao(PessoaJuridica pessoajuridica, Segmento segmento, 
        bool flgativo, string nomeiniciativa, string objetivos, string publicoalvo)
        {
        this.pessoajuridica = pessoajuridica;
        this.segmento = segmento;
        this.flgativo = flgativo;
        this.nomeiniciativa = nomeiniciativa;
        this.objetivos = objetivos;         
        this.publicoalvo = publicoalvo;
        }

        
        public Inscricao(int pessoajuridicaid, int segmentoid, PessoaJuridica pessoajuridica, Segmento segmento, 
        bool flgativo, string nomeiniciativa, string objetivos, string publicoalvo)
        {
        this.pessoajuridicacnpj = pessoajuridicaid;
        this.segmentoid = segmentoid;
        this.pessoajuridica = pessoajuridica;
        this.segmento = segmento;
        this.flgativo = flgativo;
        this.nomeiniciativa = nomeiniciativa;
        this.objetivos = objetivos;         
        this.publicoalvo = publicoalvo;
        }

        [Key]
        public int pessoajuridicacnpj{ get; set; }

        [Key]
        public int segmentoid { get; set; }
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