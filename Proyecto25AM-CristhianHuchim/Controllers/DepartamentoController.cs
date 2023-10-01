using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoServices _departamentoServices;

        public DepartamentoController(IDepartamentoServices depaservices)
        {
            _departamentoServices = depaservices;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarD()
        {
            return Ok(await _departamentoServices.MostrarDepa());
        }

        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> CrearD([FromBody] DepartamentoResponse request)
        {
            return Ok(await _departamentoServices.CrearDepa(request));
        }
       
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarD([FromBody] DepartamentoResponse request, int id)
        {
            return Ok(await _departamentoServices.ActualizarDepa(request, id));
        }
        [HttpDelete("del/{id:int}")]
        public async Task<IActionResult> EliminarD(int id)
        {
            return Ok(await _departamentoServices.EliminarDepa(id));
        }

        [HttpGet("consultarid/{id:int}")]
        //[Route("mostrarid")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _departamentoServices.MosID(id));

        }
    }
}
