CREATE TABLE ingredient_recipe_app.Recipe (
	Recipe_ID INT PRIMARY KEY,
	Recipe_Name VARCHAR(100),
	Serving_Count SMALLINT,
	Cost_per_Recipe DECIMAL(6,2),
	Cost_per_Serving DECIMAL(6,2)
);