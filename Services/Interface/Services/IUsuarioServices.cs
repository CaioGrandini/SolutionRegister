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
        (bool, string) DeleteUsuario(int idUser);
        (bool, string, UsuarioIdade) GetUsuario(int id);
        IEnumerable<UsuarioIdade> GetListaUsuarios();


        // UPDATE
        (bool, string) UpdateNome(int id, UpdateNome updateNome);
        (bool, string) UpdateIdade(int id, UpdateIdade updateIdade);
        (bool, string) UpdateSexo(int id, UpdateSexo updateSexo);
        (bool, string) UpdateDesativar(int id);
    }
}
