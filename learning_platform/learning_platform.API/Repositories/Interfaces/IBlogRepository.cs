using learning_platform.API.Models;

namespace learning_platform.API.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByUserIdAsync(int userId);
        Task<Blog?> GetByIdAsync(int id);
        Task<Blog?> AddAsync(Blog blog);
        Task<Blog?> UpdateAsync(Blog blog);
        Task<bool> DeleteAsync(int id);
    }
}

