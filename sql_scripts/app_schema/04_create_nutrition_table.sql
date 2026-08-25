CREATE TABLE IF NOT EXISTS ingredient_recipe_app.Nutrition (
	Ingredient_ID INT Primary Key,
	Calories_per_100g DECIMAL(6,2),
	Carbohydrates_per_100g DECIMAL(6,2),
	Protein_per_100g DECIMAL(6,2),
	Fat_per_100g DECIMAL(6,2),
		
	CONSTRAINT FK_Ingredient_ID FOREIGN KEY (Ingredient_ID)
		REFERENCES ingredient_recipe_app.Ingredient(Ingredient_ID)
);