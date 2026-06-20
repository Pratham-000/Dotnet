using learning_platform.API.Models;

namespace learning_platform.API.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<List<Note>> GetByUserIdAsync(int userId);
        Task<Note?> GetByIdAsync(int id);
        Task<Note> AddAsync(Note note);
        Task<Note?> UpdateAsync(Note note);
        Task<bool> DeleteAsync(int id);
    }
}