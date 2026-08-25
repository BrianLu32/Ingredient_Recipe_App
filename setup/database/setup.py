import argparse
import subprocess

create_script = "setup/database/create.py"
delete_all_script = "setup/database/delete_all.py"
reset_script = "setup/database/reset.py"

parser = argparse.ArgumentParser(description="Create or Delete All Databases")

group = parser.add_mutually_exclusive_group(required=True)

group.add_argument("-c", "--create", action="store_true", help="Create the required schemas and tables for the app to function")
group.add_argument("-d", "--delete", action="store_true", help="Deletes all schemas and tables to start fresh")
group.add_argument("-r", "--reset", action="store_true", help="Clears all data from all schemas")

args = parser.parse_args()

if args.create:
    subprocess.run(
        [
            "python",
            create_script
        ],
        text=True
    )
elif args.delete:
    subprocess.run(
        [
            "python",
            delete_all_script
        ],
        text=True
    )
elif args.reset:
    subprocess.run(
        [
            "python",
            reset_script
        ],
        text=True
    )