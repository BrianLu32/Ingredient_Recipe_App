using Ingredient_Recipe_Tracker.Model;
using Ingredient_Recipe_Tracker.Repository;

namespace Ingredient_Recipe_Tracker.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsByName(string name)
        {
            return await _repository.GetIngredientsByNameAsync(name);
        }
        public async Task<Ingredient?> GetIngredientById(int id) 
        {
            return await _repository.GetIngredientByIdAsync(id);
        }
    }
}
