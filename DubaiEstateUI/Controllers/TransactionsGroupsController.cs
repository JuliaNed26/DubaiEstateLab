using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DubaiEstateUI.Models;

namespace DubaiEstateUI.Controllers
{
    public class TransactionsGroupsController : Controller
    {
        private readonly ITransactionsGroupRepository _transactionsGroupRepository;

        public TransactionsGroupsController(ITransactionsGroupRepository transactionsGroupRepository)
        {
            _transactionsGroupRepository = transactionsGroupRepository;
        }

        // GET: TransactionsGroups
        public async Task<IActionResult> Index()
        {
            return View(await _transactionsGroupRepository.GetAllAsync());
        }

        // GET: TransactionsGroups/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getTransactionsGroupResult = await _transactionsGroupRepository.GetAsync((long)id); 
            return getTransactionsGroupResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: TransactionsGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionsGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TransactionsGroupEntity transactionsGroup)
        {
            var createTransactionsGroupResult = await _transactionsGroupRepository.CreateAsync(transactionsGroup); 
            return View(createTransactionsGroupResult);
        }

        // GET: TransactionsGroups/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var getTransactionsGroupResult = await _transactionsGroupRepository.GetAsync(id); 
            return getTransactionsGroupResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: TransactionsGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name")] TransactionsGroupEntity transactionsGroup)
        {
            var updateTransactionsGroupResult = await _transactionsGroupRepository.UpdateAsync(transactionsGroup); 
            return updateTransactionsGroupResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));;
        }

        // GET: TransactionsGroups/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var getTransactionsGroupResult = await _transactionsGroupRepository.GetAsync(id); 
            return getTransactionsGroupResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: TransactionsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _transactionsGroupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
