using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Cidade
    {
        public Cidade()
        {
        }

        public Cidade(string nome)
        {
            this.nome = nome;
        }

        public Cidade(string nome, Estado estado)
        {
            this.nome = nome;
            this.estado = estado;
        }

        public Cidade(string nome, Estado estado, List<Endereco> enderecos)
        {
            this.nome = nome;
            this.estado = estado;
        }

        public Cidade(int id, string nome, Estado estado, List<Endereco> enderecos)
        {
            this.id = id;
            this.nome = nome;
            this.estado = estado;
            this.enderecos = enderecos;
        }

        [Key]
        public int id { get; set; }
        public int estadoid { get; set; }
        public string nome { get; set; }
        public Estado estado {  get; set; }
        public List<Endereco> enderecos { get; set; }
    }
}