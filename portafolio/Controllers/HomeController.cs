using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Services;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectService projectService;
    private readonly IConfiguration configuration;

    public HomeController(
        ILogger<HomeController> logger,
        IProjectService projectService,
        IConfiguration configuration
    )
    {
        _logger = logger;
        this.projectService = projectService;
        this.configuration = configuration;
    }

    public IActionResult Index()
    {
        // EXTRAER INFORMACIÓN DE UN PROVEDOR DE CONFIGURACION
        var surname = configuration.GetValue<string>("Surname");

        // LOGS PARA DEBUGEAR CÓDIGO EN TIEMPO DE EJECUCIÓN
        _logger.LogTrace("Este es un mensaje de trace " + surname);
        _logger.LogDebug("Este es un mensaje de debug " + surname);
        _logger.LogInformation("Este es un mensaje de information " + surname);
        _logger.LogWarning("Este es un mensaje de warning " + surname);
        _logger.LogError("Este es un mensaje de error " + surname);
        _logger.LogCritical("Este es un mensaje de critical " + surname);
        var projects = projectService.GetProjects().Take(3).ToList();

        var model = new HomeIndexViewModel() {
            projects = projects
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Projects()
    {
        var projects = projectService.GetProjects();
        return View(projects);
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Contact(Contact contact)
    {
        _logger.LogError("Nombre: " + contact.name);
        _logger.LogError("Email: " + contact.email);
        _logger.LogError("Mensaje: " + contact.message);
        return RedirectToAction("Thanks");
    }

    public IActionResult Thanks()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
