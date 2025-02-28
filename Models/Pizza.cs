namespace ContosoPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsGlutenFree { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsVegetarian { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

