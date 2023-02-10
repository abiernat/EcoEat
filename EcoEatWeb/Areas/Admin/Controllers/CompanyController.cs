using EcoEat.DataAccess;
using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using EcoEat.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EcoEatWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CompanyController : Controller
{
    private readonly iUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;

    public CompanyController(iUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    //get
    public IActionResult Upsert(int? id)
    {
        Company company = new();

        if (id==null || id == 0)
        {
            return View(company);
        }
        else
        {
            company = _unitOfWork.Company.GetFirstOrDefault(u=>u.Id==id);
            return View(company);
        }
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Company obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {

            if(obj.Id == 0)
            {
                _unitOfWork.Company.Add(obj);
                TempData["success"] = "Firma została pomyślnie dodana.";
            }
            else
            {
                _unitOfWork.Company.Update(obj);
                TempData["success"] = "Firma została pomyślnie aktualizowana.";
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        return View(obj);

    }

    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var companyList = _unitOfWork.Company.GetAll();
        return Json(new { data = companyList });
    }

    //post
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Błąd podczas usuwania" });
        }

        _unitOfWork.Company.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Pomyślnie usunięto" });

    }

    #endregion

}
