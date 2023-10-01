using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolServices;

        public RolController(IRolServices rolservices)
        {
            _rolServices = rolservices;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarC()
        {
            return Ok(await _rolServices.MostrarRoles());
        }
        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> CrearC([FromBody] RolResponse request)
        {
            return Ok(await _rolServices.CrearRoles(request));
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> ActualizarC([FromBody] RolResponse request, int id)
        {
            return Ok(await _rolServices.ActualizarRoles(request, id));
        }
        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _rolServices.EliminarRoles(id));
        }


        [HttpGet("consultarid/{id:int}")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _rolServices.MosID(id));

        }
    }
}
