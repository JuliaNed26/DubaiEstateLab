using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DubaiEstateUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DubaiEstateUI.Controllers
{
    public class PropertySubTypesController : Controller
    {
        private readonly IPropertySubTypeRepository _repository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;
        
        public PropertySubTypesController(IPropertySubTypeRepository repository, IPropertyTypeRepository propertyTypeRepository)
        {
            _repository = repository;
            _propertyTypeRepository = propertyTypeRepository;
        }

        // GET: PropertySubTypes
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: PropertySubTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getPropertySubTypeResult = await _repository.GetAsync((long)id); 
            return getPropertySubTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: PropertySubTypes/Create
        public async Task<IActionResult> Create()
        {
            var propertyTypes = await _propertyTypeRepository.GetAllAsync();
            ViewData["PropertyTypeId"] = new SelectList(propertyTypes, "Id", "Name");
            return View();
        }

        // POST: PropertySubTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PropertyTypeId")] PropertySubTypeEntity propertySubType)
        {
            var createPropertySubTypeResult = await _repository.CreateAsync(propertySubType); 
            var propertyTypes = await _propertyTypeRepository.GetAllAsync();
            ViewData["PropertyTypeId"] = new SelectList(propertyTypes, "Id", "Name");
            return View(createPropertySubTypeResult);
        }

        // GET: PropertySubTypes/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var getPropertySubTypeResult = await _repository.GetAsync(id); 
            var propertyTypes = await _propertyTypeRepository.GetAllAsync();
            ViewData["PropertyTypeId"] = new SelectList(propertyTypes, "Id", "Name");
            return getPropertySubTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: PropertySubTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,PropertyTypeId")] PropertySubTypeEntity propertySubType)
        {
            var updatePropertySubTypeResult = await _repository.UpdateAsync(propertySubType); 
            var propertyTypes = await _propertyTypeRepository.GetAllAsync();
            ViewData["PropertyTypeId"] = new SelectList(propertyTypes, "Id", "Name");
            return updatePropertySubTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: PropertySubTypes/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var getPropertySubTypeResult = await _repository.GetAsync(id); 
            return getPropertySubTypeResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: PropertySubTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}