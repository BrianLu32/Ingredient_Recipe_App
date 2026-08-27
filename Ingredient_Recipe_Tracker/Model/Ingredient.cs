namespace Ingredient_Recipe_Tracker.Model
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public string CategoryType { get; set; }

        public decimal CaloriesPer100g { get; set; }

        public decimal CarbohydratesPer100g { get; set; }

        public decimal ProteinPer100g { get; set; }

        public decimal FatPer100g { get; set; }

        public decimal ServingQuantity { get; set; }

        public string UnitName { get; set; }
    }
}
