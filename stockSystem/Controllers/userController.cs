using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockSystem.Services;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.context;
using StockSystem.dataAccess.Models;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly IUserService _service;

        public userController(IUserService service) {
            _service = service;
        }


        [HttpGet]
        public IActionResult Get() {

            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _service.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            _service.Add(user);
            return Created("", user);
        }

    [HttpPut]
    public IActionResult update([FromBody] User user)
    {
        _service.Update(user);
        return Created("", user);
    }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
}
}
