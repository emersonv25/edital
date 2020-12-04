using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace edital.Model
{
    public class Estado
    {
        public Estado()
        {
        }

        public Estado(string nome, string uf, bool flgativo)
        {
            this.nome = nome;
            this.uf = uf;
            this.flgativo = flgativo;
        }
        public Estado(int id, string nome, string uf, bool flgativo)
        {
            this.id = id;
            this.nome = nome;
            this.uf = uf;
            this.flgativo = flgativo;
        }

        public Estado(string nome, string uf, bool flgativo, List<Cidade> cidades)
        {
            this.nome = nome;
            this.uf = uf;
            this.flgativo = flgativo;
            this.cidades = cidades;
        }

        public Estado(int id, string nome, string uf, bool flgativo, List<Cidade> cidades)
        {
            this.id = id;
            this.nome = nome;
            this.uf = uf;
            this.flgativo = flgativo;
            this.cidades = cidades;
        }

        [Key]
        public int id { get; set; }
         
        public string nome { get; set; }
         
        public string uf { get; set; }
         
        public bool flgativo { get; set; }
        List<Cidade> cidades { get; set; }
    }
}