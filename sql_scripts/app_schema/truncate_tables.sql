-- Intended use during development process
-- Clears all data from all tables in ingredient_recipe_app schema
DO $$ 
DECLARE
    statements CURSOR FOR
        SELECT tablename
        FROM pg_tables
        WHERE schemaname = 'ingredient_recipe_app';
BEGIN
    FOR stmt IN statements LOOP
        EXECUTE 'TRUNCATE TABLE ingredient_recipe_app.' || quote_ident(stmt.tablename) || ' RESTART IDENTITY CASCADE';
    END LOOP ;
END $$