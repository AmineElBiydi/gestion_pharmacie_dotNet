-- ========================================
-- Check User Details for Login
-- ========================================
-- Run this to verify the user is set up correctly for login

USE GestionPharmacie;
GO

PRINT '========================================';
PRINT 'User Login Details Check';
PRINT '========================================';
PRINT '';

-- Check user details
SELECT 
    UserId,
    Username,
    FullName,
    Role,
    IsActive,
    CASE 
        WHEN IsActive = 1 THEN '✓ Active (can login)'
        ELSE '✗ Inactive (cannot login)'
    END AS Status,
    CreatedDate,
    LEN(PasswordHash) AS PasswordHashLength,
    LEFT(PasswordHash, 20) + '...' AS PasswordHashPreview
FROM Users
WHERE Username = 'pharmacien';
GO

PRINT '';
PRINT 'Expected Values:';
PRINT '  Username: pharmacien';
PRINT '  IsActive: 1 (true)';
PRINT '  PasswordHashLength: 64';
PRINT '  PasswordHashPreview: 240be518fabd2724ddb6...';
PRINT '';

-- Verify password hash matches
DECLARE @ExpectedHash NVARCHAR(64) = '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a';
DECLARE @ActualHash NVARCHAR(64);

SELECT @ActualHash = PasswordHash 
FROM Users 
WHERE Username = 'pharmacien';

IF @ActualHash = @ExpectedHash
BEGIN
    PRINT '✓ Password hash is CORRECT';
    PRINT '  Login should work with: pharmacien / admin123';
END
ELSE
BEGIN
    PRINT '✗ Password hash is INCORRECT';
    PRINT '  Expected: ' + @ExpectedHash;
    PRINT '  Actual:   ' + ISNULL(@ActualHash, 'NULL');
    PRINT '';
    PRINT '  SOLUTION: Run FixUser.sql to recreate the user with correct hash';
END
GO

PRINT '';
PRINT '========================================';
PRINT 'Check Complete';
PRINT '========================================';
GO

