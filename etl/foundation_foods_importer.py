import json
import csv

def parse_food(food):
    row = {
        "fdc_id": food["fdcId"],
        "name": food["description"],
        "calories": None,
        "protein": None,
        "carbs": None,
        "fat": None
    }

    for food_nutrient in food["foodNutrients"]:
        nutrient = food_nutrient["nutrient"]
        nutrient_id = nutrient["id"]

        if nutrient_id in NUTRIENTS:
            column = NUTRIENTS[nutrient_id]
            row[column] = food_nutrient.get("amount")

    return row

NUTRIENTS = {
    1003: "protein",
    1004: "fat",
    1005: "carbs",
    1008: "calories"
}

# JSON is downloaded from USDA FoodData Central
# https://fdc.nal.usda.gov/download-datasets
# Foundation Foods JSON - Release 04/2026
with open('FoodData_Central_foundation_food_json/FoodData_Central_foundation_food_json.json') as file:
    data = json.load(file)

foods = data["FoundationFoods"]

with open("foods.csv", "w", newline="", encoding="utf-8") as file:
    fieldnames = [
        "fdc_id",
        "name",
        "calories",
        "protein",
        "carbs",
        "fat"
    ]

    writer = csv.DictWriter(file, fieldnames=fieldnames)
    writer.writeheader()

    for food in foods[:100]:
        writer.writerow(parse_food(food))