using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LetsCalc.API.Controllers.Views;

public class LetsCalcController : Controller
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View("~/Views/Login/Index.cshtml");
    }

    [Authorize]
    public IActionResult Calculator()
    {
        return View("~/Views/Addition/Index.cshtml");
    }
}