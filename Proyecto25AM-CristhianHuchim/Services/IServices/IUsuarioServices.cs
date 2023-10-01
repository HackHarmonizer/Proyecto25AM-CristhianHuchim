using Domain.DTO;
using Domain.Entities;

namespace Proyecto25AM_CristhianHuchim.Services.IServices
{
    public interface IUsuarioServices
    {
        //Mostrar
        public Task<Response<List<Usuario>>> MostrarUsuario();

        //Pedir
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);

        public Task<Response<Usuario>> EliminarUsuario(int id);

        public Task<Response<Usuario>> ActualizarUsuario(UsuarioResponse request, int id);
        public Task<Response<Usuario>> MosID(int id);
    }
}
