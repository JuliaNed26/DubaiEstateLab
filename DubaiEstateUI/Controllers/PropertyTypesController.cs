using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DubaiEstateUI.Models;

namespace DubaiEstateUI.Controllers
{
    public class PropertyTypesController : Controller
    {
        private readonly IPropertyTypeRepository _repository;

        public PropertyTypesController(IPropertyTypeRepository repository)
        {
            _repository = repository;
        }

        // GET: PropertyTypes
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: PropertyTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getPropertyTypeResult = await _repository.GetAsync((long)id); 
            return getPropertyTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: PropertyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PropertyTypeEntity propertyType)
        {
            var createPropertyTypeResult = await _repository.CreateAsync(propertyType); 
            return View(createPropertyTypeResult);
        }

        // GET: PropertyTypes/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var getPropertyTypeResult = await _repository.GetAsync(id); 
            return getPropertyTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: PropertyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] PropertyTypeEntity propertyType)
        {
            var updatePropertyTypeResult = await _repository.UpdateAsync(propertyType); 
            return updatePropertyTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: PropertyTypes/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var getPropertyTypeResult = await _repository.GetAsync(id); 
            return getPropertyTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: PropertyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
