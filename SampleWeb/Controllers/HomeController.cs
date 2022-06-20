using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReCaptchaVerifyClient.Contracts;
using SampleWeb.Models;

namespace SampleWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReCaptchaClient client;
        public HomeController(ILogger<HomeController> logger, IReCaptchaClient client)
        {
            _logger = logger;
            this.client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeModel model, string captcha)
        {
            var captchaResult = await client.VerifyAsync(captcha);
            if (captchaResult.IsSuccess)
            {
                return View();
            }

            return View(model);
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