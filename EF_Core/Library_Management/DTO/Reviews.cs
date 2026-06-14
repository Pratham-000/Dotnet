using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Review 
{
    [Key]
    public int ReviewId { get; set; }
    public string? ReviewText { get; set; }

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }
    [ForeignKey("BookId")]
    public int BookId { get; set; }
    public Books? Book { get; set; }
}
