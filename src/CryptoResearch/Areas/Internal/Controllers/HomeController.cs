using Microsoft.AspNetCore.Mvc;

namespace CryptoResearch.Areas.Internal.Controllers
{
    [Area("Internal")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}