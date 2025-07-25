using MODEL.DTO;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Interface.Repositories
{
    public interface IUsuarioRepository
    {
        //INTERFACE
        void DeleteUsuario(Usuario usuario);
        void InsertUsuario(Usuario usuario);
        Usuario GetUsuario(int id);
        IEnumerable<Usuario> GetListaUsuarios();

        //UPDATE
        void UpdateUsuario(Usuario usuario);

    }
}
