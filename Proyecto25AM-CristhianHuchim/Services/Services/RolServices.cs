using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class RolServices :IRolServices
    {
        private readonly AppDBContext _context;
        public string Mensaje;
        public RolServices(AppDBContext context)
        {
            _context = context;
        }


        //FUNCIONES CRUD

        #region
        public async Task<Response<List<Rol>>> MostrarRoles()
        {
            try
            {
                var response = await _context.Rols.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Rol>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Rol>>(Mensaje, false);
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
        public async Task<Response<Rol>> CrearRoles(RolResponse request)
        {
            try
            {
                Rol user = new Rol()
                {
                    Nombre = request.Nombre,

                };
                _context.Rols.Add(user);
                await _context.SaveChangesAsync();
                return new Response<Rol>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion

        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Rol>> ActualizarRoles(RolResponse request, int id)
        {
            try
            {
                var response = _context.Rols.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Rol>(Mensaje,false);
                }
                else
                {
                    response.Nombre = request.Nombre;

                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Response<Rol>(response);
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
        public async Task<Response<Rol>> EliminarRoles(int id)
        {

            try
            {
                var response = await _context.Rols.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Rol>(Mensaje, false);
                }
                else
                {
                    _context.Rols.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Rol>(Mensaje,true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion

        #region
        public async Task<Response<Rol>> MosID(int id)
        {
            try
            {
                var response = await _context.Rols.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se entontro rol disponible";
                    return new Response<Rol>(Mensaje,false);
                }
                else
                {
                    response = _context.Rols.FirstOrDefault(x => x.PkRol == id);
                    return new Response<Rol>(response);
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
