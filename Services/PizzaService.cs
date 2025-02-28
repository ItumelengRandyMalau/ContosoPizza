using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }

    public async Task<List<Pizza>> GetAllAsync()
    {
        return await _context.Pizzas.ToListAsync();
    }

    public async Task<Pizza?> GetByIdAsync(int id)
    {
        return await _context.Pizzas.FindAsync(id);
    }

    public async Task<Pizza> CreateAsync(Pizza newPizza)
    {
        _context.Pizzas.Add(newPizza);
        await _context.SaveChangesAsync();
        return newPizza;
    }

    public async Task<bool> UpdateAsync(Pizza updatedPizza)
    {
        var pizza = await _context.Pizzas.FindAsync(updatedPizza.Id);

        if (pizza == null)
            return false;

        pizza.Name = updatedPizza.Name;
        pizza.IsGlutenFree = updatedPizza.IsGlutenFree;
        pizza.Price = updatedPizza.Price;
        pizza.Description = updatedPizza.Description;
        pizza.ImageUrl = updatedPizza.ImageUrl;
        pizza.IsVegetarian = updatedPizza.IsVegetarian;
        pizza.IsAvailable = updatedPizza.IsAvailable;
        pizza.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

        if (pizza == null)
            return false;

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();
        return true;
    }
}

