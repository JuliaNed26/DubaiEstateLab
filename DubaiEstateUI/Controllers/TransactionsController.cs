using DubaiEstate.BLL.Models;
using DubaiEstate.BLL.Services.Interfaces;
using DubaiEstateUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace DubaiEstateUI.Controllers;

public class TransactionsController : Controller
{
    private readonly IProcedureRepository _procedureRepository;
    private readonly IAreaRepository _areaRepository;
    private readonly IPropertySubTypeRepository _propertySubTypeRepository;
    private readonly IDateRepository _dateRepository;
    private readonly ITransactionRepository _transactionRepository;

    public TransactionsController(
        ITransactionRepository transactionRepository,
        IProcedureRepository procedureRepository,
        IAreaRepository areaRepository,
        IPropertySubTypeRepository propertySubTypeRepository,
        IDateRepository dateRepository)
    {
        _transactionRepository = transactionRepository;
        _procedureRepository = procedureRepository;
        _areaRepository = areaRepository;
        _propertySubTypeRepository = propertySubTypeRepository;
        _dateRepository = dateRepository;
    }

    // GET: Transactions
    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
    {
        var pagedTransactions = await _transactionRepository.GetAllAsync(pageNumber, pageSize);
        return View(pagedTransactions);
    }

    // GET: Transactions/Details/5
    public async Task<IActionResult> Details(long id)
    {
        var result = await _transactionRepository.GetAsync(id);
        return result.Match<IActionResult>(
            View,
            failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));

    }

    // GET: Transactions/Create
    public async Task<IActionResult> Create()
    {
        var propertySubTypes = await _propertySubTypeRepository.GetAllAsync();
        var areas = await _areaRepository.GetAllAsync();
        var procedures = await _procedureRepository.GetAllAsync();
        ViewData["PropertySubTypeId"] = new SelectList(propertySubTypes, "Id", "Name");
        ViewData["AreaId"] = new SelectList(areas, "Id", "Name");
        ViewData["ProcedureId"] = new SelectList(procedures, "Id", "Name");
        return View();
    }

    // POST: Transactions/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TransactionEntity transactionEntity)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _transactionRepository.CreateAsync(transactionEntity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating transaction: {ex.Message}");
            }
        }

        var propertySubTypes = await _propertySubTypeRepository.GetAllAsync();
        var areas = await _areaRepository.GetAllAsync();
        var procedures = await _procedureRepository.GetAllAsync();
        ViewData["PropertySubTypeId"] = new SelectList(propertySubTypes, "Id", "Name");
        ViewData["AreaId"] = new SelectList(areas, "Id", "Name");
        ViewData["ProcedureId"] = new SelectList(procedures, "Id", "Name");
        return View(transactionEntity);
    }

    // GET: Transactions/Edit/5
    public async Task<IActionResult> Edit(long id)
    {
        var propertySubTypes = await _propertySubTypeRepository.GetAllAsync();
        var areas = await _areaRepository.GetAllAsync();
        var procedures = await _procedureRepository.GetAllAsync();
        ViewData["PropertySubTypeId"] = new SelectList(propertySubTypes, "Id", "Name");
        ViewData["AreaId"] = new SelectList(areas, "Id", "Name");
        ViewData["ProcedureId"] = new SelectList(procedures, "Id", "Name");
        var result = await _transactionRepository.GetAsync(id);
        return result.Match<IActionResult>(
            View,
            failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));

    }

    // POST: Transactions/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TransactionEntity transactionEntity)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var propertySubTypes = await _propertySubTypeRepository.GetAllAsync();
                var areas = await _areaRepository.GetAllAsync();
                var procedures = await _procedureRepository.GetAllAsync();
                ViewData["PropertySubTypeId"] = new SelectList(propertySubTypes, "Id", "Name");
                ViewData["AreaId"] = new SelectList(areas, "Id", "Name");
                ViewData["ProcedureId"] = new SelectList(procedures, "Id", "Name");
                var result = await _transactionRepository.UpdateAsync(transactionEntity);
                return result.Match<IActionResult>(
                    View,
                    failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating transaction: {ex.Message}");
            }
        }

        return View(transactionEntity);
    }

    // GET: Transactions/Delete/5
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _transactionRepository.GetAsync(id);
        return result.Match<IActionResult>(
            View,
            failedResult => View("Error", new ErrorViewModel { Message = failedResult.Message }));
    }

    // POST: Transactions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        await _transactionRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}