namespace EjemploDeClase
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public int Contrasenia { get; set; }
        public required string NombreUsuario { get; set; }
        public required string Mail { get; set; }
    }
}
