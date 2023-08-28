using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly CatalogAPIContext _context;
        public CategoriesController(CatalogAPIContext context) {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() {
            try {
                return _context.Categories.AsNoTracking().ToList();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorre um problema ao tratar a sua solicitação");
            }

        }

        [HttpGet("{id:int}", Name = "GetCategories")]
        public ActionResult<Category> Get(int id) {
            try {
                var category = _context.Categories.FirstOrDefault(p => p.Id == id);

                if (category == null) {
                    return NotFound("Category not found");
                }

                return category;
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }

        }

        [HttpPost]
        public ActionResult<Category> Create(Category category) {
            if (category == null) {
                return BadRequest();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategories", new { id = category.Id }, category);
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category) {
            if (id != category.Id) {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> Delete(int id) {
            var category = _context.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null) {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts() {
            return _context.Categories.Include(p => p.Products).ToList();
        }
    }
}
