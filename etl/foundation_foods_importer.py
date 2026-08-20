import json
import csv

def parse_food(food):
    row = {
        "fdc_id": food["fdcId"],
        "name": food["description"],
        "calories": None,
        "protein": None,
        "carbs": None,
        "fat": None,
        "food_category": None,
        "portion": None,
        "unitFull": None,
        "unitAbr": None,
        "gramWeight": None
    }

    for food_nutrient in food["foodNutrients"]:
        nutrient = food_nutrient["nutrient"]
        nutrient_id = nutrient["id"]

        if nutrient_id in NUTRIENTS:
            column = NUTRIENTS[nutrient_id]
            row[column] = food_nutrient.get("amount")

    if (food_category := food.get("foodCategory")) is not None:
        row["food_category"] = food_category.get("description")

    # food portions is a list in json
    for portion in food.get("foodPortions", []):
        if portion.get("measureUnit").get("name") in UNITS:
            row["portion"] = portion.get("value")
            row["unitFull"] = portion.get("measureUnit").get("name")
            row["unitAbr"] = portion.get("measureUnit").get("abbreviation")
            row["gramWeight"] = portion.get("gramWeight")
            break
        else:
            print(portion)

    return row

NUTRIENTS = {
    1003: "protein",
    1004: "fat",
    1005: "carbs",
    1008: "calories"
}

UNITS = [
    "cup",
    "tablespoon",
    "milliliter",
    "oz",
    "gram",
    "teaspoon"
]

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
        "fat",
        "food_category",
        "portion",
        "unitFull",
        "unitAbr",
        "gramWeight"
    ]

    writer = csv.DictWriter(file, fieldnames=fieldnames)
    writer.writeheader()

    for food in foods[:100]:
        writer.writerow(parse_food(food))