using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class DepartamentoServices : IDepartamentoServices
    {
        public readonly AppDBContext _context;
        public string Mensaje;

        public DepartamentoServices(AppDBContext context)
        {
            _context = context;
        }

        //FUNCIONES CRUD
        #region
        public async Task<Response<List<Departamento>>> MostrarDepa()
        {
            try
            {
                var response = await _context.Departamentos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Departamento>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Departamento>>(Mensaje, false);
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
        public async Task<Response<Departamento>> CrearDepa(DepartamentoResponse request)
        {
            try
            {
                Departamento Depa = new Departamento()
                {
                    Nombre = request.Nombre,
                };
                _context.Departamentos.Add(Depa);
                await _context.SaveChangesAsync();
                return new Response<Departamento>(Depa);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion
        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Departamento>> ActualizarDepa(DepartamentoResponse request, int id)
        {
            try
            {
                var response = _context.Departamentos.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Departamento>(Mensaje, false);
                }
                else
                {
                    response.Nombre = request.Nombre;


                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Response<Departamento>(response);
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
        public async Task<Response<Departamento>> EliminarDepa(int id)
        {

            try
            {
                var response = await _context.Departamentos.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Departamento>(Mensaje, false);
                }
                else
                {
                    _context.Departamentos.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Departamento>(Mensaje,true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion

        #region
        public async Task<Response<Departamento>> MosID(int id)
        {
            try
            {
                var response = await _context.Departamentos.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "No se encontro Departamento";
                    return new Response<Departamento>(Mensaje, false);
                }
                else
                {
                    response = _context.Departamentos.FirstOrDefault(x => x.PkDepartamento == id);
                    return new Response<Departamento>(response);
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
