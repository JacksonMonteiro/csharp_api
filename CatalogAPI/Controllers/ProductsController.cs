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


        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<Product> Get(int id) {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product is null) {
                return NotFound("Product not found");
            }

            return product;
        }

        [HttpPost]
        public ActionResult Create(Product product) {
            if (product is null) {
                return BadRequest();
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }
    }
}
