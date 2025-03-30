using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DubaiEstate.DAL;
using DubaiEstate.DAL.Models;
using DubaiEstateUI.Models;

namespace DubaiEstateUI.Controllers
{
    public class ProceduresController : Controller
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly ITransactionsGroupRepository _transactionGroupRepository;

        public ProceduresController(
            IProcedureRepository procedureRepository,
            ITransactionsGroupRepository transactionGroupRepository)
        {
            _procedureRepository = procedureRepository;
            _transactionGroupRepository = transactionGroupRepository;
        }

        // GET: Procedures
        public async Task<IActionResult> Index()
        {
            return View(await _procedureRepository.GetAllAsync());
        }

        // GET: Procedures/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getAreaResult = await _procedureRepository.GetAsync((long)id); 
            return getAreaResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: Procedures/Create
        public async Task<IActionResult> Create()
        {
            var transGroups = await _transactionGroupRepository.GetAllAsync();
            ViewData["TransGroupId"] = new SelectList(transGroups, "Id", "Name");
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TransGroupId")] ProcedureEntity procedure)
        {
            var createProcedureResult = await _procedureRepository.CreateAsync(procedure); 
            var transGroups = await _transactionGroupRepository.GetAllAsync();
            ViewData["TransGroupId"] = new SelectList(transGroups, "Id", "Name");
            return View(createProcedureResult);
        }

        // GET: Procedures/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getProcedureResult = await _procedureRepository.GetAsync((long)id); 
            var transGroups = await _transactionGroupRepository.GetAllAsync();
            ViewData["TransGroupId"] = new SelectList(transGroups, "Id", "Name");
            return getProcedureResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,TransGroupId")] ProcedureEntity procedure)
        {
            var updateProcedureResult = await _procedureRepository.UpdateAsync(procedure); 
            var transGroups = await _transactionGroupRepository.GetAllAsync();
            ViewData["TransGroupId"] = new SelectList(transGroups, "Id", "Name");
            return updateProcedureResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // GET: Procedures/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var getProcedureResult = await _procedureRepository.GetAsync(id); 
            return getProcedureResult.Match<IActionResult>(
                View,
                failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _procedureRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
