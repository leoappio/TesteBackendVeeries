using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteVeeries.Models.Interfaces
{
    public interface ICashRepository
    {
        public IEnumerable<CashDTO> GetAll();
        public IEnumerable<CashDTO> GetWithçAtName();
        public IEnumerable<CashDTO> GetWithUAtName();
        public IEnumerable<CashDTO> GetAllEvenAndMultipleOf5Values();
    }
}
