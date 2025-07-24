using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MODEL.Entities
{
    [Table("RegistroUsuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        
        public string NomeContato { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public bool Ativo { get; set; }
    }
}
