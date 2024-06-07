using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AcodeX_Web_Sitesi.Controllers
{
    public class UserAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7273/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserAdd(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonUSer = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonUSer, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7273/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> UserUpdate(int id)
        {
            var httpClient = new HttpClient();
            var responsiveMessage = await httpClient.GetAsync("https://localhost:7273/api/Default/" + id);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                var jsonUser = await responsiveMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonUser);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonUser = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var respponsiveMessage = await httpClient.PutAsync("https://localhost:7273/api/Default/", content);
            if (respponsiveMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            return View(p);
        }

        [HttpDelete]
        public async Task<IActionResult> UserDelete(int id)
        {
            var httpClient = new HttpClient();
            var responsiveMessage = await httpClient.GetAsync("https://localhost:7273/api/Default/" + id);
            if (responsiveMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}

