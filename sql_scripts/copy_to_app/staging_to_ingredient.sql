INSERT INTO ingredient_recipe_app.ingredient (
	ingredient_name, 
	category_id,
	fdc_id
)
SELECT DISTINCT 
	fs.food_name,
	c.category_id,
	fs.fdc_id
FROM staging.food_staging fs
JOIN ingredient_recipe_app.category c
	ON fs.food_category = c.category_type
WHERE fs.food_name IS NOT NULL;