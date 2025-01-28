
using Microsoft.AspNetCore.Mvc;
using StockSystem.dataAccess.Models;
using stockSystem.Services.Interfaces;
using stockSystem.Dtos;

using AutoMapper;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,STOCKER")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        public ProductController(IProductService service, IMapper mapper, Cloudinary cloudinary)
        {
            _service = service;
            _mapper = mapper;
            _cloudinary = cloudinary;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var map = this._mapper.Map<IEnumerable<ResponseProduct>>(_service.GetAll(null,"user,category",null));
            return Ok(map);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.FindOne(x=>x.id == id, "user,category");
            
            if (product == null)
            {
                return NotFound();
            }
            var map = this._mapper.Map<ResponseProduct>(product);
            return Ok(map);
        }

        [HttpPost]
       async public Task<IActionResult> Add(CreateUpdateProduct productDto)
        {



            var data = this._mapper.Map<Product>(productDto);
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            var userId = int.Parse(userIdClaim.Value);
            data.userId = userId;
            if (productDto.file != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(productDto.name, productDto.file.OpenReadStream()),
                    AssetFolder = "Products"

                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                data.image = uploadResult.SecureUrl.ToString();
            }
            
            _service.Add(data);
            return Created("", data);
        }

        [HttpPut]
       async public Task<IActionResult>  update(CreateUpdateProduct productDto)
        {
            var data = this._mapper.Map<Product>(productDto);
            if (productDto.file != null)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(productDto.name, productDto.file.OpenReadStream()),
                    AssetFolder = "Products"

                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                data.image = uploadResult.SecureUrl.ToString();
            }
            _service.Update(data);
            return Created("", data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }

    }



}

