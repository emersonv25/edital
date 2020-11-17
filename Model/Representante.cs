using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Representante
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public Contato contato { get; set; }
        [Required]
        public Endereco endereco { get; set; }
    }
}