using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models.Entities;
using TesteVeeries.Models.Interfaces;

namespace TesteVeeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductivityController : ControllerBase
    {
        private readonly IProductivityRepository _productivityRepository;

        public ProductivityController(IProductivityRepository productivityRepository)
        {
            _productivityRepository = productivityRepository;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] ProductivityRequest request)
        {
            double productivity = _productivityRepository.GetProductivity(request);
            return Ok(new { production = productivity.ToString("F") + " sc/ha" });
        }
    }
}
