using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Estado
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string uf { get; set; }
        [Required]
        public bool flgativo { get; set; }
        List<Cidade> cidades { get; set; }
    }
}