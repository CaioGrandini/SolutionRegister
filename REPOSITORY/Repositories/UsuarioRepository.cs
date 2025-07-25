using MODEL.Entities;
using System.Data;
using Dapper;
using System.Data.Common;
using SERVICES.Interface.Repositories;
using Dommel;
using MODEL.DTO;

namespace REPOSITORY.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region ..:: UPDATE's ::..

        //UPDATE USUARIO
        public void UpdateUsuario(Usuario usuario)
        {
            _connection.Update(usuario);
        }

        #endregion ..:: UPDATE's ::..

        #region ..:: DELETE ::..
        //EXCLUI USUARIO
        public void DeleteUsuario(Usuario usuario)
        {
            _connection.Delete(usuario);
        }
        #endregion ..:: DELETE ::..

        #region ..:: INSERT ::..
        //INSERE USUARIO
        public void InsertUsuario(Usuario usuario)
        {
            _connection.Insert(usuario);
        }

        #endregion ..:: INSERT ::..

        #region ..:: GET's ::..
        //BUSCA USUARIO
        public Usuario GetUsuario(int id)
        {
            var sql = @"Select 
                        	IdUsuario,
                        	NomeContato,
                        	DataNascimento,
                        	Sexo,
                        	Ativo
                        from RegistroUsuario
                        where IdUsuario = @idUsuario";

            return _connection.Query<Usuario>(sql, new { idUsuario = id }).FirstOrDefault();
        }

        //LISTA USUARIOS ATIVOS
        public IEnumerable<Usuario> GetListaUsuarios()
        {
            var sql = @"Select 
                        	IdUsuario,
                        	NomeContato,
                        	DataNascimento,
                        	Sexo,
                        	Ativo
                        from RegistroUsuario
                        where ativo = 1";

            return _connection.Query<Usuario>(sql).ToList();
        }

        #endregion ..:: GET's ::..
    }
}
