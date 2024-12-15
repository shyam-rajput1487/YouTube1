using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        List<string> fruits = new List<string>()
        {
            "Banana",
            "Grapes",
            "Orenge",
            "Apple",
            "Mango",
            "Cherry"
        };
        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }
        [HttpGet("id")]
        public string GetFruitsByIndex(int id)
        {
            return fruits.ElementAt(id);
        }
    }
}
