using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaServices _facturaServices;

        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarC()
        {
            return Ok(await _facturaServices.MostrarFacturas());
        }

        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> CrearC([FromBody] FacturaResponse requeste)
        {
            return Ok(await _facturaServices.CrearFactura(requeste));
        }
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarC([FromBody] FacturaResponse request, int id)
        {
            return Ok(await _facturaServices.ActualizarFactura(request, id));
        }
        [HttpDelete("del/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _facturaServices.EliminarFac(id));
        }

        [HttpGet("consultarid/{id:int}")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _facturaServices.MosID(id));

        }
    }
}
