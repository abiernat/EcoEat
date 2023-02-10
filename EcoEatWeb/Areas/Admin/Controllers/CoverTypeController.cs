using EcoEat.DataAccess;
using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoEatWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CoverTypeController : Controller
{
    private readonly iUnitOfWork _unitOfWork;

    public CoverTypeController(iUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
        return View(objCoverTypeList);
    }

    //get
    public IActionResult Create()
    {
        return View();
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Okładka została pomyślnie utworzona.";
            return RedirectToAction("Index");
        }
        return View();

    }

    //get
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(CoverType obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.CoverType.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Okładka została pomyślnie edytowana.";
            return RedirectToAction("Index");
        }
        return View(obj);

    }

    //get
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.CoverType.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Okładka została pomyślnie usunięta.";
        return RedirectToAction("Index");

    }

}
