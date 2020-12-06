using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Representante
    {

        public Representante(){

        }

        public Representante(string nome, string cpf, Contato contato, Endereco endereco){
            this.nome = nome;
            this.cpf = cpf;
            this.contato = contato;
            this.endereco = endereco;
        }
        public Representante(int id, string nome, string cpf, Contato contato, Endereco endereco){
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
            this.contato = contato;
            this.endereco = endereco;

        }

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