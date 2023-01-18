using BasketAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using System.Threading.Tasks;

namespace BasketAPI.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete(string userId);

    }
}
