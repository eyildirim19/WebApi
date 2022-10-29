using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Ornek2.Entites;

namespace WebApi.Ornek2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        WebApiDBContext _dbContext;
        public CustomersController(
           WebApiDBContext dbContext
            )
        {
            _dbContext = dbContext;
        }


        [HttpGet()]
        public IActionResult MusteriListesi()
        {
            var result = _dbContext.Customers.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Musteri(string id)
        {
            var result = _dbContext.Customers.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
