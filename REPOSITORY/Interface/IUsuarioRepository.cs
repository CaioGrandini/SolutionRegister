using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Interface
{
    public interface IUsuarioRepository
    {
        //INTERFACE

        void InserirUsuario(Usuario usuario);
        void VisualizarDetalhes();
        void DesativarUsuario(int IdUser);
        void ExcluirUsuario(int IdUser);
        ListarUsuario GetUsuario(int IdUser);

        IEnumerable<ListarUsuario> ListarUsuariosAtivos();
    }
}
