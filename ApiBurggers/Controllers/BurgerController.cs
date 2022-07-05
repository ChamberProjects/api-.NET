namespace ApiBurggers.Controllers;
using ApiBurggers.Services;
using ApiBurggers.Models;
using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[Controller]")]
public class BurgerController : ControllerBase    
{
    public BurgerController()
        {
        }

    [HttpGet]
    public ActionResult<List<Burger>> GetAll() =>
    BurgerService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Burger> Get(int id)
    {

        var burger = BurgerService.Get(id);

        if (burger == null)
            return NotFound();

        return burger;
    }

    [HttpPost]
    public IActionResult Create(Burger burger)
    {
        BurgerService.Add(burger);
        return CreatedAtAction(nameof(Create), new { id = burger.Id }, burger);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Burger burger)
    {
        if (id != burger.Id)
            return BadRequest();

        var existingPizza = BurgerService.Get(id);
        if (existingPizza is null)
            return NotFound();

        BurgerService.Update(burger);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = BurgerService.Get(id);

        if (pizza is null)
            return NotFound();

        BurgerService.Delete(id);

        return NoContent();
    }
}



