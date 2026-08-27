using Ingredient_Recipe_Tracker.Model;

namespace Ingredient_Recipe_Tracker.Repository
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name);
        Task<Ingredient?> GetIngredientByIdAsync(int id);
    }
}
