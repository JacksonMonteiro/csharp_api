using CatalogAPI.Context;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]  
    public class ProductsController : Controller {
        private readonly CatalogAPIContext _context;

        public ProductsController(CatalogAPIContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
