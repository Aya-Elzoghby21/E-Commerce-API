using AutoMapper;
using E_commerce.DTOs.ProductDTOs;
using E_commerce.Models;
using E_commerce.Repositry;
using Microsoft.AspNetCore.Hosting;

namespace E_commerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ProductService(IGenericRepository<Product> productRepo, IMapper mapper, IWebHostEnvironment env)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            var products = await _productRepo.GetAllAsync();
            var paged = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return _mapper.Map<IEnumerable<ProductDto>>(paged);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            if (dto.Images != null && dto.Images.Any())
            {
                var image = dto.Images.First();
                var imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "images", imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                product.Urlimage = $"/images/{imageName}";
            }

            await _productRepo.AddAsync(product);
            await _productRepo.SaveAsync();
        }

        public async Task UpdateAsync(int id, CreateProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new Exception("Product Not Found");

            
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.CategoryId = dto.CategoryId;

          
            if (dto.Images != null && dto.Images.Any())
            {
                
                if (!string.IsNullOrEmpty(product.Urlimage))
                {
                    var oldPath = Path.Combine(_env.WebRootPath, product.Urlimage.TrimStart('/'));
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                var image = dto.Images.First();
                var imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(_env.WebRootPath, "images", imageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                product.Urlimage = $"/images/{imageName}";
            }

            _productRepo.Update(product);
            await _productRepo.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new Exception("Product Not Found");

            if (!string.IsNullOrEmpty(product.Urlimage))
            {
                var path = Path.Combine(_env.WebRootPath, product.Urlimage.TrimStart('/'));
                if (File.Exists(path))
                    File.Delete(path);
            }

            _productRepo.Delete(product);
            await _productRepo.SaveAsync();
        }
    }
}
