using MODEL.DTO;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Interface.Services
{
    public interface IUsuarioServices
    {
        (bool, string) InserirUsuario(UsuarioInsert usuario);

        (bool, string) UpdateUsuario(Usuario usuario);
        (bool, string) DeleteUsuario(int idUser);
        Usuario GetUsuario(int id);
        IEnumerable<Usuario> GetListaUsuarios();
    }
}
