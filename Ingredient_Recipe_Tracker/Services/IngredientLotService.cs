using Ingredient_Recipe_Tracker.Model;
using Ingredient_Recipe_Tracker.Model.Requests;
using Ingredient_Recipe_Tracker.Repository;

namespace Ingredient_Recipe_Tracker.Services
{
    public class IngredientLotService : IIngredientLotService
    {
        private readonly IIngredientLotRepository _repository;

        public IngredientLotService(IIngredientLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<IngredientLot> AddIngredientLot(CreateIngredientLotRequest lot)
        {
            var ingredientLot = new IngredientLot
            {
                IngredientId = lot.IngredientId,
                RemainingQuantity = lot.RemainingQuantity,
                UnitId = lot.UnitId,
                Location = lot.Location,
                ReceivedDate = lot.ReceivedDate,
                ExpirationDate = lot.ExpirationDate
            };
            return await _repository.AddIngredientLotAsync(ingredientLot);
        }
    }
}
