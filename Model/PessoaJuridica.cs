using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class PessoaJuridica
    {
        [Key]
        public int cnpj { get; set; }
         
        public string razaosocial { get; set; }
         
        public Endereco endereco { get; set; }
         
        public Representante representante { get; set; }
         
        public Contato contato { get; set; }
        List<Inscricao> inscricoes { get; set; }
    }
}