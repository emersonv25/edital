using System.ComponentModel.DataAnnotations;

namespace edital.Model
{
    public class Anexo
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string contentype { get; set; }
        public byte[] arquivo { get; set; } 
       
    }
}