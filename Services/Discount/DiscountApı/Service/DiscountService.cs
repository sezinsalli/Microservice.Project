using Dapper;
using DiscountApı.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Shared.Dtos;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountApı.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;
        public DiscountService(IConfiguration configuration, IDbConnection dbConnection)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select*from discount");

            return Response<List<Discount>>.Success(discounts.ToList(), 200);
        }

        public Task<Response<Discount>> GetByCodeAndUserId(string code, string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<List<Discount>>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<NoContent>> Save(Discount discount)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<NoContent>> Update(Discount discount)
        {
            throw new System.NotImplementedException();
        }
    }
}
