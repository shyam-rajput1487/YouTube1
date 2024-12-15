using ASPCoreWebAPICrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASPCoreWebAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly CsdbContext context;
        public StudentAPIController(CsdbContext context)
        {
            this.context= context;
        }
        public async Task< ActionResult<List<Dept>>> GetStudent()
        {
            var data = await context.Emps.ToListAsync();
            return Ok();
        }
    }
}
