using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models.Entities;

namespace TesteVeeries.Models.Interfaces
{
    public interface IProvincesOfUkraineRepository
    {
        public IEnumerable<ProvincesOfUkraineDTO> GetAll();
    }
}
