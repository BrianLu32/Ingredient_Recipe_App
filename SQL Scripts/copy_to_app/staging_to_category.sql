INSERT INTO ingredient_recipe_app.category (
	category_type
)
SELECT DISTINCT 
	food_category
FROM staging.food_staging
WHERE food_category IS NOT NULL;