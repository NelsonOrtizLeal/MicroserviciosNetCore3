using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MicroserviciosNetCore3.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class ProductController : ControllerBase
    {
        // Lista de productos cargda en memoria para pruebas locales
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 500, Description = "Laptop HP" },
            new Product { Id = 2, Name = "Mouse", Price = 20, Description = "Mouse Logitech" },
            new Product { Id = 3, Name = "Keyboard", Price = 30, Description = "Keyboard Genius" }
        };

        // Método para obtener todos los productos
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }

        // Método para obtener un producto por su Id
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Products.Find(producto => producto.Id == id);

            if (product == null)
                return NotFound();

            return product;
        }

        // Método para agregar un producto
        [HttpPost]
        public ActionResult Create(Product model)
        {
            // Validando de forma manual el model JSON que se recibe de la peticion
            // Esta forma ya no es necesaria pero vale la pena saber que existe.
            if (!ModelState.IsValid)
                return BadRequest();

            model.Id = Products.Count + 1;
            Products.Add(model);

            return CreatedAtAction(
                "Get",
                new { id = model.Id },
                model
                );
        }

        // Método para actualizar un producto
        [HttpPut("{id}")]
        public ActionResult Update(int Id, Product model)
        {
            var originProduct = Products.Find(producto => producto.Id == Id);

            originProduct.Name = model.Name;
            originProduct.Price = model.Price;
            originProduct.Description = model.Description;

            return NoContent();
        }

        // Método para eliminar un producto
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Forma mas rapida para eliminar un producto
            //Products = Products.Where(producto => producto.Id != id).ToList();

            var originProduct = Products.Find(producto => producto.Id == id);

            if (originProduct == null)
                return NotFound();

            Products.Remove(originProduct);
            return NoContent();
        }
    }
}
