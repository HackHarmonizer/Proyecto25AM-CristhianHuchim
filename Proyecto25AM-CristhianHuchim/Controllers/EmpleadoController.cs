using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServices _EmpleadoServices;

        public EmpleadoController(IEmpleadoServices EmpleadoServices)
        {
            _EmpleadoServices = EmpleadoServices;
        }

        [HttpGet]
        public async Task<IActionResult> MostrarC()
        {
            return Ok(await _EmpleadoServices.MostrarEmpleados());
        }

        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> CrearE([FromBody] EmpleadoResponse request)
        {
            return Ok(await _EmpleadoServices.CrearEmp(request));
        }

        [HttpPut("actualizarEmple/{id}")]
        public async Task<IActionResult> ActualizarE([FromBody] EmpleadoResponse request, int id)
        {
            return Ok(await _EmpleadoServices.ActualizarEm(request, id));
        }

        [HttpDelete("del/{id:int}")]
        public async Task<IActionResult> EliminaE(int id)
        {
            return Ok(await _EmpleadoServices.EliminarEmpleado(id));
        }

        [HttpGet("consultarEmpleado/{id:int}")]
        public async Task<IActionResult> MostrarE(int id)
        {
            return Ok(await _EmpleadoServices.MosID(id));
        }

    }
}
