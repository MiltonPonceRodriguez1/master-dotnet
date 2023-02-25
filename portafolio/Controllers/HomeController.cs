using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var projects = GetProjects().Take(3).ToList();
        var model = new HomeIndexViewModel() {projects = projects};
        return View(model);
    }

    private List<Project> GetProjects()
    {
        return new List<Project>() {
            new Project {
                title = "Amazon",
                description = "E-Commerce realizado en ASP.NET Core",
                image = "/images/amazon.png",
                url = "https://amazon.com"
            },
            new Project {
                title = "New York Times",
                description = "Página de noticias en React",
                image = "/images/nyt.png",
                url=  "https://nytimes.com"
            },
            new Project {
                title = "Reddit",
                description = "Red  social para compartir en comunidades",
                image = "/images/reddit.png",
                url=  "https://reddit.com"
            },
            new Project {
                title = "Steam",
                description = "Tienda en linea para comprar videojuegos",
                image = "/images/steam.png",
                url=  "https://store.steampowered.com"
            }
        };
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
