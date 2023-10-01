using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _UsuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _UsuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> Mostrar()
        {
            return Ok(await _UsuarioServices.MostrarUsuario());
        }

        //Crear usuarios
        [HttpPost]
        [Route("enviar")]
        public async Task<IActionResult> Crear([FromBody] UsuarioResponse i)
        {

            return Ok(await _UsuarioServices.CrearUsuario(i));
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> Actualizar([FromBody] UsuarioResponse request, int id)
        {
            return Ok(await _UsuarioServices.ActualizarUsuario(request, id));
        }

        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _UsuarioServices.EliminarUsuario(id));
        }

        [HttpGet("consultarid/{id:int}")]
        public async Task<IActionResult> MostrarC(int id)
        {
            return Ok(await _UsuarioServices.MosID(id));

        }

    }
}
