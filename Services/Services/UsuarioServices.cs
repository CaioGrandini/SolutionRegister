using MODEL.Entities;
using REPOSITORY.Interface;
using SERVICES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void DesativarUsuario(int IdUser)
        {
            _usuarioRepository.DesativarUsuario(IdUser);
        }

        public void ExcluirUsuario(int IdUser)
        {
            _usuarioRepository.ExcluirUsuario(IdUser);
        }

        public void InserirUsuario(Usuario usuario)
        {
            _usuarioRepository.InserirUsuario(usuario);
        }


        public ListarUsuario GetUsuario(int id)
        {
            return _usuarioRepository.GetUsuario(id);
        }

        public IEnumerable<ListarUsuario> ListarUsuariosAtivos()
        {
            return _usuarioRepository.ListarUsuariosAtivos();
        }

        public void VisualizarDetalhes()
        {
            throw new NotImplementedException();
        }

        public bool ValidaInformacoes(Usuario usuario, out string mensagem)
        {
            DateTime hoje = DateTime.Today;

            if (usuario.DataNascimento > DateTime.Now)
            {
                mensagem = "A data de nascimento não pode ser maior que a data atual.";
                return false;
            }

            int idade = hoje.Year - usuario.DataNascimento.Year;

            //CALCULA SE AINDA NAO FEZ ANIVERSARIO
            if (usuario.DataNascimento > hoje.AddYears(-idade))
            {
                idade--;
            }

            if (idade <= 0)
            {
                mensagem = "A idade não pode ser zero";
                return false;
            }

            if (idade < 18)
            {
                mensagem = "Sem maioridade penal, não permitido cadastro";
                return false;
            }

            mensagem = "Ok";
            return true;
        }
    }
}
