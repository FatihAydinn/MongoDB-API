using RAS.Services.ProductAPI.Dtos;
using RAS.Shared.Dtos;

namespace RAS.Services.ProductAPI.Services
{
    public interface IProductService
    {
           Task<Response<List<GuitarDto>>> GetAllAsync();
           Task<Response<GuitarDto>> GetByIdAsync(string id);
           Task<Response<List<GuitarDto>>> GetAllByUserIdAsync(string userid);
           Task<Response<GuitarDto>> CreateAsync(GuitarCreateDto guitarCreateDto);
           Task<Response<NoContent>> UpdateAsync(GuitarUpdateDto guitarUpdateDto);
           Task<Response<NoContent>> DeleteAsync(string id);
    }
}
