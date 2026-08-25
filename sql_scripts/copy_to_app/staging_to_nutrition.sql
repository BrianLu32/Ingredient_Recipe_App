INSERT INTO ingredient_recipe_app.nutrition (
	ingredient_id,
	calories_per_100g,
	carbohydrates_per_100g,
	protein_per_100g,
	fat_per_100g
)
SELECT
	i.ingredient_id,
	fs.calories,
	fs.carbs,
	fs.protein,
	fs.fat
FROM staging.food_staging fs
JOIN ingredient_recipe_app.ingredient i
	ON fs.fdc_id = i.fdc_id;