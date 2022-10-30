using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using WebApi.Client.Models;

namespace WebApi.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string url = "";
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            //url = (string)_configuration.GetValue<string>("AppUrls:CategoryApi");
            url = _configuration["AppUrls:CategoryApi"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoriesListWithAjax()
        {
            return View();
        }

        public IActionResult CategoriesListWithServer()
        {
            //string remoteUrl = "http://localhost:5062/Categories/";

            //HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(remoteUrl);
            //httpRequest.Method = "GET";
            //WebResponse response = httpRequest.GetResponse();
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //string result = reader.ReadToEnd();

            string result;
            HttpRequestHelper req = new HttpRequestHelper();
            req.SendRequest(url, "GET", null, null, out result);

            // json datayı c# nesnesine dönüştüyoruz...
            List<CategoryVM> resultData = JsonSerializer.Deserialize<List<CategoryVM>>(result);
            return View(resultData);
        }
        public IActionResult CategoriesDetay(int id)
        {
            string result;
            HttpRequestHelper req = new HttpRequestHelper();
            bool durum = req.SendRequest(url, "GET", id.ToString(), null, out result);

            CategoryVM resultData;
            if (durum)
                resultData = JsonSerializer.Deserialize<CategoryVM>(result);
            else
                resultData = new CategoryVM();

            // json datayı c# nesnesine dönüştüyoruz... 
            return Json(resultData);

        }

        public IActionResult AddCategory(CategoryVM model)
        {
            HttpRequestHelper req = new HttpRequestHelper();
            if (ModelState.IsValid)
            {
                string result = "";
                string postData = JsonSerializer.Serialize(model);
                req.SendRequest(url, "POST", null, postData, out result);

                return Json(result);
            }
            else
                return Json(BadRequest());
        }
    }
}