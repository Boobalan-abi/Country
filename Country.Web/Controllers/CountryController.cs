using Country.MVC.Models.Country;
using Country.MVC.Services;
using Country.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Country.MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }

        // GET: Country
        public async Task<IActionResult> Index()
        {
            var countries = await _service.GetAllAsync();
            return View(countries);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var country = await _service.GetByIdAsync(id);

            var model = new CountryViewModel
            {
                Id = country.Id,
                Name = country.Name,
                ShortDesc = country.ShortDesc,
                CountryCode = country.CountryCode
            };

            return View(model);
        }

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _service.GetByIdAsync(id);

            var model = new UpdateCountryViewModel
            {
                Id = country.Id,
                Name = country.Name,
                ShortDesc = country.ShortDesc,
                CountryCode = country.CountryCode
            };

            return View(model);
        }

        // POST: Country/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCountryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}