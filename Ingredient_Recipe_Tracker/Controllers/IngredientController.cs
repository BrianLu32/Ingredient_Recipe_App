using Ingredient_Recipe_Tracker.Model;
using Ingredient_Recipe_Tracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient_Recipe_Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetByName(string name)
        {
            var ingredients = await _ingredientService.GetIngredientsByName(name);
            return Ok(ingredients);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ingredient?>> GetById(int id)
        {
            var ingredient = await _ingredientService.GetIngredientById(id);

            if (ingredient == null) { return NotFound(); }
            return Ok(ingredient);
        }
    }
}
