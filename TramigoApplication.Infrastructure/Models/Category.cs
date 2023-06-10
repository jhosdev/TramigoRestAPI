namespace TramigoApplication.Infrastructure.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    // Navigation properties (if needed)
    //public List<Procedure> Procedure { get; set; }
}