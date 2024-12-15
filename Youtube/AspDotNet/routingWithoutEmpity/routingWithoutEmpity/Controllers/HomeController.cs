using Microsoft.AspNetCore.Mvc;

namespace routingWithoutEmpity.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("[action]")]
        [Route("~/")]
        [Route("~/home")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult about()
        {
            return View();
        }


        [Route("[action]/{Id?}")]
        public int Details(int? Id)
        {
            return Id?? 2;
        }
    }
}
