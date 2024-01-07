using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private BarContext _context;

        public BrandController(BarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Brand> Get() => _context.Brands.ToList();
    }
}
