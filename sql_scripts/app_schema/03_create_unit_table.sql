CREATE TABLE IF NOT EXISTS ingredient_recipe_app.Unit (
	Unit_ID INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	Unit_Name VARCHAR(20),
	Unit_Abbreviation VARCHAR(10),
	Conversion_to_base SMALLINT
);