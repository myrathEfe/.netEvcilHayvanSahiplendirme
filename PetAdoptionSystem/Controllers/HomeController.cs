using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionSystem.Filters;
using PetAdoptionSystem.Models;

namespace PetAdoptionSystem.Controllers;

public class HomeController : Controller
{
    [SessionAuthorize]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Pet");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
