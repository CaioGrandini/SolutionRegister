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

        #region ..:: INSERT ::..

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

        #endregion ..:: INSERT ::..

        #region ..:: GET's ::..

        [HttpGet("get/{id}")]
        public ActionResult Get(int id)
        {
            (var valid, var mensagem, var usuarios) = _usuarioServices.GetUsuario(id);

            if (usuarios == null)
                return BadRequest(new { erro = mensagem }); 

            if (!usuarios.Ativo)
                return BadRequest(new { erro = mensagem });

            return Ok(usuarios);
        }

        [HttpGet("getList")]
        public IEnumerable<UsuarioIdade> GetList()
        {
            IEnumerable<UsuarioIdade> usuario = _usuarioServices.GetListaUsuarios();
            return usuario;
        }

        #endregion ..:: GET's ::..

        #region ..:: DELETE ::..
        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            (var valid, var message) = _usuarioServices.DeleteUsuario(id);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });
        }

        #endregion ..:: DELETE ::..

        #region ..:: UPDATE's ::..

        [HttpPut("update/nome/{id}")]
        public ActionResult UpdateUsuario(int id, [FromBody] UpdateNome usuario)
        {
            if (usuario == null)
                return NotFound();

            (var valid, var message) = _usuarioServices.UpdateNome(id, usuario);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });

        }

        [HttpPut("update/idade/{id}")]
        public ActionResult UpdateIdade(int id, [FromBody] UpdateIdade usuario)
        {
            if (usuario == null)
                return NotFound();

            (var valid, var message) = _usuarioServices.UpdateIdade(id, usuario);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });

        }

        [HttpPut("update/sexo/{id}")]
        public ActionResult UpdateSexo(int id, [FromBody] UpdateSexo usuario)
        {
            if (usuario == null)
                return NotFound();

            (var valid, var message) = _usuarioServices.UpdateSexo(id, usuario);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });

        }

        [HttpPut("update/desativar/{id}")]
        public ActionResult UpdateDesativar(int id)
        {
            (var valid, var message) = _usuarioServices.UpdateDesativar(id);

            if (valid)
                return Ok();
            else
                return BadRequest(new { error = message });

        }

        #endregion ..:: UPDATE's ::..
    }
}
