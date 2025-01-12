﻿
using Microsoft.AspNetCore.Mvc;
using StockSystem.dataAccess.Models;
using stockSystem.Services.Interfaces;
using stockSystem.Dtos;

using AutoMapper;
using System.Text;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var map = this._mapper.Map<IEnumerable<ResponseProduct>>(_service.GetAll(null,"user",null));
            return Ok(map);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.FindOne(x=>x.Id == id,"user");
            
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
            if (productDto.file != null)
            {
                using var stream = productDto.file.OpenReadStream();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                byte[] file = ms.ToArray();
                data.Image = Convert.ToBase64String(file);
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
                using var stream = productDto.file.OpenReadStream();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                byte[] file = ms.ToArray();
                data.Image = Convert.ToBase64String(file);
            }
            _service.Update(data);
            return Created("", data);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }

    }



}

