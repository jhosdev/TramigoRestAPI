namespace TramigoApplication.Infrastructure.Models;

public class Procedure
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public int ReceiptId { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
        
    // Navigation properties (if needed)
    //public User User { get; set; }
    //public Category Category { get; set; }
    //public Receipt Receipt { get; set; }
    
    public Procedure()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}