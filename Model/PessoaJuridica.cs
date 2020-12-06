using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class PessoaJuridica
    {
        public PessoaJuridica(){}

        public PessoaJuridica(int cnpj, string razaosocial, Endereco endereco, Representante representante, Contato contato){
            this.cnpj = cnpj;
            this.razaosocial = razaosocial;
            this.endereco = endereco;
            this.representante = representante;
            this.contato = contato; 
        }

        public PessoaJuridica(int cnpj, string razaosocial, Endereco endereco, Representante representante, Contato contato, List<Inscricao> inscricoes){
            this.cnpj = cnpj;
            this.razaosocial = razaosocial;
            this.endereco = endereco;
            this.representante = representante;
            this.contato = contato;
            this.inscricoes = inscricoes;
        }



        [Key]
        public int cnpj { get; set; }
        [Required]
        public string razaosocial { get; set; }
        [Required]
        public Endereco endereco { get; set; }
        [Required]
        public Representante representante { get; set; }
        [Required]
        public Contato contato { get; set; }
        List<Inscricao> inscricoes { get; set; }
    }
}