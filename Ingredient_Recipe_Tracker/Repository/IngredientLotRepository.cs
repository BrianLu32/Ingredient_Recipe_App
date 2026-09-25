using Dapper;
using Ingredient_Recipe_Tracker.Model;
using Npgsql;
using System.Data;

namespace Ingredient_Recipe_Tracker.Repository
{
    public class IngredientLotRepository : IIngredientLotRepository
    {
        private readonly NpgsqlDataSource _dataSource;

        public IngredientLotRepository(NpgsqlDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<IngredientLot> AddIngredientLotAsync(IngredientLot lot)
        {
            const string sql = """
                INSERT INTO ingredient_recipe_app.IngredientLot 
                (
                	IngredientId,
                	RemainingQuantity,
                	UnitId,
                	Location,
                	ReceivedDate,
                	ExpirationDate
                )
                VALUES
                (
                    @IngredientId,
                    @RemainingQuantity,
                    @UnitId,
                    @Location,
                    @ReceivedDate,
                    @ExpirationDate
                )
                RETURNING
                    IngredientLotId,
                    IngredientId,
                    RemainingQuantity,
                    UnitId,
                    Location,
                    ReceivedDate,
                    ExpirationDate;
                """;

            await using var connection = await _dataSource.OpenConnectionAsync();

            var parameters = new DynamicParameters();

            parameters.Add("IngredientId", lot.IngredientId);
            parameters.Add("RemainingQuantity", lot.RemainingQuantity);
            parameters.Add("UnitId", lot.UnitId);
            parameters.Add("Location", lot.Location);

            parameters.Add(
                "ReceivedDate",
                lot.ReceivedDate,
                DbType.Date
            );

            parameters.Add(
                "ExpirationDate",
                lot.ExpirationDate,
                DbType.Date
            );

            return await connection.QuerySingleAsync<IngredientLot>(
                sql,
                parameters
            );
        }
    }
}
