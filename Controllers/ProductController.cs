﻿using Microsoft.AspNetCore.Mvc;
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
    }
}