using Country.MVC.Models.State;
using Country.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace Country.MVC.Controllers
{
    public class StateController : Controller
    {
        private readonly IStateService _service;

        public StateController(IStateService service)
        {
            _service = service;
        }

        // GET: State
        public async Task<IActionResult> Index()
        {
            var states = await _service.GetAllAsync();
            return View(states);
        }

        // GET: State/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var state = await _service.GetByIdAsync(id);

            var model = new StateViewModel
            {
                Id = state.Id,
                Name = state.Name,
                CountryId = state.CountryId
            };

            return View(model);
        }

        // GET: State/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateStateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: State/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var state = await _service.GetByIdAsync(id);

            var model = new UpdateStateViewModel
            {
                Id = state.Id,
                Name = state.Name,
                CountryId = state.CountryId
            };

            return View(model);
        }

        // POST: State/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateStateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _service.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        // GET: State/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}