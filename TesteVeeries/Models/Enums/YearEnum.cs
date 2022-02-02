using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVeeries.Models.Enums
{
    public enum YearEnum
    {
        [Display(Name = "2020")]
        _2020 = 1,
        [Display(Name = "2019")]
        _2019 = 2,
    }
}
