CREATE TABLE ingredient_recipe_app.Ingredient (
	Ingredient_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Ingredient_Name TEXT,
	Category_ID INT
);