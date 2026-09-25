using System.ComponentModel.DataAnnotations;

namespace Ingredient_Recipe_Tracker.Model.Requests
{
    public class CreateIngredientLotRequest
    {
        [Range(1, int.MaxValue)]
        public int IngredientId { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal RemainingQuantity { get; set; }

        public int? UnitId { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        public DateOnly ReceivedDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public DateOnly? ExpirationDate { get; set; }
    }
}
