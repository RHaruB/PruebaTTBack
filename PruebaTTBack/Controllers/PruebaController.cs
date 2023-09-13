using Microsoft.AspNetCore.Mvc;
using PruebaTTBack.Service;

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
    }
}
