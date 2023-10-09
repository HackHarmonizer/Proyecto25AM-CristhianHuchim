using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _ClienteServices;

        public ClienteController(IClienteServices usuarioServices)
        {
            _ClienteServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarC()
        {
            return Ok(await _ClienteServices.MostratCliente());
        }
        [HttpPost]
        [Route("crearcli")]
        public async Task<IActionResult> CrearC([FromBody] ClienteResponse request)
        {
            return Ok(await _ClienteServices.CrearCliente(request));
        }
        [HttpPut("actualizarcliente/{id}")]
        public async Task<IActionResult> ActualizarC([FromBody] ClienteResponse request, int id)
        {
            return Ok(await _ClienteServices.ActualizarCliente(request, id));
        }
        [HttpDelete("eliminarcliente/{id:int}")]
        public async Task<IActionResult> EliminarClie(int id)
        {
            return Ok(await _ClienteServices.EliminarCliente(id));
        }

        [HttpGet("consultarid/{id:int}")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _ClienteServices.MosID(id));
        }


    }
}
