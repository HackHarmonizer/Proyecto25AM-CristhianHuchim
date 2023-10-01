using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<List<Factura>>> MostrarFacturas();
        public Task<Response<Factura>> CrearFactura(FacturaResponse request);

        public Task<Response<Factura>> ActualizarFactura(FacturaResponse request, int id);

        public Task<Response<Factura>> EliminarFac(int id);

        public Task<Response<Factura>> MosID(int id);
    }
}
