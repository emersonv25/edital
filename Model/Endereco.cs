using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string logradouro { get; set; }
        [Required]
        public string bairro { get; set; }
        public string complemento { get; set; }
        [Required]
        public string numero { get; set; }
        [Required]
        public string cep { get; set; }
        [Required]
        public Cidade cidade { get; set; }
    }
}