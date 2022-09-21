using HttpRequestApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;

namespace HttpRequestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        //public IEnumerable<GitHubBranch>? GitHubBranches { get; set; }
        public async Task<IActionResult> Index1()
        {
            List<GitHubBranch>? GitHubBranches = new();

            var httpRequestMessage = new HttpRequestMessage(
           HttpMethod.Get,
           "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches")
            {
                Headers =
            {
                { HeaderNames.Accept, "application/vnd.github.v3+json" },
                { HeaderNames.UserAgent, "HttpRequestsSample" }
            }
            };
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                GitHubBranches = await JsonSerializer.DeserializeAsync<List<GitHubBranch>>(contentStream);
            }
            return Ok(GitHubBranches);
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}