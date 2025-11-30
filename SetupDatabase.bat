@echo off
echo ========================================
echo Pharmacy Management System - Database Setup
echo ========================================
echo.

REM Check if SQL Server is available
echo Checking SQL Server connection...
sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "SELECT @@VERSION" >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo ERROR: SQL Server LocalDB is not available or not running.
    echo Please install SQL Server LocalDB or modify the connection string.
    echo.
    pause
    exit /b 1
)

echo SQL Server LocalDB is available.
echo.

REM Check if database exists
echo Checking if database exists...
sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "IF EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionPharmacie') SELECT 'Database exists'" >nul 2>&1
if %ERRORLEVEL% EQU 0 (
    echo.
    echo WARNING: Database 'GestionPharmacie' already exists!
    echo.
    set /p confirm="Do you want to DROP and recreate it? (This will DELETE ALL DATA!) [y/N]: "
    if /i not "%confirm%"=="y" (
        echo Setup cancelled.
        pause
        exit /b 0
    )
)

echo.
echo Creating database and tables...
echo.

REM Execute the schema script
sqlcmd -S "(localdb)\MSSQLLocalDB" -i DatabaseSchema_Clean.sql

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo Database setup completed successfully!
    echo ========================================
    echo.
    echo Database: GestionPharmacie
    echo Server: (localdb)\MSSQLLocalDB
    echo.
    echo Test data has been inserted:
    echo   - 4 Suppliers
    echo   - 18 Medicines (3 out of stock, 4 low stock)
    echo   - 8 Clients
    echo   - 8 Orders (various statuses and payment types)
    echo   - 5 Deliveries
    echo.
) else (
    echo.
    echo ERROR: Database setup failed!
    echo Please check the error messages above.
    echo.
)

pause
