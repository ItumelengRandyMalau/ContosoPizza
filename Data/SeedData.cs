using ContosoPizza.Models;

namespace ContosoPizza.Data;

public static class SeedData
{
    public static void Initialize(PizzaContext context)
    {
        if (context.Pizzas.Any())
            return; // DB has been seeded

        context.Pizzas.AddRange(
            new Pizza
            {
                Name = "Classic Pepperoni",
                IsGlutenFree = false,
                Price = 12.99M,
                Description = "Our classic pepperoni pizza with mozzarella cheese and tomato sauce",
                ImageUrl = "/images/pepperoni.jpg",
                IsVegetarian = false
            },
            new Pizza
            {
                Name = "Veggie Supreme",
                IsGlutenFree = true,
                Price = 15.99M,
                Description = "A vegetarian delight with bell peppers, mushrooms, onions, and olives",
                ImageUrl = "/images/veggie.jpg",
                IsVegetarian = true
            },
            new Pizza
            {
                Name = "Meat Lovers",
                IsGlutenFree = false,
                Price = 17.99M,
                Description = "Loaded with pepperoni, sausage, bacon, and ham for meat lovers",
                ImageUrl = "/images/meat-lovers.jpg",
                IsVegetarian = false
            }
        );

        context.SaveChanges();
    }
}
