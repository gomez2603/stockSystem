using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockSystem.Dtos;
using stockSystem.Services.Interfaces;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,STOCKER")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_service.GetAll());
        }
    }
}
