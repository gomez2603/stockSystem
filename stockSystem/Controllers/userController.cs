using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockSystem.Dtos;
using stockSystem.Services;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.context;
using StockSystem.dataAccess.Models;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class userController : ControllerBase
    {

        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        
        public userController(IUserService service,IMapper mapper,IAuthService auth) {
            _service = service;
            _mapper = mapper;
            _authService = auth;
        }


        [HttpGet]
        public IActionResult Get() {
            var map = _mapper.Map<IEnumerable<userResponseDto>>(_service.GetAll(incluirPropiedades: "Rol").ToList());
            return Ok(map);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _service.FindOne(x => x.Id == id, "Rol");
            if (user == null)
            {
                return NotFound();
            }
            var map = _mapper.Map<userResponseDto>(user);
            return Ok(map);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserCreateDto user)
        {   
            var map = _mapper.Map<User>(user);
            _authService.CreatePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);   
            map.PasswordHash = passwordHash;
            map.PasswordSalt = passwordSalt;
         
            try
            {
                _service.Add(map);
                var response = _mapper.Map<userResponseDto>(map);

                return Created("", response);
            }
            catch (Exception ex) { 
                return BadRequest("El nombre de usuario ya esta en uso");
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginDto user)
        {
            var usertoLogin = _service.FindOne(x => x.Username == user.username,"Rol");
            if(usertoLogin == null)
            {
                return NotFound();
            }
            if (_authService.VerifyPassword(user.password, usertoLogin.PasswordHash, usertoLogin.PasswordSalt))
            {
                var response = _mapper.Map<userLoginResponse>(usertoLogin);
                response.token = _authService.CreateToken(usertoLogin);
                return Ok(response);
            }
           
            return BadRequest("Usuario o Contraseña Incorrecta");
          
        }

        [HttpPut]
    public IActionResult update([FromBody] UserCreateDto user)
    {
            var  map = _mapper.Map<User>(user);
            _authService.CreatePasswordHash(user.password, out byte[] passwordHash, out byte[] passwordSalt);
            map.PasswordHash = passwordHash;
            map.PasswordSalt = passwordSalt;
            try
            {

         
            _service.Update(map);
                var response = _mapper.Map<userResponseDto>(map);
                return Created("", response);
            }
            catch (Exception ex) {
                return BadRequest("El nombre de usuario ya esta en uso");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
}
}
