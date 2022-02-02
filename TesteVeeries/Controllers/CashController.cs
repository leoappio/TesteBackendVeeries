using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models.Interfaces;
using TesteVeeries.Repositories;

namespace TesteVeeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        ICashRepository _cashRepository;

        public CashController(ICashRepository cashRepository)
        {
            _cashRepository = cashRepository;
        }

        [HttpGet]
        [Route("/GetAll")]
        public ActionResult GetAll()
        {
            return Ok(_cashRepository.GetAll());
        }

        [HttpGet]
        [Route("/GetAllWithçAtName")]
        public ActionResult GetAllWithçAtName()
        {
            return Ok(_cashRepository.GetWithçAtName());
        }

        [HttpGet]
        [Route("/GetAllWithUAtName")]
        public ActionResult GetAllWithUAtName()
        {
            return Ok(_cashRepository.GetWithUAtName());
        }

        [HttpGet]
        [Route("/GetAllEvenAndMultipleOf5Values")]
        public ActionResult GetAllEvenAndMultipleOf5Values()
        {
            return Ok(_cashRepository.GetAllEvenAndMultipleOf5Values());
        }
    }
}
