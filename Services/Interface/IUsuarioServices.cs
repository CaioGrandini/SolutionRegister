using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Interface
{
    public interface IUsuarioServices
    {
        void InserirUsuario(Usuario usuario);
        void VisualizarDetalhes();
        void DesativarUsuario(int IdUser);
        void ExcluirUsuario(int IdUser);
        ListarUsuario GetUsuario(int IdUser);

        bool ValidaInformacoes(Usuario usuario, out string mensagem);
        IEnumerable<ListarUsuario> ListarUsuariosAtivos();
    }
}
