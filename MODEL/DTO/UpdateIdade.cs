using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class UpdateIdade
    {
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
