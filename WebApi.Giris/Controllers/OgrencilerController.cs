using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Giris.Controllers
{
    // Not : Genellikle web apilerde Routing Atrribute ile yapılır..
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencilerController : ControllerBase
    {
        List<string> ogrencilerim = new List<string>() { "Ziya", "Celalletin", "Onur", "Büşra", "İsmail", "Kübra" };


        // Not : webapiler arayüz uygulamarı olmadğı için (actionların viewları olmadığı için) web api geliştirmelerinde testler için ve geliştirme için çeşitli toollar kullanılır. EN yaygını POSTMAN, SOAPUI gibi toollardır. webapi uygulamalarından POSTMAN tercih edilir..SOAPUI ise genelde soap sevislerde tercih edilir..Bilgisayarınıza POSTMAN'İ kurunuz...https://www.postman.com/downloads/?utm_source=postman-home


        // Postman kurulumdan sonra yeni bir çalışma alanı oluşturup requestlrenizi yapabilirsiniz...
        // uygulamalayı çalışıtırın. tarayıcıdan url'i alın. postman request url'e alanına yapıştırıp request type'ı seçin send diyerek reqeusti gönderin...

        [HttpGet]
        public IActionResult Get()
        {
            // 20x status codeler başarılı dönüşlerdir..
            // Ok metodu client'e success dönen metottur. Bu metot HttpResponse döner. Clent bu metottan Ok geldiğini statuscode ile anlar. Başarılı responseların httpstatus code 200'dür..
            return Ok(ogrencilerim);
        }

        // api/Ogrenciler/1
        [HttpGet("{index}")] // url'de parametreyi tanımlıyoruz.. 
        public IActionResult Get(int index)
        {
            return Ok(ogrencilerim[index]);
        }

        [HttpPost]
        public IActionResult Kaydet()
        {
            return Ok("Kayıt İşlemi Başarılı");
        }
    }
}