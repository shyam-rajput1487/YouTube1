using Microsoft.AspNetCore.Mvc;

namespace routingWithoutEmpity.UserController
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
