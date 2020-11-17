using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Cidade
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public Estado estado {  get; set; }
        public List<Endereco> enderecos { get; set; }
    }
}