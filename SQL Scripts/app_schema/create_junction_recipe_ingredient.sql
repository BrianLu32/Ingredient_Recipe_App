CREATE TABLE ingredient_recipe_app.Recipe_Ingredient (
	Recipe_ID INT,
	Ingredient_ID INT,
	Quantity SMALLINT,
	Unit_ID INT,
	
	CONSTRAINT FK_Unit_ID FOREIGN KEY (Unit_ID)
		REFERENCES ingredient_recipe_app.Unit(Unit_ID),
	CONSTRAINT FK_Recipe_ID FOREIGN KEY (Recipe_ID)
		REFERENCES ingredient_recipe_app.Recipe(Recipe_ID),
	CONSTRAINT FK_Ingredient_ID FOREIGN KEY (Ingredient_ID)
		REFERENCES ingredient_recipe_app.Ingredient(Ingredient_ID),
		
	CONSTRAINT PK_Recipe_Ingredient PRIMARY KEY (Recipe_ID, Ingredient_ID)
);