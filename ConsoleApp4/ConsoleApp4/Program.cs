namespace EjemploDeClase
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa iniciado");

            // ProductoHandler productoHandler = new ProductoHandler();
            // productoHandler.GetProductos();

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            Console.WriteLine("\n----- GET ALL -----");
            List<Usuario> usuarios = usuarioHandler.GetUsuarios();

            for (int i = 0; i < usuarios.Count; i++)
            {
                Console.WriteLine($"Nombre usuario {i + 1}: {usuarios[i].Nombre}");
            }

            Console.WriteLine("\n----- INSERT ONE -----");
            Usuario newUser = new Usuario
            {
                Nombre = "Ricardo",
                Apellido = "Carranza",
                Contrasenia = 1234,
                NombreUsuario = "RicardoCarranza",
                Mail = "fHqJt@example.com"
            };

            int idNewUser = 0;

            if (Convert.ToBoolean(usuarioHandler.Insert(newUser)))
            {
                Usuario lastUser = usuarioHandler.GetUsuarios().Last();
                idNewUser = lastUser.Id;
                Console.WriteLine($"Contraseña del nuevo usuario agregado {lastUser.Contrasenia}");
            }

            Console.WriteLine("\n----- UPDATE ONE -----");

            if (Convert.ToBoolean(usuarioHandler.UpdateContrasenia(idNewUser, 4321)))
            {
                Usuario lastUser = usuarioHandler.GetUsuarios().Last();
                Console.WriteLine($"Nueva contraseña del nuevo usuario agregado {lastUser.Contrasenia}");
            }

            Console.WriteLine("\n----- DELETE ONE -----");

            if (Convert.ToBoolean(usuarioHandler.Delete(idNewUser)))
            {
                Console.WriteLine("Usuario eliminado. Mostrando nombres de los usuarios actuales:");

                List<Usuario> usuarios2 = usuarioHandler.GetUsuarios();

                for (int i = 0; i < usuarios2.Count; i++)
                {
                    Console.WriteLine($"Nombre usuario {i + 1}: {usuarios2[i].Nombre}");
                }
            }
        }
    }
}