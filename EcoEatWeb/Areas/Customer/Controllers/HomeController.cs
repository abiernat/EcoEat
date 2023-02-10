using EcoEat.DataAccess.Repository.iRepository;
using EcoEat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;

namespace EcoEatWeb.Areas.Customer.Controllers;
[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly iUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, iUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category");

        return View(productList);
    }

    public IActionResult Details(int id)
    {
        ShoppingCart cartObj = new()
        {
            Count = 1,
            Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category"),
        };

        return View(cartObj);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}