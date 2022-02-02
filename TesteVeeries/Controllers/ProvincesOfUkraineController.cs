using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TesteVeeries.Models.Entities;
using TesteVeeries.Models.Interfaces;

namespace TesteVeeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesOfUkraineController : ControllerBase
    {
        private readonly IProvincesOfUkraineRepository _provincesOfUkraineRepository;

        public ProvincesOfUkraineController(IProvincesOfUkraineRepository provincesOfUkraineRepository)
        {
            _provincesOfUkraineRepository = provincesOfUkraineRepository;
        }

        [HttpGet]
        public FileResult GetCSVFile()
        {
            List<ProvincesOfUkraineDTO> listProvinces = (List<ProvincesOfUkraineDTO>)_provincesOfUkraineRepository.GetAll();
            byte[] fileBytes = null;

            if (listProvinces.Count > 0)
            {
                bool isFirstIteration = true;
                StringBuilder sb = new StringBuilder();
                PropertyInfo[] Props = typeof(ProvincesOfUkraineDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (ProvincesOfUkraineDTO pronvice in listProvinces)
                {
                    string[] propertyNames = pronvice.GetType().GetProperties().Select(p => p.Name).ToArray();
                    foreach (var prop in propertyNames)
                    {
                        if (isFirstIteration == true)
                        {
                            for (int j = 0; j < propertyNames.Length; j++)
                            {
                                sb.Append("" + propertyNames[j] + "" + ',');
                            }
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("\r\n");
                            isFirstIteration = false;
                        }
                        object propValue = pronvice.GetType().GetProperty(prop).GetValue(pronvice, null);
                        sb.Append("" + propValue + "" + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("\r\n");

                    fileBytes = Encoding.UTF8.GetBytes(sb.ToString());
                }
            }

            return File(fileBytes, "text/csv", "ukraine_provinces.csv");
        }


    }
}
