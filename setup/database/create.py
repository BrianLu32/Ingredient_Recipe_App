import os
import subprocess
from dotenv import load_dotenv

load_dotenv()

db_host = os.getenv("DB_HOST")
db_username = os.getenv("DB_USERNAME")
db_password = os.getenv("DB_PASSWORD")
db_port = os.getenv("DB_PORT")
db_name = os.getenv("DB_NAME")

env = os.environ.copy()
env["PGPASSWORD"] = db_password

app_sql_path = "sql_scripts/app_schema/master.sql"
staging_sql_path = "sql_scripts/staging_schema/master.sql"
seed_sql_path = "sql_scripts/staging_schema/seed.sql"
stage_to_app_path = "sql_scripts/copy_to_app/master.sql"
truncate_stage_path = "sql_scripts/staging_schema/truncate_tables.sql"

# Application DB Setup
subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", app_sql_path
    ],
    env=env,
    check=True
)

# Staging DB Setup
subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", staging_sql_path
    ],
    env=env,
    check=True
)

# Import CSV to Staging
subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", seed_sql_path
    ],
    env=env,
    check=True
)

# Staging to App
subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", stage_to_app_path
    ],
    env=env,
    check=True
)

# Clear Staging Table
subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", truncate_stage_path
    ],
    env=env,
    check=True
)