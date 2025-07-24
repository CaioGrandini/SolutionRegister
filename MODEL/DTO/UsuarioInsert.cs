using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class UsuarioInsert
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string NomeContato { get; set; }
+
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Sexo { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
