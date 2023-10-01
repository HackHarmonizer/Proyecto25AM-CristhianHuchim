using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> MostrarRoles();
        public Task<Response<Rol>> CrearRoles(RolResponse request);
        public Task<Response<Rol>> ActualizarRoles(RolResponse request, int id);
        public Task<Response<Rol>> EliminarRoles(int id);
        public Task<Response<Rol>> MosID(int id);
    }
}
