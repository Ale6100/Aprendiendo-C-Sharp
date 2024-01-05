using Microsoft.AspNetCore.Mvc;
using ASP.NET_CoreWebAPI1.Model;
using ASP.NET_CoreWebAPI1.Repository;
using ASP.NET_CoreWebAPI1.Controllers.DTOS;

namespace ASP.NET_CoreWebAPI1.Controllers
{
    [ApiController] // Decorador que indica que la clase es un controlador
    [Route("[controller]")] // Define la ruta de este controlador. Es dinámica porque depende del nombre de la clase que decora. Actualmente es equivalente a [Route("Usuario")]

    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")] // El nombre de la ruta no cambia, pero gracias al Name podemos referenciar a este método como GetUsuarios, por ejemplo asi se obtiene la ruta a la que apunta: var url = Url.RouteUrl("GetUsuarios");
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }

        [HttpDelete]
        public bool EliminarUsuario([FromBody] int id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }

        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarContraseniaUsuario(usuario.Id, usuario.Contrasenia);
        }

        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            Usuario newUser = new Usuario
            {
                Apellido = usuario.Apellido,
                Nombre = usuario.Nombre,
                Contrasenia = usuario.Contrasenia,
                NombreUsuario = usuario.NombreUsuario,
                Mail = usuario.Mail
            };

            return UsuarioHandler.CrearUsuario(newUser);
        }
    }
}
