using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoServices _puestoServices;

        public PuestoController(IPuestoServices puestoservices)
        {
            _puestoServices = puestoservices;
        }
        //
        [HttpGet]
        public async Task<IActionResult> MostrarC()
        {
            return Ok(await _puestoServices.MostrarPuesto());
        }
        //
        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> CrearC([FromBody] PuestoResponse request)
        {
            return Ok(await _puestoServices.CrearPuesto(request));
        }
        //
        [HttpPut("ActualizarP/{id}")]
        public async Task<IActionResult> ActualizarC([FromBody] PuestoResponse request, int id)
        {
            return Ok(await _puestoServices.ActualizarPuesto(request, id));
        }

        //
        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _puestoServices.EliminarpU(id));
        }
        //
        [HttpGet("consultarid/{id:int}")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _puestoServices.MosID(id));

        }
    }
}
