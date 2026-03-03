using Country.MVC.Models.Country;
using Country.MVC.Services;
using Country.Web.Service;
using Microsoft.AspNetCore.Mvc;

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
            if (countries == null || !countries.Any())
            {
                ViewBag.ErrorMessage = "No countries found or unable to fetch data.";
                countries = new List<CountryViewModel>();
            }
            return View(countries);
        }

        // GET: Country/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null)
            {
                TempData["ErrorMessage"] = $"Country with Id {id} not found.";
                return RedirectToAction(nameof(Index));
            }

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
        public IActionResult Create() => View();

        // POST: Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCountryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _service.CreateAsync(model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Unable to create country. Try again later.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _service.GetByIdAsync(id);
            if (country == null)
            {
                TempData["ErrorMessage"] = $"Country with Id {id} not found.";
                return RedirectToAction(nameof(Index));
            }

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateCountryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _service.UpdateAsync(model);
            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Unable to update country. Try again later.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
            {
                TempData["ErrorMessage"] = $"Unable to delete country with Id {id}. Try again later.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}