using Microsoft.AspNetCore.Mvc;
using MODEL.DTO;
using MODEL.Entities;
using SERVICES.Interface.Services;
using SERVICES.Services;
using System.Diagnostics.Eventing.Reader;

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


        [HttpPost("insert")]
        public ActionResult Post([FromBody] UsuarioInsert usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            (var valid, var message) = _usuarioServices.InserirUsuario(usuario);

            if (valid)
                return Ok();
            else
                return BadRequest(new { erro = message });

        }

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            var usuarios = _usuarioServices.GetUsuario(id);

            if (usuarios == null)
                return NotFound();

            if (!usuarios.Ativo)
                return BadRequest(new { erro = "Usuario desativado" });

            return Ok(usuarios);
        }

        [HttpPut("update")]
        public ActionResult UpdateUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return NotFound();

            (var valid, var message) = _usuarioServices.UpdateUsuario(usuario);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });

        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            (var valid, var message) = _usuarioServices.DeleteUsuario(id);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });
        }

        [HttpGet("getList")]
        public IEnumerable<UsuarioIdade> GetList()
        {
            IEnumerable<UsuarioIdade> usuario = _usuarioServices.GetListaUsuarios();
            return usuario;
        }

    }
}
