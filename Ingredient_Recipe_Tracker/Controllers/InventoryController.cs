using Ingredient_Recipe_Tracker.Model.Requests;
using Ingredient_Recipe_Tracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient_Recipe_Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly IIngredientLotService _ingredientLotService;

        public InventoryController(IIngredientLotService ingredientLotService)
        {
            _ingredientLotService = ingredientLotService;
        }

        [HttpPost("lots")]
        public async Task<ActionResult<CreateIngredientLotRequest>> AddIngredientLot(CreateIngredientLotRequest newIngredientLot)
        {
            var ingredientLot = await _ingredientLotService.AddIngredientLot(newIngredientLot);
            return Ok(ingredientLot);
        }
    }
}
