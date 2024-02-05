using DataAccess;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BusinessLogic.DTOs;
namespace AUTO.Controllers
{
    public class CarSalonController : Controller
    {
        private readonly IAutosServices autoServices;
        private readonly IMapper mapper;

        public CarSalonController(IAutosServices autosServices, IMapper mapper)
        {
            this.autoServices = autosServices;
            this.mapper = mapper;
        }

        public IActionResult Index() { return View(autoServices.GetAll); }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public IActionResult Create(AutoDto item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            autoServices.Create(item);

            return RedirectToAction(nameof(Index));
        }
    

        public IActionResult Details(int id, string? returnUrl)
        {
            var auto = autoServices.GetById(id);
            if (auto == null) return NotFound();

            ViewBag.ReturnUrl = returnUrl;
            return View(auto);
        }

        //public IActionResult Edit(int id)
        //{
        //    if (!ModelState.IsValid) { Load()}
        //}

        public IActionResult Delete(int id)
        {
            autoServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
