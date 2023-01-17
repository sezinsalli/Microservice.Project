using CatalogAPI.Dtos;
using CatalogAPI.Models;
using MongoDB.Driver;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogAPI.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
