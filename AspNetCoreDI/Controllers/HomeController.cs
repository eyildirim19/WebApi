using AspNetCoreDI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // HomeController'in beklediği instance controlerdan oluşturulduğunda verilecektir...

        Repository repository = new Repository();
        //public HomeController(Repository repository)
        //{
        //    this.repository = repository;
        //}

        public IActionResult Index()
        {
            test();
            return Ok(repository.List());
        }

        public void test()
        {
            var r = repository.List();
        }
    }
}