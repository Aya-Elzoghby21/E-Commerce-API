using E_commerce.DTOs.CategoryDTOs;
using E_commerce.Models;
using E_commerce.Repositry;
using E_commerce.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _categoryRepo;

    public CategoryService(IGenericRepository<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepo.GetAllAsync();
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        });
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null) return null;

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public async Task AddAsync(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };
        await _categoryRepo.AddAsync(category);
        await _categoryRepo.SaveAsync();
    }

    public async Task UpdateAsync(int id, CreateCategoryDto dto)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null) return;

        category.Name = dto.Name;
        category.Description = dto.Description;

        _categoryRepo.Update(category);
        await _categoryRepo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null) return;

        _categoryRepo.Delete(category);
        await _categoryRepo.SaveAsync();
    }
}
