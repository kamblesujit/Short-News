using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Short_News.Models;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using ToShortNews.Models;

namespace Short_News.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            // string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, @"~\CommonDataProvider\API\NewsArticles.json");
            StreamReader reader = new StreamReader(@"E:\SSK\DotNet_Practical\Short-News\CommonDataProvider\API\NewsArticles.json");
           // StreamReader reader = new StreamReader($"~//CommonDataProvider//API//NewsArticles.json");
            string json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<ExternalDataModel>(json);

            return View(data.Articles);
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
