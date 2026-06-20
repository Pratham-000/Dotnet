using learning_platform.API.Models;

namespace learning_platform.API.Repositories.Interfaces
{
    public interface IQuizAttemptRepository
    {
        Task<List<QuizAttempt>> GetAllAsync();
        Task<List<QuizAttempt>> GetByUserIdAsync(int userId);
        Task<List<QuizAttempt>> GetByQuizIdAsync(int quizId);
        Task<QuizAttempt?> GetByIdAsync(int id);
        Task<QuizAttempt> AddAsync(QuizAttempt attempt);
        Task<bool> DeleteAsync(int id);
    }
}