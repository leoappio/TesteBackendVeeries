using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteVeeries.Models;
using TesteVeeries.Models.Interfaces;

namespace TesteVeeries.Repositories
{
    public class CashRepository : ICashRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public CashRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
        }

        public IEnumerable<CashDTO> GetAll()
        {
            List<CashDTO> cashList = new();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM CASH",connection);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                CashDTO cash = new()
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    Value = int.Parse(reader["CASH_VALUE"].ToString()),
                    Animal = reader["CASH_ANIMAL"].ToString(),
                };

                cashList.Add(cash);
            }

            connection.Close();

            return cashList;
        }

        public IEnumerable<CashDTO> GetWithçAtName()
        {
            List<CashDTO> cashList = new();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM CASH WHERE CASH_ANIMAL LIKE '%ç%'", connection);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                CashDTO cash = new()
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    Value = int.Parse(reader["CASH_VALUE"].ToString()),
                    Animal = reader["CASH_ANIMAL"].ToString(),
                };

                cashList.Add(cash);
            }

            connection.Close();

            return cashList;
        }

        public IEnumerable<CashDTO> GetWithUAtName()
        {
            List<CashDTO> cashList = new();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM CASH WHERE CASH_ANIMAL LIKE '%u%'", connection);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                CashDTO cash = new()
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    Value = int.Parse(reader["CASH_VALUE"].ToString()),
                    Animal = reader["CASH_ANIMAL"].ToString(),
                };

                cashList.Add(cash);
            }

            connection.Close();

            return cashList;
        }
        public IEnumerable<CashDTO> GetAllEvenAndMultipleOf5Values()
        {
            List<CashDTO> cashList = new();
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM CASH WHERE CASH_VALUE % 2 = 0 AND CASH_VALUE % 5 = 0", connection);
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                CashDTO cash = new()
                {
                    Id = int.Parse(reader["ID"].ToString()),
                    Value = int.Parse(reader["CASH_VALUE"].ToString()),
                    Animal = reader["CASH_ANIMAL"].ToString(),
                };

                cashList.Add(cash);
            }

            connection.Close();

            return cashList;
        }

    }
}
