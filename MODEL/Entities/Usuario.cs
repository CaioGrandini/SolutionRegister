using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Usuario
    {
        
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string NomeContato { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage = "Defina um status ativo/inativo")]
        public bool Ativo { get; set; }
    }

    public class ListarUsuario
    {
        public int IdUserRegister { get; set; }

        public string NomeContato { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public bool Ativo { get; set; }
    }
}
