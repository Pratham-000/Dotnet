using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Books
{
    [Key]
    public int BookId { get; set; }
    public string? Title { get; set; }
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }
    public Authors? Author { get; set; }
}   