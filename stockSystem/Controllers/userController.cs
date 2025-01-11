using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSystem.dataAccess.context;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly stockSystemContext _context;

        public userController(stockSystemContext context) {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get() {

            return Ok(_context.Users.ToList());
        }


    }
}
