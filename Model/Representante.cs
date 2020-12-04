using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Representante
    {
        [Key]
        public int id { get; set; }
         
        public string nome { get; set; }
         
        public string cpf { get; set; }
         
        public Contato contato { get; set; }
         
        public Endereco endereco { get; set; }
    }
}