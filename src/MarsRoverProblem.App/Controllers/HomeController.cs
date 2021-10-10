using Microsoft.AspNetCore.Mvc;

namespace MarsRoverProblem.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
