using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class PuestoServices : IPuestoServices
    {
        private readonly AppDBContext _context;
        public string Mensaje; 

        public PuestoServices(AppDBContext context)
        {
            _context = context;
        }


        #region
        public async Task<Response<List<Puesto>>> MostrarPuesto()
        {
            try
            {
                var response = await _context.Puestos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Puesto>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Puesto>>(Mensaje, false);
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
        public async Task<Response<Puesto>> CrearPuesto(PuestoResponse request)
        {
            try
            {
                Puesto pues = new Puesto()
                {
                    Nombre = request.Nombre,
                };
                _context.Puestos.Add(pues);
                await _context.SaveChangesAsync();
                return new Response<Puesto>(pues);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion

        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Puesto>> ActualizarPuesto(PuestoResponse request, int id)
        {
            try
            {
                var response = _context.Puestos.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Puesto>(Mensaje, false);
                }
                else
                {
                    response.Nombre = request.Nombre;
                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //Retonar
                    return new Response<Puesto>(response);
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
        public async Task<Response<Puesto>> EliminarpU(int id)
        {

            try
            {
                var response = await _context.Puestos.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Puesto>(Mensaje,false);
                }
                else
                {
                    _context.Puestos.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Puesto>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion

        #region
        public async Task<Response<Puesto>> MosID(int id)
        {
            try
            {
                var response = await _context.Puestos.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se encontro puesto";
                    return new Response<Puesto>(Mensaje,false);
                }
                else
                {
                    response = _context.Puestos.FirstOrDefault(x => x.PkPuesto == id);
                    return new Response<Puesto>(response);
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
