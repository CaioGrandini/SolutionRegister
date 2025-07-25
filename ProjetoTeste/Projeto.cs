using Microsoft.VisualStudio.TestPlatform.Utilities;
using MODEL.DTO;
using SERVICES.Services;
using Xunit.Abstractions;

namespace ProjetoTeste
{
    public class Projeto
    {

        private readonly ITestOutputHelper _output;

        public Projeto(ITestOutputHelper output)
        {
            _output = output;
        }

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

            bool resultado = UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem);

            _output.WriteLine(mensagem);
            Assert.False(resultado, mensagem);
        }

        [Fact]
        public void RetornaMenorIdade()
        {
            //USUARIO NAO PODE SER MENOR DE IDADE
            string data = "2010-10-10";
            DateTime dataConvert = Convert.ToDateTime(data);

            bool resultado = UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem);
            _output.WriteLine(mensagem);
            Assert.False(resultado, mensagem);
        }

        [Fact]
        public void RetornaIdadeZero()
        {
            //USUARIO NAO PODE SER MENOR DE IDADE
            string data = "2025-07-25";
            DateTime dataConvert = Convert.ToDateTime(data);

            bool resultado = UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem);
            _output.WriteLine(mensagem);
            Assert.False(resultado, mensagem);
        }

        [Fact]
        public void RetornaTrue()
        {
            // USUARIO MAIOR DE IDADE = TRUE
            string data = "2000-10-27";
            DateTime dataConvert = Convert.ToDateTime(data);

            bool resultado = UsuarioServices.ValidaInformacoes(dataConvert, out string mensagem);

            Assert.True(resultado, mensagem);

        }
    }
}