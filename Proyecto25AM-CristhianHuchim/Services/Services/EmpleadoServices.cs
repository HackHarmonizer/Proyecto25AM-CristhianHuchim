using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class EmpleadoServices :IEmpleadoServices
    {
        public readonly AppDBContext _context;
        public string Mensaje;

        public EmpleadoServices(AppDBContext context)
        {
            _context = context;
        }

        //FUNCIONES CRUD
        #region
        public async Task<Response<List<Empleado>>> MostrarEmpleados()
        {
            try
            {
                //var response = await _context.Empleados.ToListAsync();
                var response = await _context.Empleados.Include(x => x.Puesto).Include(z => z.Departamento).ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Empleado>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Empleado>>(Mensaje, false);
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
        public async Task<Response<Empleado>> CrearEmp(EmpleadoResponse request)
        {
            try
            {
                Empleado Em = new Empleado()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Dirección = request.Dirección,
                    Ciudad = request.Ciudad,
                    FkPuesto = request.FkPuesto,
                    FKDepartamento = request.FKDepartamento
                };
                _context.Empleados.Add(Em);
                await _context.SaveChangesAsync();
                return new Response<Empleado>(Em);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion
        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Empleado>> ActualizarEm(EmpleadoResponse request, int id)
        {
            try
            {
                var response = _context.Empleados.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Empleado>(Mensaje, false);
                }
                else
                {
                    response.Nombre = request.Nombre;
                    response.Apellidos = request.Apellidos;
                    response.Dirección = request.Dirección;
                    response.Ciudad = request.Ciudad;
                    response.FkPuesto = request.FkPuesto;
                    response.FKDepartamento = request.FKDepartamento;

                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Response<Empleado>(response);
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
        public async Task<Response<Empleado>> EliminarEmpleado(int id)
        {

            try
            {
                var response = await _context.Empleados.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Empleado>(Mensaje, false);
                }
                else
                {
                    _context.Empleados.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Empleado>(Mensaje, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion
        #region
        public async Task<Response<Empleado>> MosID(int id)
        {
            try
            {
                var response = await _context.Empleados.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se encontro Empleado";
                    return new Response<Empleado>(Mensaje, false);
                }
                else
                {
                    response = _context.Empleados.FirstOrDefault(x => x.PkEmpleado == id);
                    return new Response<Empleado>(response);
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
