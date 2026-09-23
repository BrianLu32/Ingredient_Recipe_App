using Ingredient_Recipe_Tracker.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient_Recipe_Tracker.Repository
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name);
        Task<IEnumerable<Ingredient>> GetIngredientByIdAsync(int id);
    }
}
