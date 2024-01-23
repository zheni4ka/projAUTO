using AUTO.Data;
using AUTO.Data.Entities;
using Microsoft.AspNetCore.Mvc;
namespace AUTO.Controllers
{
    public class CarSalonController : Controller
    {
        public CarSalonDbContext Context { get; set; }

        public CarSalonController(CarSalonDbContext context)
        {
            this.Context = context;
        }

        public IActionResult Index()
        {
            var products = Context.Autos.ToList();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Auto item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Context.Autos.Add(item);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var product = Context.Autos.Find(id);

            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = Context.Autos.Find(id);

            if (product == null) return NotFound();

            Context.Remove(product);
            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
