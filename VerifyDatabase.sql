-- ========================================
-- Verify Database Setup
-- ========================================
-- Run this script to verify your database is set up correctly

USE GestionPharmacie;
GO

PRINT '========================================';
PRINT 'Database Verification';
PRINT '========================================';
PRINT '';

-- Check if database exists
IF DB_NAME() = 'GestionPharmacie'
BEGIN
    PRINT '✓ Database "GestionPharmacie" exists';
END
ELSE
BEGIN
    PRINT '✗ Database "GestionPharmacie" does not exist';
    PRINT '  Please run DatabaseSchema_Clean.sql first';
    RETURN;
END
GO

-- Check tables
PRINT '';
PRINT 'Checking tables...';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
    PRINT '✓ Users table exists';
ELSE
    PRINT '✗ Users table does NOT exist';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Medicaments')
    PRINT '✓ Medicaments table exists';
ELSE
    PRINT '✗ Medicaments table does NOT exist';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Clients')
    PRINT '✓ Clients table exists';
ELSE
    PRINT '✗ Clients table does NOT exist';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Commandes')
    PRINT '✓ Commandes table exists';
ELSE
    PRINT '✗ Commandes table does NOT exist';

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'DetailsCommande')
    PRINT '✓ DetailsCommande table exists';
ELSE
    PRINT '✗ DetailsCommande table does NOT exist';

GO

-- Check Users
PRINT '';
PRINT 'Checking Users...';
DECLARE @UserCount INT;
SELECT @UserCount = COUNT(*) FROM Users;
IF @UserCount > 0
BEGIN
    PRINT '✓ Users table has ' + CAST(@UserCount AS VARCHAR) + ' user(s)';
    PRINT '';
    PRINT 'Users in database:';
    SELECT Username, FullName, Role, IsActive FROM Users;
END
ELSE
BEGIN
    PRINT '✗ Users table is EMPTY';
    PRINT '  Run FixUser.sql to create the default user';
END
GO

-- Check test data
PRINT '';
PRINT 'Checking test data...';

DECLARE @MedCount INT, @ClientCount INT, @OrderCount INT;
SELECT @MedCount = COUNT(*) FROM Medicaments;
SELECT @ClientCount = COUNT(*) FROM Clients;
SELECT @OrderCount = COUNT(*) FROM Commandes;

IF @MedCount > 0
    PRINT '✓ Medicaments: ' + CAST(@MedCount AS VARCHAR);
ELSE
    PRINT '✗ Medicaments: 0 (no test data)';

IF @ClientCount > 0
    PRINT '✓ Clients: ' + CAST(@ClientCount AS VARCHAR);
ELSE
    PRINT '✗ Clients: 0 (no test data)';

IF @OrderCount > 0
    PRINT '✓ Commandes: ' + CAST(@OrderCount AS VARCHAR);
ELSE
    PRINT '✗ Commandes: 0 (no test data)';

GO

PRINT '';
PRINT '========================================';
PRINT 'Verification Complete';
PRINT '========================================';
GO

