using RAS.Services.ProductAPI.Dtos;
using RAS.Services.ProductAPI.Models;
using RAS.Shared.Dtos;

namespace RAS.Services.ProductAPI.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
