using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


public class ArtificialController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _endpoint = "https://api.openai.com/v1/completions";

    public  ArtificialController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _apiKey = "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"; // ChatGPT API anahtarınızı buraya ekleyin
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string text)
    {
        try
        {
            // ChatGPT API'ye gönderilecek metin
            var requestData = new
            {
                prompt = text,
                max_tokens = 1000000 // Opsiyonel: En fazla kaç kelime üretileceğini belirleyin
            };

            // İstek verisini JSON formatına dönüştürme
            var jsonRequestData = JsonConvert.SerializeObject(requestData);

            // HTTP isteği oluşturma
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_endpoint),
                Content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json")
            };

            // Authorization başlığı eklemek
            request.Headers.Add("Authorization", $"Bearer {_apiKey}");

            // HTTP isteği gönderme
            var response = await _httpClient.SendAsync(request);

            // Yanıtın içeriğini okuma
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // JSON yanıtını C# nesnesine dönüştürme
            var responseData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

            // Yanıtı görüntüleme
            return Ok(responseData);
        }
        catch (Exception ex)
        {
            // Hata durumunda hatayı görüntüleme
            return StatusCode(500, ex.Message);
        }
    }
}
