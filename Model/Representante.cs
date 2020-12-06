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
         
        public string nome { get; set; }
         
        public string cpf { get; set; }
         
        public Contato contato { get; set; }
         
        public Endereco endereco { get; set; }
    }
}