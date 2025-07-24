using MODEL.Entities;
using REPOSITORY.Interface;
using System.Data;
using Dapper;
using System.Data.Common;

namespace REPOSITORY.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _connection;

        public UsuarioRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        //DESATIVA USUARIO
        public void DesativarUsuario(int idUser)
        {
            var sql = "UPDATE USER_REGISTER SET ATIVO = 0 WHERE IDUSER_REGISTER = @IDUSUARIO_REGISTER";
            _connection.Execute(sql, new
            {
                IDUSUARIO_REGISTER = idUser
            });
        }

        //EXCLUI USUARIO
        public void ExcluirUsuario(int idUser)
        {
            var sql = "DELETE FROM USER_REGISTER WHERE IDUSER_REGISTER = @IDUSUARIO_REGISTER";
            _connection.Execute(sql, new
            {
                IDUSUARIO_REGISTER = idUser
            });
        }

        //INSERE USUARIO
        public void InserirUsuario(Usuario usuario)
        {
            var sql = "INSERT INTO USER_REGISTER (NOME_CONTATO, DATA_NASCIMENTO, SEXO, ATIVO) VALUES (@NOME_CONTATO, @DATA_NASCIMENTO, @SEXO, @ATIVO)";
            _connection.Execute(sql, new
            {
                NOME_CONTATO = usuario.NomeContato,
                DATA_NASCIMENTO = usuario.DataNascimento,
                SEXO = usuario.Sexo,
                ATIVO = usuario.Ativo
            });
        }


        public void VisualizarDetalhes()
        {
            throw new NotImplementedException();
        }

        //BUSCA USUARIO
        public ListarUsuario GetUsuario(int id)
        {
            var sql = @"SELECT  
                         IDUSER_REGISTER AS IdUserRegister, 
                         NOME_CONTATO AS NomeContato,
                         DATA_NASCIMENTO AS DataNascimento,
                         SEXO,
                         ATIVO
                FROM USER_REGISTER WHERE IDUSER_REGISTER = @Id";
            return _connection.QueryFirstOrDefault<ListarUsuario>(sql, new { Id = id });
        }

        //LISTA USUARIOS ATIVOS
        public IEnumerable<ListarUsuario> ListarUsuariosAtivos()
        {
            var sql = @"SELECT 
                         IDUSER_REGISTER AS IdUserRegister,
                         NOME_CONTATO AS NomeContato,
                         DATA_NASCIMENTO AS DataNascimento,
                         SEXO,
                         ATIVO
                       FROM USER_REGISTER
                       WHERE ATIVO = 1";

            return _connection.Query<ListarUsuario>(sql).ToList();
        }

    }
}
