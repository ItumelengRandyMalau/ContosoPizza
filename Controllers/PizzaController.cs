using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaService _pizzaService;
    private readonly ILogger<PizzaController> _logger;

    public PizzaController(PizzaService pizzaService, ILogger<PizzaController> logger)
    {
        _pizzaService = pizzaService;
        _logger = logger;
    }

    // GET: api/Pizza
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
    {
        _logger.LogInformation("Getting all pizzas");
        return await _pizzaService.GetAllAsync();
    }

    // GET: api/Pizza/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> GetPizza(int id)
    {
        _logger.LogInformation("Getting pizza with ID: {Id}", id);
        var pizza = await _pizzaService.GetByIdAsync(id);

        if (pizza == null)
        {
            _logger.LogWarning("Pizza with ID: {Id} not found", id);
            return NotFound();
        }

        return pizza;
    }

    // POST: api/Pizza
    [HttpPost]
    public async Task<ActionResult<Pizza>> CreatePizza(Pizza pizza)
    {
        _logger.LogInformation("Creating a new pizza");
        await _pizzaService.CreateAsync(pizza);

        return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
    }

    // PUT: api/Pizza/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePizza(int id, Pizza pizza)
    {
        _logger.LogInformation("Updating pizza with ID: {Id}", id);

        if (id != pizza.Id)
        {
            _logger.LogWarning("ID mismatch: {Id} vs {PizzaId}", id, pizza.Id);
            return BadRequest();
        }

        var success = await _pizzaService.UpdateAsync(pizza);

        if (!success)
        {
            _logger.LogWarning("Pizza with ID: {Id} not found for update", id);
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Pizza/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePizza(int id)
    {
        _logger.LogInformation("Deleting pizza with ID: {Id}", id);
        var success = await _pizzaService.DeleteAsync(id);

        if (!success)
        {
            _logger.LogWarning("Pizza with ID: {Id} not found for deletion", id);
            return NotFound();
        }

        return NoContent();
    }
}

