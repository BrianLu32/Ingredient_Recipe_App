INSERT INTO ingredient_recipe_app.nutrition (
	ingredient_id,
	calories,
	carbohydrates,
	protein,
	fat,
	serving_quantity,
	unit_id,
	gram_weight
)
SELECT
	i.ingredient_id,
	fs.calories,
	fs.carbs,
	fs.protein,
	fs.fat,
	fs.portion,
	u.unit_id,
	fs.gram_weight
FROM staging.food_staging fs
LEFT JOIN ingredient_recipe_app.unit u
	ON fs.unit_full = u.unit_name
JOIN ingredient_recipe_app.ingredient i
	ON fs.fdc_id = i.fdc_id;