using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);

        Task<Product?> GetByIdAsync(Guid id);

        Task<List<Product>> GetAllAsync();

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
