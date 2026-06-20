using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learning_platform.API.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public int QuizId { get; set; }

        [Required]
        public string QuestionText { get; set; } = string.Empty;

        [Required]
        public string OptionA { get; set; } = string.Empty;

        [Required]
        public string OptionB { get; set; } = string.Empty;

        [Required]
        public string OptionC { get; set; } = string.Empty;

        [Required]
        public string OptionD { get; set; } = string.Empty;

        [Required]
        public string CorrectAnswer { get; set; } = string.Empty;

        [JsonIgnore]
        public Quiz? Quiz { get; set; }
    }
}
// Id
// QuizId
// QuestionText
// OptionA
// OptionB
// OptionC
// OptionD
// CorrectAnswer