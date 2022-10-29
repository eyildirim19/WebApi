using Microsoft.AspNetCore.Mvc;

namespace WebApi.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoriesListWithAjax()
        {

            return View();
        }
    }
}
