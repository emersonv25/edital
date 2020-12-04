using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Contato
    {
        [Key]
         
        public int id { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
         
        public string celular { get; set; }
        public string site { get; set; } 
    }
}