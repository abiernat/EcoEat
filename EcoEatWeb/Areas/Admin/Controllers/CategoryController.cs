using EcoEat.DataAccess;
using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoEatWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class CategoryController : Controller
{
    private readonly iUnitOfWork _unitOfWork;

    public CategoryController(iUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
        return View(objCategoryList);
    }

    //get
    public IActionResult Create()
    {
        return View();
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "Kolejność wyświetlania nie odpowiada nazwie.");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategoria została pomyślnie utworzona.";
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
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFirst);
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "Kolejność wyświetlania nie odpowiada nazwie.");
        }
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategoria została pomyślnie edytowana.";
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
        //var categoryFromDb = _db.Categories.Find(id);
        var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

        if (categoryFromDbFirst == null)
        {
            return NotFound();
        }

        return View(categoryFromDbFirst);
    }

    //post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.Category.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Kategoria została pomyślnie usunięta.";
        return RedirectToAction("Index");

    }

}
