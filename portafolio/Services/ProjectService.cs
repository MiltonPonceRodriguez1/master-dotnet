using portafolio.Models;

namespace portafolio.Services
{
    public interface IProjectService
    {
        List<Project> GetProjects();
    }

    public class ProjectService: IProjectService
    {
        public List<Project> GetProjects()
        {
            return new List<Project>() {
                new Project {
                    title = "Amazon",
                    description = "E-Commerce realizado en ASP.NET Core",
                    image = "/images/amazon.png",
                    url = "https://amazon.com"
                },
                new Project {
                    title = "Steam",
                    description = "Tienda en linea para comprar videojuegos",
                    image = "/images/steam.png",
                    url=  "https://store.steampowered.com"
                },
                new Project {
                    title = "Reddit",
                    description = "Red  social para compartir en comunidades",
                    image = "/images/reddit.png",
                    url=  "https://reddit.com"
                },
                new Project {
                    title = "New York Times",
                    description = "Página de noticias en React",
                    image = "/images/nyt.png",
                    url=  "https://nytimes.com"
                }
            };
        }
    }
}