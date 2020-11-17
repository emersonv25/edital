using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class PessoaJuridica
    {
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