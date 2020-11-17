using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Contato
    {
        [Key]
        [Required]
        public int id { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        [Required]
        public string celular { get; set; }
        public string site { get; set; } 
    }
}