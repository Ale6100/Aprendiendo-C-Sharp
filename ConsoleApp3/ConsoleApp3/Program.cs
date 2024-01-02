using Connection;
namespace AleConsoleApp
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            List<Usuario> usuarios = productoHandler.GetUsuarios();

            foreach (var item in usuarios)
            {
                Console.WriteLine($"Item name devuelto: {item.name}");
            }
        }
    }
}
