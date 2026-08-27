using Dapper;
using Ingredient_Recipe_Tracker.Model;
using Npgsql;

namespace Ingredient_Recipe_Tracker.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public IngredientRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsByNameAsync(string name)
        {
            const string sql = """
                SELECT
                	i.IngredientId,
                	i.IngredientName,
                	c.CategoryType,
                	n.CaloriesPer100g,
                	n.CarbohydratesPer100g,
                	n.ProteinPer100g,
                	n.FatPer100g,
                	sq.ServingQuantity,
                	u.UnitName
                FROM ingredient_recipe_app.Ingredient i
                JOIN ingredient_recipe_app.Category c
                	ON c.CategoryId = i.CategoryId
                JOIN ingredient_recipe_app.Nutrition n
                	ON n.IngredientId = i.IngredientId
                JOIN ingredient_recipe_app.ServingQuantity sq
                	ON sq.IngredientId = i.IngredientId
                JOIN ingredient_recipe_app.Unit u
                	ON u.UnitId = sq.UnitId
                WHERE i.IngredientName ILIKE @IngredientName;
                """;

            await using var connection = await _dataSource.OpenConnectionAsync();

            return await connection.QueryAsync<Ingredient>(
                sql,
                new { IngredientName = $"%{name}%" }
            );
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(int id)
        {
            const string sql = """
                SELECT
                	i.IngredientId,
                	i.IngredientName,
                	c.CategoryType,
                	n.CaloriesPer100g,
                	n.CarbohydratesPer100g,
                	n.ProteinPer100g,
                	n.FatPer100g,
                	sq.ServingQuantity,
                	u.UnitName
                FROM ingredient_recipe_app.Ingredient i
                JOIN ingredient_recipe_app.Category c
                	ON c.CategoryId = i.CategoryId
                JOIN ingredient_recipe_app.Nutrition n
                	ON n.IngredientId = i.IngredientId
                JOIN ingredient_recipe_app.ServingQuantity sq
                	ON sq.IngredientId = i.IngredientId
                JOIN ingredient_recipe_app.Unit u
                	ON u.UnitId = sq.UnitId
                WHERE i.IngredientId = @Id
                """;

            await using var connection = await _dataSource.OpenConnectionAsync();

            return await connection.QuerySingleOrDefaultAsync<Ingredient>(
                sql,
                new { Id = id }
            );
        }
    }
}
