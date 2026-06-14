using System.ComponentModel.DataAnnotations;

public class Authors
{
    [Key]
    public int AuthorId { get; set; }
    public string? AuthorName { get; set; }
    

} 