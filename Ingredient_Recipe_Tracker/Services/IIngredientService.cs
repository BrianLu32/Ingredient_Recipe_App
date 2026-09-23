using Ingredient_Recipe_Tracker.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ingredient_Recipe_Tracker.Services
{
    public interface IIngredientService
    {
        Task<IEnumerable<Ingredient>> GetIngredientsByName(string name);
        Task<IEnumerable<Ingredient>> GetIngredientById(int id);
    }
}
