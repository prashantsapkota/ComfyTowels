using Microsoft.AspNetCore.Mvc;

namespace ComfyTowels.Controllers
{
    public class TowelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
