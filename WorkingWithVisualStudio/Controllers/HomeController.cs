using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        // Fält som representerar en ny instans av klassen SimpleRepository 
        public IRepository _repository = SimpleRepository.SharedRepository;

        //public IActionResult Index()
        //    => View(_repository.Products.Where(p => p?.Price < 50));


        public IActionResult Index()
            => View(_repository.Products);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            _repository.AddProduct(p);
             return RedirectToAction("Index");
        }

        public IActionResult Index2()
        {
            var lista = new List<Product>
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

                return View(lista);
        }
    }


}
    


