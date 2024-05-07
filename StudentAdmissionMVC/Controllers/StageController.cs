using Microsoft.AspNetCore.Mvc;

namespace StudentAdmissionMVC.Controllers
{
    public class StageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
