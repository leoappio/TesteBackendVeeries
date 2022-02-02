using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models.Enums;

namespace TesteVeeries.Models.Entities
{
    public class ProductivityRequest
    {
        /// <summary>
        /// 1 = Soja,
        /// 2 = Milho
        /// </summary>
        public CultureEnum Culture { get; set; }
        /// <summary>
        /// 1 = 2020,
        /// 2 = 2019
        /// </summary>
        public YearEnum Year { get; set; }
        /// <summary>
        /// 1 = Sorriso,
        /// 2 = Mato Grosso,
        /// 3 = Brasil
        /// </summary>
        public LocationEnum Location { get; set; }
    }
}
