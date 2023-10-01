using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<List<Puesto>>> MostrarPuesto();
        public Task<Response<Puesto>> CrearPuesto(PuestoResponse request);
        public Task<Response<Puesto>> ActualizarPuesto(PuestoResponse request, int id);
        public Task<Response<Puesto>> EliminarpU(int id);
        public Task<Response<Puesto>> MosID(int id);
    }
}
