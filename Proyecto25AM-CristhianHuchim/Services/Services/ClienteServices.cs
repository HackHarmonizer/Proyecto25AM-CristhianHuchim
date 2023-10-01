using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using System.Net;
using System.Net.Mail;

namespace Proyecto25AM_CristhianHuchim.Services.Services
{
    public class ClienteServices :  IClienteServices
    {
        public readonly AppDBContext _context;
        public string Mensaje;

        public ClienteServices(AppDBContext context)
        {
            _context = context;
        }

        //FUNCIONES CRUD
        #region
        public async Task<Response<List<Cliente>>> MostratCliente()
        {
            try
            {
                var response = await _context.Clientes.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Cliente>>(response);
                }
                else
                {
                    Mensaje = "No se encontro ningun registro";
                    return new Response<List<Cliente>>(Mensaje,false);
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
        public async Task<Response<Cliente>> CrearCliente(ClienteResponse request)
        {
            try
            {
                Cliente Cli = new Cliente()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Telefono = request.Telefono,
                    Email = request.Email,
                    Direccion = request.Direccion
                };
                _context.Clientes.Add(Cli);
                await _context.SaveChangesAsync();
                return new Response<Cliente>(Cli);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR" + ex.Message);
            }
        }
        #endregion
        #region
        //ACTUALIZAR USUARIOS
        public async Task<Response<Cliente>> ActualizarCliente(ClienteResponse request, int id)
        {
            try
            {
                var response = _context.Clientes.Find(id);

                if (response == null)
                {
                    Mensaje = "No se encontro el usuario";
                    return new Response<Cliente>(Mensaje,false);
                }
                else
                {
                    response.Nombre = request.Nombre;
                    response.Apellidos = request.Apellidos;
                    response.Telefono = request.Telefono;
                    response.Email = request.Email;
                    response.Direccion = request.Direccion;

                    _context.Entry(response).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new Response<Cliente>(response);
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
        public async Task<Response<Cliente>> EliminarCliente(int id)
        {
            try
            {
                var response = await _context.Clientes.FindAsync(id);

                if (response == null)
                {
                    Mensaje = "NO SE ENCONTRO ID";
                    return new Response<Cliente>(Mensaje,false);
                }
                else
                {
                    _context.Clientes.Remove(response);
                    await _context.SaveChangesAsync();
                    Mensaje = "Se borro el usuario";
                    return new Response<Cliente>(Mensaje,true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Mensaje" + ex.Message);
            }
        }
        #endregion

        #region
        public async Task<Response<Cliente>> MosID(int id)
        {
            try
            {
                var response = await _context.Clientes.FindAsync(id);

                if(response == null)
                {
                    Mensaje = "No se encontro cliente";
                    return new Response<Cliente>(Mensaje,false);
                }
                else
                {
                    response = _context.Clientes.FirstOrDefault(x => x.PkCliente == id);
                    return new Response<Cliente>(response);
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
