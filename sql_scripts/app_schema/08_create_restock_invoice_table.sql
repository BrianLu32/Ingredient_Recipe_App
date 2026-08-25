CREATE TABLE IF NOT EXISTS ingredient_recipe_app.Restock_Invoice (
	Invoice_ID INT PRIMARY KEY,
	Transaction_Type VARCHAR(100),
	Quantity SMALLINT,
	Unit_ID INT,
	Transaction_Date DATE,
	Supplier_ID INT,
	
	CONSTRAINT FK_Unit_ID FOREIGN KEY (Unit_ID)
		REFERENCES ingredient_recipe_app.Unit(Unit_ID),
		
	CONSTRAINT FK_Supplier_ID FOREIGN KEY (Supplier_ID)
		REFERENCES ingredient_recipe_app.Supplier(Supplier_ID)
);