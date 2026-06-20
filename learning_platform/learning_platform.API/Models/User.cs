using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learning_platform.API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public ICollection<Note> Notes { get; set; } = new List<Note>();

        [JsonIgnore]
        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();

        [JsonIgnore]
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}