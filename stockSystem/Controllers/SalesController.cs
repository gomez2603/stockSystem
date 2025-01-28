using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stockSystem.DataAccess.Models;
using stockSystem.Dtos;
using stockSystem.Services;
using stockSystem.Services.Interfaces;
using System.Security.Claims;

namespace stockSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN,SALESMAN")]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;

        public SalesController(ISalesService salesService,IMapper mapper)
        {
            _salesService = salesService;
            _mapper = mapper;
        }


        [HttpPost]
        public  IActionResult CreateSale([FromBody] SalesDto salesDto)
        {
            try
            {
                // Obtener el userId del token
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
                if (userIdClaim == null)
                {
                    return Unauthorized("No se pudo obtener el ID del usuario del token.");
                }

                var userId = int.Parse(userIdClaim.Value);

                var saleEntity = _mapper.Map<Sales>(salesDto);
                saleEntity.salesBy = userId;

                // Validar y crear la venta
                var isValid =  _salesService.ValidateTotal(saleEntity) &&  _salesService.ValidateStock(saleEntity);
                if (isValid)
                {
                    _salesService.Add(saleEntity);
                    return Ok(new { status="Venta Creada" });
                }

                return BadRequest(new { status = "No se pudo crear la venta" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "No se pudo crear la venta" }  );
            }
        }
    }
}

