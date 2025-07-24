using MODEL.DTO;
using MODEL.Entities;
using SERVICES.Interface.Repositories;
using SERVICES.Interface.Services;
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

        public (bool, string) DeleteUsuario(int IdUser)
        {
            var getUser = GetUsuario(IdUser);

            if (getUser == null)
                return (false, "Usuario não encontrado");

            if (!getUser.Ativo)
                return (false, "Usuario desativado");

            _usuarioRepository.DeleteUsuario(getUser);
            return (true, string.Empty);
        }

        public (bool, string) UpdateUsuario(Usuario usuario)
        {
            Usuario getUser = GetUsuario(usuario.IdUsuario);

            if (getUser == null)
                return (false, "Usuario não encontrado");

            if (!getUser.Ativo)
                return (false, "Usuario desativado");

            var usuarioInsert = new UsuarioInsert
            {
                NomeContato = usuario.NomeContato,
                Ativo = usuario.Ativo,
                DataNascimento = usuario.DataNascimento,
                Sexo = usuario.Sexo
            };

            if (!ValidaInformacoes(usuarioInsert, out string mensagem))
                return (false, mensagem);

            _usuarioRepository.UpdateUsuario(usuario);
            return (true, string.Empty);
        }


        public (bool, string) InserirUsuario(UsuarioInsert usuarioInsert)
        {
            if (!ValidaInformacoes(usuarioInsert, out string mensagem))
                return (false, mensagem);

            var usuario = new Usuario
            {
                NomeContato = usuarioInsert.NomeContato,
                Ativo = usuarioInsert.Ativo,
                DataNascimento = usuarioInsert.DataNascimento,
                Sexo = usuarioInsert.Sexo,
            };

            _usuarioRepository.InsertUsuario(usuario);
            return (true, string.Empty);
        }

        public Usuario GetUsuario(int id)
        {
            return _usuarioRepository.GetUsuario(id);
        }

        public IEnumerable<Usuario> GetListaUsuarios()
        {
            return _usuarioRepository.GetListaUsuarios();
        }

        public bool ValidaInformacoes(UsuarioInsert usuario, out string mensagem)
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
