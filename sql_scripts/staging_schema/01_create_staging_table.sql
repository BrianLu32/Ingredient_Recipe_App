CREATE TABLE IF NOT EXISTS staging.food_staging (
	fdc_id INT PRIMARY KEY,
	food_name TEXT,
	calories DECIMAL(6,2),
	protein DECIMAL(6,2),
	carbs DECIMAL(6,2),
	fat DECIMAL(6,2),
	food_category TEXT,
	portion DECIMAL(6,2),
	unit_full VARCHAR(50),
	unit_abr VARCHAR(20),
	gram_weight DECIMAL(6,2)
);