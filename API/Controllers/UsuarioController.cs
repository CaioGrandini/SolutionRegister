using Microsoft.AspNetCore.Mvc;
using MODEL.DTO;
using MODEL.Entities;
using SERVICES.Interface.Services;
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

        [HttpPut("update/{id}")]
        public ActionResult Update(Usuario usuario)
        {
            if (usuario == null)
                return NotFound();

            _usuarioServices.UpdateUsuario(usuario);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {                     
            _usuarioServices.DeleteUsuario(id);
            return NoContent(); // retorna 204
        }

        [HttpGet("getList")]
        public IEnumerable<Usuario> GetList()
        {
            IEnumerable<Usuario> usuario = _usuarioServices.GetListaUsuarios();
            return usuario;
        }

    }
}
