using E_commerce.DTOs.ProductDTOs;

namespace E_commerce.Services
{
    public interface IProductService
    {
       
        Task<IEnumerable<ProductDto>> GetAllAsync(int page = 1, int pageSize = 10);


        Task<ProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(int id, CreateProductDto dto);
        Task DeleteAsync(int id);
    }

}
