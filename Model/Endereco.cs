using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string logradouro, string bairro, string complemento, string numero, string cep)
        {
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
        }

        public Endereco(int id, string logradouro, string bairro, string complemento, string numero, string cep)
        {
            this.id = id;
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
        }

        public Endereco(string logradouro, string bairro, string complemento, string numero, string cep, Cidade cidade)
        {
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
            this.cidade = cidade;
        }
        /*
        public Endereco(string logradouro, string bairro, string complemento, string numero, string cep, int cidadeid)
        {
            this.logradouro = logradouro;
            this.bairro = bairro;
            this.complemento = complemento;
            this.numero = numero;
            this.cep = cep;
            this.cidadeid = cidadeid;
        }*/




        [Key]
        public int id { get; set; }
         
        public string logradouro { get; set; }
         
        public string bairro { get; set; }
        public string complemento { get; set; }
         
        public string numero { get; set; }
         
        public string cep { get; set; }
         
        public Cidade cidade { get; set; }
        //public int cidadeid { get; set; }
    }
}