namespace ASP.NET_CoreWebAPI1.Controllers.DTOS
{
    public class PostUsuario
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Contrasenia { get; set; }

        public string? NombreUsuario { get; set; }
        public string? Mail { get; set; }

    }
}
