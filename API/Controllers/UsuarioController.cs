using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using SERVICES.Interface;
using SERVICES.Services;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_usuarioServices.ValidaInformacoes(usuario, out string mensagem))
                return BadRequest(new { erro = mensagem });

            _usuarioServices.InserirUsuario(usuario);
            return Ok();

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var usuarios = _usuarioServices.GetUsuario(id);

            if (usuarios == null)
                return NotFound();

            if (!usuarios.Ativo)
                return BadRequest(new { erro = "Usuario desativado" });

            return Ok(usuarios);
        }

        [HttpPut("desativar/{id}")]
        public ActionResult Edit(int id)
        {
            var usuario = _usuarioServices.GetUsuario(id);

            if (usuario == null)
                return NotFound();

            _usuarioServices.DesativarUsuario(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioServices.GetUsuario(id);

            if (usuario == null)
                return Ok();

            _usuarioServices.ExcluirUsuario(id);
            return NoContent(); // retorna 204
        }

        [HttpGet("listar")]
        public IEnumerable<ListarUsuario> ListarUsuariosAtivos()
        {
            IEnumerable<ListarUsuario> usuario = _usuarioServices.ListarUsuariosAtivos();
            return usuario;
        }

    }
}
