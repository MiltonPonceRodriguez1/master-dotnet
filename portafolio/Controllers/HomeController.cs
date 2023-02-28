using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Services;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectService projectService;

    public HomeController(ILogger<HomeController> logger, IProjectService projectService)
    {
        _logger = logger;
        this.projectService = projectService;
    }

    public IActionResult Index()
    {
        var projects = projectService.GetProjects().Take(3).ToList();
        var model = new HomeIndexViewModel() {projects = projects};
        return View(model);
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
