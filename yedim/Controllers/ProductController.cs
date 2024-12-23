using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yedim.Models;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace yedim.Controllers
{
    public class ProductController: Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }



        //ilgili verileri google da göstermek için yazılan kod 

        public IActionResult Index()
        {


            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            //Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(model);// id ye göre veritabanının daki verileri gösteriyor.
        }
    }
}
 