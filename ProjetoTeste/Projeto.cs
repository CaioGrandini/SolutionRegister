using MODEL.DTO;
using SERVICES.Services;

namespace ProjetoTeste
{
    public class Projeto
    {
        [Fact]
        public void CalculaIdade()
        {
            //IDADE = 54
            string data = "1970-10-21";
            DateTime dataConvert = Convert.ToDateTime(data);

            Assert.Equal(54, UsuarioServices.CalculaIdade(dataConvert));
        }

        [Fact]
        public void RetornaFalse()
        {
            //A DATA NÃO PODE SER MAIOR QUE A ATUAL
            string data = "2025-08-03";
            DateTime dataConvert = Convert.ToDateTime(data);

            Assert.False(UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem));
        }

        [Fact]
        public void RetornaMenorIdade()
        {
            //USUARIO NAO PODE SER MENOR DE IDADE
            string data = "2010-10-10";
            DateTime dataConvert = Convert.ToDateTime(data);

            Assert.False(UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem));
        }

        [Fact]
        public void RetornaIdadeZero()
        {
            //USUARIO NAO PODE SER MENOR DE IDADE
            string data = "2025-07-25";
            DateTime dataConvert = Convert.ToDateTime(data);

            Assert.False(UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem));
        }

        [Fact]
        public void RetornaTrue()
        {
            // USUARIO MAIOR DE IDADE = TRUE
            string data = "2000-10-27";
            DateTime dataConvert = Convert.ToDateTime(data);

            Assert.True(UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem));
        }
    }
}