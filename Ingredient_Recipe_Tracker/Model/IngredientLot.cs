namespace Ingredient_Recipe_Tracker.Model
{
    public class IngredientLot
    {
        public int IngredientLotId { get; set; }

        public int IngredientId { get; set; }

        public decimal RemainingQuantity { get; set; }

        public int? UnitId { get; set; }

        public string Location { get; set; }

        public DateOnly ReceivedDate { get; set; }

        public DateOnly? ExpirationDate { get; set; }
    }
}
