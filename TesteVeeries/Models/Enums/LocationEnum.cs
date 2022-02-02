using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVeeries.Models.Enums
{
    public enum LocationEnum
    {
        [Display(Name = "Sorriso")]
        Sorriso = 1,
        [Display(Name = "Mato Grosso")]
        MatoGrosso = 2,
        [Display(Name = "Brasil")]
        Brasil = 3,


    }
}
