CREATE TABLE ingredient_recipe_app.Serving_Quantity (
	Serving_Quantity_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Ingredient_ID INT,
	Serving_Quantity DECIMAL(6,2),
	Unit_ID INT,
	Gram_Weight DECIMAL(6,2),

	CONSTRAINT FK_Unit_ID FOREIGN KEY (Unit_ID)
		REFERENCES ingredient_recipe_app.Unit(Unit_ID),
	CONSTRAINT FK_Ingredient_ID FOREIGN KEY (Ingredient_ID)
		REFERENCES ingredient_recipe_app.Ingredient(Ingredient_ID)
);