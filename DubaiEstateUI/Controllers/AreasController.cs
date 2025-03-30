using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DubaiEstateUI.Models;

namespace DubaiEstateUI.Controllers
{
    public class AreasController : Controller
    {
        private readonly IAreaRepository _areaRepository;

        public AreasController(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            return View(await _areaRepository.GetAllAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getAreaResult = await _areaRepository.GetAsync((long)id); 
            return getAreaResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AreaEntity area)
        {
            var createAreaResult = await _areaRepository.CreateAsync(area); 
            return View(createAreaResult);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var getAreaResult = await _areaRepository.GetAsync(id); 
            return getAreaResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] AreaEntity area)
        {
            var updateAreaResult = await _areaRepository.UpdateAsync(area); 
            return updateAreaResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var getAreaResult = await _areaRepository.GetAsync(id); 
            return getAreaResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _areaRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
