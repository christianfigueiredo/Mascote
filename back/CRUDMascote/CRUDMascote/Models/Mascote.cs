using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDMascote.Models
{
    [Table("Mascote")]
    public class Mascote
    {
               
        public int Id { get; set; }     
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Cor { get; set; }
        public float Peso { get; set; }
        public int Idade { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
