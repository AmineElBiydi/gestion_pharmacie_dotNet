-- ========================================
-- Fix User - Create Default Pharmacist User
-- ========================================
-- Run this script if you're getting "Incorrect username or password" error
-- This will create the default user if it doesn't exist

USE GestionPharmacie;
GO

-- Check if Users table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    PRINT 'ERROR: Users table does not exist. Please run DatabaseSchema_Clean.sql first.';
    RETURN;
END
GO

-- Check if user already exists
IF EXISTS (SELECT * FROM Users WHERE Username = 'pharmacien')
BEGIN
    PRINT 'User "pharmacien" already exists.';
    PRINT 'If login still fails, the password hash might be incorrect.';
    PRINT 'Deleting existing user and recreating...';
    
    DELETE FROM Users WHERE Username = 'pharmacien';
END
GO

-- Insert Default Pharmacist User
-- Username: pharmacien
-- Password: admin123
-- Password Hash (SHA256): 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a
INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive, CreatedDate) VALUES
('pharmacien', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a', 'Pharmacien Principal', 'Pharmacien', 1, GETDATE());
GO

-- Verify user was created
IF EXISTS (SELECT * FROM Users WHERE Username = 'pharmacien')
BEGIN
    PRINT '========================================';
    PRINT 'SUCCESS: Default user created!';
    PRINT '========================================';
    PRINT 'Username: pharmacien';
    PRINT 'Password: admin123';
    PRINT '========================================';
    PRINT '';
    PRINT 'You can now login with these credentials.';
END
ELSE
BEGIN
    PRINT 'ERROR: Failed to create user. Please check the error messages above.';
END
GO

-- Show all users (for verification)
SELECT UserId, Username, FullName, Role, IsActive, CreatedDate 
FROM Users;
GO

