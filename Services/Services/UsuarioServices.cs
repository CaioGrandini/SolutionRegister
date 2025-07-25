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

        #region ..:: DELETE ::..

        public (bool, string) DeleteUsuario(int IdUser)
        {
            (var valid, var mensagem, var getUser) = GetUsuario(IdUser);

            if (getUser == null)
                return (false, "Usuario não encontrado");

            if (!getUser.Ativo)
                return (false, "Usuario desativado");

            Usuario user = new Usuario
            {
                NomeContato = getUser.NomeContato,
                Ativo = getUser.Ativo,
                DataNascimento = Convert.ToDateTime(getUser.DataNascimento),
                IdUsuario = IdUser,
                Sexo = getUser.Sexo
            };

            _usuarioRepository.DeleteUsuario(user);
            return (true, string.Empty);
        }

        #endregion ..:: DELETE ::..

        #region ..:: INSERT ::..

        public (bool, string) InserirUsuario(UsuarioInsert usuarioInsert)
        {
            if (!ValidaInformacoes(usuarioInsert.DataNascimento, out string mensagem))
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

        #endregion ..:: INSERT ::..

        #region ..:: GET's ::..

        public (bool, string, UsuarioIdade) GetUsuario(int id)
        {
            Usuario getUsuario = _usuarioRepository.GetUsuario(id);

            if (getUsuario == null)
                return (false, "Usuario não encontrado", null);

            if (!getUsuario.Ativo)
                return (false, "Usuario desativado", null);

            return (true, string.Empty, CalculaIdade(getUsuario));
        }

        public IEnumerable<UsuarioIdade> GetListaUsuarios()
        {
            IEnumerable<Usuario> usuario = _usuarioRepository.GetListaUsuarios();

            IEnumerable<UsuarioIdade> usuarioIdade = CalculaIdadeLista(usuario);

            return usuarioIdade;
        }

        #endregion ..:: GET's ::..

        #region ..:: UPDATE's ::..

        public (bool, string) UpdateNome(int id, UpdateNome usuario)
        {
            (var valid, var mensagem, UsuarioIdade getUser) = GetUsuario(id);

            if (getUser == null)
                return (false, mensagem);

            if (!getUser.Ativo)
                return (false, mensagem);

            var updateNome = new Usuario
            {
                IdUsuario = id,
                NomeContato = usuario.NomeContato,
                Ativo = getUser.Ativo,
                DataNascimento = Convert.ToDateTime(getUser.DataNascimento),
                Sexo = getUser.Sexo
            };


            _usuarioRepository.UpdateUsuario(updateNome);
            return (true, string.Empty);
        }

        public (bool, string) UpdateIdade(int id, UpdateIdade usuario)
        {
            (var valid, var mensagemUsuario, UsuarioIdade getUser) = GetUsuario(id);

            if (getUser == null)
                return (false, mensagemUsuario);

            if (!getUser.Ativo)
                return (false, mensagemUsuario);

            if (!ValidaInformacoes(usuario.DataNascimento, out string mensagem))
                return (false, mensagem);

            var updateIdade = new Usuario
            {
                IdUsuario = id,
                NomeContato = getUser.NomeContato,
                Ativo = getUser.Ativo,
                DataNascimento = Convert.ToDateTime(usuario.DataNascimento),
                Sexo = getUser.Sexo
            };

            _usuarioRepository.UpdateUsuario(updateIdade);
            return (true, string.Empty);
        }

        public (bool, string) UpdateSexo(int id, UpdateSexo usuario)
        {
            (var valid, var mensagem, UsuarioIdade getUser) = GetUsuario(id);

            if (getUser == null)
                return (false, mensagem);

            if (!getUser.Ativo)
                return (false, mensagem);

            var updateNome = new Usuario
            {
                IdUsuario = id,
                NomeContato = getUser.NomeContato,
                Ativo = getUser.Ativo,
                DataNascimento = Convert.ToDateTime(getUser.DataNascimento),
                Sexo = usuario.Sexo
            };

            _usuarioRepository.UpdateUsuario(updateNome);
            return (true, string.Empty);
        }

        public (bool, string) UpdateDesativar(int id)
        {
            (var valid, var mensagem, UsuarioIdade getUser) = GetUsuario(id);

            if (getUser == null)
                return (false, mensagem);

            if (!getUser.Ativo)
                return (false, mensagem);

            var updateNome = new Usuario
            {
                IdUsuario = id,
                NomeContato = getUser.NomeContato,
                Ativo = false,
                DataNascimento = Convert.ToDateTime(getUser.DataNascimento),
                Sexo = getUser.Sexo
            };

            _usuarioRepository.UpdateUsuario(updateNome);
            return (true, string.Empty);
        }



        #endregion ..:: UPDATE's ::..

        #region ..:: METODOS ::..

        public bool ValidaInformacoes(DateTime dataNascimento, out string mensagem)
        {
            DateTime hoje = DateTime.Today;

            if (dataNascimento > DateTime.Now)
            {
                mensagem = "A data de nascimento não pode ser maior que a data atual.";
                return false;
            }

            int idade = hoje.Year - dataNascimento.Year;

            //CALCULA SE AINDA NAO FEZ ANIVERSARIO
            if (dataNascimento > hoje.AddYears(-idade))
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

        public IEnumerable<UsuarioIdade> CalculaIdadeLista(IEnumerable<Usuario> usuarios)
        {
            DateTime hoje = DateTime.Today;

            return usuarios.Select(usuario =>
            {
                int idade = hoje.Year - usuario.DataNascimento.Year;

                if (usuario.DataNascimento > hoje.AddYears(-idade))
                {
                    idade--;
                }

                return new UsuarioIdade
                {
                    IdUsuario = usuario.IdUsuario,
                    NomeContato = usuario.NomeContato,
                    Ativo = usuario.Ativo,
                    DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy"),
                    Idade = idade,
                    Sexo = usuario.Sexo,
                };
            });
        }

        public UsuarioIdade CalculaIdade(Usuario usuarios)
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - usuarios.DataNascimento.Year;

            if (usuarios.DataNascimento > hoje.AddYears(-idade))
            {
                idade--;
            }

            return new UsuarioIdade
            {
                IdUsuario = usuarios.IdUsuario,
                NomeContato = usuarios.NomeContato,
                Ativo = usuarios.Ativo,
                DataNascimento = usuarios.DataNascimento.ToString("dd/MM/yyyy"),
                Idade = idade,
                Sexo = usuarios.Sexo,
            };

        }

        #endregion ..:: METODOS ::..

    }
}
