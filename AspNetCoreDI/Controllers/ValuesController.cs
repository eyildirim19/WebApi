using AspNetCoreDI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly YasamSureci _ys;  //=new YasamSureci();
        readonly YasamSureci _ys1; //=new YasamSureci();
        readonly Test _t;
        public ValuesController(
            YasamSureci ys,
            YasamSureci ys1,
            Test t
            )
        {
            //ys = new YasamSureci();
            //ys1 = new YasamSureci();
            _ys = ys;
            _ys1 = ys1;
            _t = t;
        }
        public IActionResult Get()
        {
            return Ok(new
            {
                value1 = _ys.deger,
                value2 = _ys1.deger,
                value3 = _t.RandomDeger
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            return Ok(new
            {
                value1 = _ys.deger,
                value2 = _ys1.deger

            });
        }
    }
}
