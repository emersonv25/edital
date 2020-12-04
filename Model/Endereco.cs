using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Endereco
    {
        [Key]
        public int id { get; set; }
         
        public string logradouro { get; set; }
         
        public string bairro { get; set; }
        public string complemento { get; set; }
         
        public string numero { get; set; }
         
        public string cep { get; set; }
         
        public Cidade cidade { get; set; }
    }
}