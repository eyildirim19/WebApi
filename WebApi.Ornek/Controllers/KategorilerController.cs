using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Giris.Models;

namespace WebApi.Ornek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        CategoryRepository repository;
        //public KategorilerController()
        //{
        //    repository = new CategoryRepository();
        //}
        public KategorilerController(
            CategoryRepository repo
            )
        {
            repository = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.List());
        }
    }
}
