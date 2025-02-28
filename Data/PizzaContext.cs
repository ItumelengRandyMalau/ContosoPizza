using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options)
    : base(options)
    {
    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
}

