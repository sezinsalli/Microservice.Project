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

        public async Task<Response<NoContent>> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("Delete from discount where id=@Id", new { Id = id });
            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found.",404);
        }

        public async Task<Response<List<Discount>>> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select*from discount");

            return Response<List<Discount>>.Success(discounts.ToList(), 200);
        }

        public async Task<Response<Discount>> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select *from discount where userid=@UserId and code=@Code", new {UserId=userId,Code=code});

            var hasDiscount = discounts.FirstOrDefault();

            if (hasDiscount==null)
            {
                return Response<Models.Discount>.Fail("Discount not found",404);

            }
            return Response<Models.Discount>.Success(hasDiscount, 200);
        }

        public async Task<Response<Discount>> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select*from discount whre id=@Id", new { id })).SingleOrDefault();
            if (discount==null)
            {
                return Response<Discount>.Fail("Discount not found", 404);

            }
            return Response<Discount>.Success(discount, 200);
        }

        public async Task<Response<NoContent>> Save(Discount discount)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("Inser into discount (userid,rate,code) values (@userid,@rate,@code)",discount);
            if (saveStatus>0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("An Error pccured while adding", 500);
        }

        public async Task<Response<NoContent>> Update(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@userId,code=@Code,rate=@Rate where id=@Id", new {Id=discount.Id,UserId=discount.UserId,Code=discount.Code,Rate=discount.Rate});
            if (status>0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("A error occured while updating.", 500);
        }

       
    }
}
