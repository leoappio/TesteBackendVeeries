using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models.Entities;
using TesteVeeries.Models.Interfaces;

namespace TesteVeeries.Repositories
{
    public class ProvincesOfUkraineRepository : IProvincesOfUkraineRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public ProvincesOfUkraineRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }
        public IEnumerable<ProvincesOfUkraineDTO> GetAll()
        {
            List<ProvincesOfUkraineDTO> provincesList = new();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM UKRAINE_PROVINCES", connection);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                ProvincesOfUkraineDTO cash = new()
                {
                    Name = reader["NAME"].ToString(),
                    Capital = reader["CAPITAL"].ToString(),
                    Area = reader["AREA"].ToString(),
                };

                provincesList.Add(cash);
            }

            connection.Close();

            return provincesList;
        }
    }
}
