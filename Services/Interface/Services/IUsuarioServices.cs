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
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(int idUser);
        void InsertUsuario(Usuario usuario);
        Usuario GetUsuario(int id);
        IEnumerable<Usuario> GetListaUsuarios();
    }
}
