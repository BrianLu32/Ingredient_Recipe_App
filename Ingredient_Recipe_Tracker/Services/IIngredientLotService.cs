using Ingredient_Recipe_Tracker.Model;
using Ingredient_Recipe_Tracker.Model.Requests;

namespace Ingredient_Recipe_Tracker.Services
{
    public interface IIngredientLotService
    {
        Task<IngredientLot> AddIngredientLot(CreateIngredientLotRequest lot);
    }
}
