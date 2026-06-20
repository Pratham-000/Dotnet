using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learning_platform.API.Models
{
    public class QuizAttempt
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int Score { get; set; }
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Quiz? Quiz { get; set; }
    }
}