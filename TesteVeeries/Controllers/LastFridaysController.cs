using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVeeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastFridaysController : ControllerBase
    {
        [HttpGet]
        [Route("GetLastFridaysByYear")]
        public ActionResult GetLastFridays(string year)
        {
            List<string> lastFridays = new();
            if (year.All(char.IsDigit))
            {
                int yearInt = int.Parse(year);
                for (var month = 1; month <= 12; month++)
                {
                    var date = new DateTime(yearInt, month, 1).AddMonths(1).AddDays(-1);
                    while (date.DayOfWeek != DayOfWeek.Friday)
                    {
                        date = date.AddDays(-1);
                    }
                    lastFridays.Add(date.ToString("dd/MM/yyyy"));
                }
            }
            else
            {
                return BadRequest("The year parameter need to be a number");
            }

            return Ok(lastFridays);

        }
    }
}
