using Ingredient_Recipe_Tracker.Model;

namespace Ingredient_Recipe_Tracker.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetIngredientsByName(string name);
        Task<Ingredient?> GetIngredientById(int id);
    }
}
