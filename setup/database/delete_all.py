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

drop_app_sql_path = "sql_scripts/app_schema/drop_schema.sql"
drop_staging_sql_path = "sql_scripts/staging_schema/drop_schema.sql"

subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", drop_app_sql_path
    ],
    env=env,
    check=True
)

subprocess.run(
    [
        "psql",
        "-v", "ON_ERROR_STOP=1",
        "--single-transaction",
        "-h", db_host,
        "-p", db_port,
        "-U", db_username,
        "-d", db_name,
        "-f", drop_staging_sql_path
    ],
    env=env,
    check=True
)