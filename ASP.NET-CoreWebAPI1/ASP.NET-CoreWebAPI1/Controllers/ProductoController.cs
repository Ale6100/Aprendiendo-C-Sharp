using Microsoft.AspNetCore.Mvc;
using ASP.NET_CoreWebAPI1.Model;
using ASP.NET_CoreWebAPI1.Repository;

namespace ASP.NET_CoreWebAPI1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    }
}
