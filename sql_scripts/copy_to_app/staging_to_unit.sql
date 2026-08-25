INSERT INTO ingredient_recipe_app.unit (
	unit_name,
	unit_abbreviation
)
SELECT DISTINCT
	unit_full,
	unit_abr
FROM staging.food_staging
WHERE unit_full IS NOT NULL;