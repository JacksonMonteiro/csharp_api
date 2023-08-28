using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller {
        private readonly CatalogAPIContext _context;

        public ProductsController(CatalogAPIContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() {
            var products = _context.Products.ToList();
            
            if (products is null) {
                return NotFound("Products not found");
            }

            return products;
        }


    }
}
