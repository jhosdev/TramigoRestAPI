using System.ComponentModel.DataAnnotations;

namespace TramigoApplication.Infrastructure.Models;

public class Receipt
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public float Amount { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
        
    // Navigation properties (if needed)
    //public Procedure Procedure { get; set; }
    
    public Receipt()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}