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
            var autos = Context.Autos.ToList();

            return View(autos);
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
            var auto = Context.Autos.Find(id);
            if (auto == null) return NotFound();

            Context.Entry(auto);

            return View(auto);
        }

        public IActionResult Details(int id, string? returnUrl)
        {
            // get product by ID from the db
            var auto = Context.Autos.Find(id);
            if (auto == null) return NotFound();

            // load related entity
            Context.Entry(auto).Reference(x => x.Company).Load();

            ViewBag.ReturnUrl = returnUrl;
            return View(auto);
        }

    }
}
