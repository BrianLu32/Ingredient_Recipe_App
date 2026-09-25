using Ingredient_Recipe_Tracker.Model;

namespace Ingredient_Recipe_Tracker.Repository
{
    public interface IIngredientLotRepository
    {
        Task<IngredientLot> AddIngredientLotAsync(IngredientLot lot);
    }
}
