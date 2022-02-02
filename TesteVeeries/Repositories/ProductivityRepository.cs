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
    public class ProductivityRepository : IProductivityRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public ProductivityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public double GetProductivity(ProductivityRequest request)
        {
            int culture = 1;
            string table = "";
            int year = 0;

            if(request.Culture == Models.CultureEnum.Soja)
            {
                culture = 1;
            }
            else
            {
                culture = 2;
            }

            if(request.Year == Models.Enums.YearEnum._2020)
            {
                year = 2020;
            }
            else
            {
                year = 2019;
            }

            if(request.Location == Models.Enums.LocationEnum.Sorriso)
            {
                table = "CITIES_PRODUCTION";

            }else if(request.Location == Models.Enums.LocationEnum.MatoGrosso)
            {
                table = "STATES_PRODUCTION";
            }
            else
            {
                table = "COUNTRIES_PRODUCTION";
            }


            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand($"SELECT * FROM {table} WHERE CULTIVATION_ID = {culture} AND YEAR = {year}", connection);
            SqlDataReader reader = query.ExecuteReader();

            long production = 0;
            long area = 0;

            while (reader.Read())
            {
                production = int.Parse(reader["PRODUCTION"].ToString());
                area = int.Parse(reader["AREA"].ToString());
            
            }

            connection.Close();

            return CalculateProductivity(production, area);

        }


        public double CalculateProductivity(long production, long area)
        {
            double productionInSC = (production * 1000) / 60;

            return productionInSC / area;

        }
    }
}
