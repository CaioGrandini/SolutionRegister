using MODEL.Entities;
using System.Data;
using Dapper;
using System.Data.Common;
using SERVICES.Interface.Repositories;
using Dommel;

namespace REPOSITORY.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        //UPDATE USUARIO
        public void UpdateUsuario(Usuario usuario)
        {
            _connection.Update(usuario);
        }

        //EXCLUI USUARIO
        public void DeleteUsuario(int idUser)
        {
            _connection.Delete(idUser);
        }

        //INSERE USUARIO
        public void InsertUsuario(Usuario usuario)
        {
            _connection.Insert(usuario);
        }

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
                        where IdUsuario = @id";

            return _connection.Query(sql, new { @id = id }).FirstOrDefault();
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


    }
}
