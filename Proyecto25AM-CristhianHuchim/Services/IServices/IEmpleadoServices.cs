using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IEmpleadoServices
    {
        public Task<Response<List<Empleado>>> MostrarEmpleados();
        public Task<Response<Empleado>> CrearEmp(EmpleadoResponse request);
        public Task<Response<Empleado>> ActualizarEm(EmpleadoResponse request, int id);
        public Task<Response<Empleado>> EliminarEmpleado(int id);

        public Task<Response<Empleado>> MosID(int id);
    }
}
