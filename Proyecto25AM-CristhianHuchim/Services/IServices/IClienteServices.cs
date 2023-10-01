using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<List<Cliente>>> MostratCliente();
        public Task<Response<Cliente>> CrearCliente(ClienteResponse request);
        public Task<Response<Cliente>> ActualizarCliente(ClienteResponse request, int id);
        public Task<Response<Cliente>> EliminarCliente(int id);

        public Task<Response<Cliente>> MosID(int id);
    }
}
