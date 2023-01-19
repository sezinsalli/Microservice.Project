using DiscountApı.Models;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountApı.Service
{
    public class DiscountService : IDiscountService
    {
        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<List<Discount>>> GetAll()
        {
            throw new System.NotImplementedException();
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
