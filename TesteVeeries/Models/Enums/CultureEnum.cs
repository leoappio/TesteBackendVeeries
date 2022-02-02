using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVeeries.Models
{
    public enum CultureEnum
    {
        [Display(Name = "Soja")]
        Soja = 1,
        [Display(Name = "Milho")]
        Milho = 2,
    }
}
