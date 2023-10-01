using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<List<Departamento>>> MostrarDepa();
        public Task<Response<Departamento>> CrearDepa(DepartamentoResponse request);
        public  Task<Response<Departamento>> ActualizarDepa(DepartamentoResponse request, int id);
        public Task<Response<Departamento>> EliminarDepa(int id);
        public Task<Response<Departamento>> MosID(int id);
    }
}
