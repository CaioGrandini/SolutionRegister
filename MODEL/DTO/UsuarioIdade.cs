using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class UsuarioIdade
    {
        public int IdUsuario { get; set; }

        public string NomeContato { get; set; }

        public string DataNascimento { get; set; }

        public string Sexo { get; set; }

        public bool Ativo { get; set; }

        public int Idade { get; set; }
    }
}
