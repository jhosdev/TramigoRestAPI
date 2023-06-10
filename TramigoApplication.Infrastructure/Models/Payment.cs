namespace TramigoApplication.Infrastructure.Models;

public class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public string Type { get; set; }
    public int CardNumber { get; set; }
    public int Cvv { get; set; }
    public DateTime ExpirationDate { get; set; }
    
    
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
        
    // Navigation properties (if needed)
    public User User { get; set; }
    
    public Payment()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}