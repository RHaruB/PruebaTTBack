using Microsoft.AspNetCore.Mvc;
using PruebaTTBack.Service;
using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        private readonly IUsuario _usuario;
        public  PruebaController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet("GetAllCargos")]
        public IActionResult GetAllCargos()
        {
            var result = _usuario.GetAllCargos();
            return new JsonResult(result);
        }

        [HttpGet("GetAllDepartamentos")]
        public IActionResult GetAllDepartamentos()
        {
            var result = _usuario.GetAllDepartamentos();
            return new JsonResult(result);
        }
        [HttpPost("SetUsuario")]
        public IActionResult SetUsuario(PersonasVM persona)
        {
            var result = _usuario.SetUsuario(persona);
            return new JsonResult(result);
        }
        [HttpPost("DeleteUsuario")]
        public IActionResult DeleteUsuario(PersonasVM persona)
        {
            var result = _usuario.DeleteUsuario(persona);
            return new JsonResult(result);
        }
        [HttpPost("UpdateUsuario")]
        public IActionResult UpdateUsuario(PersonasVM persona)
        {
            var result = _usuario.UpdateUsuario(persona);
            return new JsonResult(result);
        }
        [HttpGet("GetAllUsuarios")]
        public IActionResult GetAllUsuarios()
        {
            var result = _usuario.GetAllUsuarios();
            return new JsonResult(result);
        }
        [HttpPost("GetUsuariosFiltros")]
        public IActionResult GetUsuariosFiltros(PersonasVM persona)
        {
            if(persona.IdDepartamento != 0 && persona.IdCargo != 0)
            {
                var result = _usuario.GetAllUsuarios().Where(s=>s.IdCargo == persona.IdCargo && s.IdDepartamento == persona.IdDepartamento);
                return new JsonResult(result);
            }
            else if (persona.IdDepartamento != 0 )
            {
                var result = _usuario.GetAllUsuarios().Where(s =>  s.IdDepartamento == persona.IdDepartamento);
                return new JsonResult(result);
            }
            else 
            {
                var result = _usuario.GetAllUsuarios().Where(s => s.IdCargo == persona.IdCargo );
                return new JsonResult(result);
            }

        }
    }
}
