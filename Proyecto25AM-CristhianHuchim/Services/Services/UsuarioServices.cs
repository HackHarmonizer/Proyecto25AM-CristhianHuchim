using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class UsuarioServices :IUsuarioServices
    {
        private readonly AppDBContext _context;
        public string Mensaje;

        //Constructor
        public UsuarioServices(AppDBContext context)
        {
            _context = context;
        }

        //Funciones CRUD

        #region
        //MOSTRAR LISTA DE USUARIOS SIN ID
        public async Task<Response<List<Usuario>>> MostrarUsuario()
        {
            try
            {
                var response = await _context.Usuarios.Include(z => z.Empleado).Include(x => x.Rol).ToListAsync();

                if (response.Count > 0)
                {
                    //Nulos
                    return new Response<List<Usuario>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Usuario>>(Mensaje, false);
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
        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario user = new Usuario()
                {
                    User = request.User,
                    Password = request.Password,
                    FechaRegistro = request.FechaRegistro,
                    FkEmpleado = request.FkEmpleado,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion
        //
        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Usuario>> ActualizarUsuario(UsuarioResponse request, int id)
        {
            try
            {
                var response = _context.Usuarios.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Usuario>(Mensaje, false);
                }
                else
                {
                    response.User = request.User;
                    response.Password = request.Password;
                    response.FechaRegistro = request.FechaRegistro;
                    response.FkEmpleado = request.FkEmpleado;
                    response.FkRol = request.FkRol;

                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new Response<Usuario>(response);
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
        public async Task<Response<Usuario>> EliminarUsuario(int id)
        {

            try
            {
                var response = await _context.Usuarios.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Usuario>(Mensaje, false);
                }
                else
                {
                    _context.Usuarios.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Usuario>(Mensaje,true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion

        #region
        public async Task<Response<Usuario>> MosID(int id)
        {
            try
            {
                var response = await _context.Usuarios.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se encontro usuario disponible";
                    return new Response<Usuario>(Mensaje,false);
                }
                else
                {
                    response = _context.Usuarios.FirstOrDefault(x => x.PkUsuario == id);
                    return new Response<Usuario>(response);
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
