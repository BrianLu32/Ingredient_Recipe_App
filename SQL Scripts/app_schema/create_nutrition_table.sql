CREATE TABLE ingredient_recipe_app.Nutrition (
	Ingredient_ID INT Primary Key,
	Calories DECIMAL(6,2),
	Carbohydrates DECIMAL(6,2),
	Protein DECIMAL(6,2),
	Fat DECIMAL(6,2),
	Serving_Quantity SMALLINT,
	Unit_ID INT,
	
	CONSTRAINT FK_Unit_ID FOREIGN KEY (Unit_ID)
		REFERENCES ingredient_recipe_app.Unit(Unit_ID),
	CONSTRAINT FK_Ingredient_ID FOREIGN KEY (Ingredient_ID)
		REFERENCES ingredient_recipe_app.Ingredient(Ingredient_ID)
);