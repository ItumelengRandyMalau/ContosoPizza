namespace ContosoPizza.Models.DTOs;

public class PizzaDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsGlutenFree { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsVegetarian { get; set; }
    public bool IsAvailable { get; set; }
}

public class CreatePizzaDTO
{
    public string Name { get; set; } = null!;
    public bool IsGlutenFree { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsVegetarian { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public class UpdatePizzaDTO
{
    public string Name { get; set; } = null!;
    public bool IsGlutenFree { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool IsVegetarian { get; set; }
    public bool IsAvailable { get; set; }
}

