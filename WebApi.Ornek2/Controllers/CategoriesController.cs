using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Ornek2.Entites;
using WebApi.Ornek2.Models;

namespace WebApi.Ornek2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly WebApiDBContext _dbContext;
        public CategoriesController(WebApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _dbContext.Categories.ToList();
            return Ok(result); // client'a httpstatuscode 200 olan bir cevap döner
        }

        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            var result = _dbContext.Categories.Find(Id);

            if (result == null)
                return NotFound("Kaynak Bulunamadı..."); // kaynak bulunamadı..


            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return Ok("İşlem Başarılı");
            }
            else
            {
                ModelState.AddModelError("hata", "Lütfen zorunlu alanları gönderiniz");
                return BadRequest(ModelState);
            }
        }
    }
}