using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class FacturaServices :IFacturaServices
    {
        private readonly AppDBContext _context;
        public string Mensaje;

        public FacturaServices(AppDBContext context)
        {
            _context = context;
        }

        //FUNCIONES CRUD
        #region
        public async Task<Response<List<Factura>>> MostrarFacturas()
        {
            try
            {
                //var response = await _context.Facturas.ToListAsync();
                var response = await _context.Facturas.Include(x => x.Cliente).ToListAsync();
                //var response = await _context.Facturas.Include(z => z.FkCliente).ThenInclude(z=> ).ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Factura>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Factura>>(Mensaje, false);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion

        #region
        //Crear usuarios
        public async Task<Response<Factura>> CrearFactura(FacturaResponse request)
        {
            try
            {
                Factura factrua = new Factura()
                {
                    RazonSocial = request.RazonSocial,
                    Fecha = request.Fecha,
                    RFC = request.RFC,
                    FkCliente = request.FkCliente,
                };
                _context.Facturas.Add(factrua);
                await _context.SaveChangesAsync();
                return new Response<Factura>(factrua);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion

        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Factura>> ActualizarFactura(FacturaResponse request, int id)
        {
            try
            {
                var response = _context.Facturas.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Factura>(Mensaje, false);
                }
                else
                {
                    response.RazonSocial = request.RazonSocial;
                    response.Fecha = request.Fecha;
                    response.RFC = request.RFC;
                    response.FkCliente = request.FkCliente;

                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Response<Factura>(response);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }
        #endregion

        #region
        //Eliminar usuarios
        public async Task<Response<Factura>> EliminarFac(int id)
        {

            try
            {
                var response = await _context.Facturas.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Factura>(Mensaje, false);
                }
                else
                {
                    _context.Facturas.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Factura>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion
        #region
        public async Task<Response<Factura>> MosID(int id)
        {
            try
            {
                var response = await _context.Facturas.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se encontro factura";
                    return new Response<Factura>(Mensaje, false);
                }
                else
                {
                    Mensaje = "Se encontro Factura";
                    response = _context.Facturas.FirstOrDefault(x => x.PkFactura == id);
                    return new Response<Factura>(response, Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion

    }
}
