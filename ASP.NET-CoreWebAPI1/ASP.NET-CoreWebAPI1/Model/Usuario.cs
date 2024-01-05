namespace ASP.NET_CoreWebAPI1.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Contrasenia { get; set; }

        public string? NombreUsuario { get; set; }
        public string? Mail { get; set; }

    }
}
