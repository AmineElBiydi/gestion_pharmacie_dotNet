# Security Notes - Login System

## Overview

The application includes a secure login system for the pharmacist. Only authenticated users can access the pharmacy management system.

## User Authentication

### Default User Account

A default pharmacist account is created when the database is set up:

- **Username**: `pharmacien`
- **Password**: `admin123`
- **Role**: `Pharmacien`
- **Status**: Active

### ⚠️ IMPORTANT SECURITY NOTES

1. **Change Default Password**: The default password `admin123` is for initial setup only. **You MUST change it after first login** for security.

2. **Single User System**: This application is designed for a single pharmacist user. There are no regular users - only the pharmacist/admin has access.

3. **Password Security**: 
   - Passwords are hashed using SHA256 before storage
   - Passwords are never stored in plain text
   - The database only stores password hashes

4. **User Roles**: 
   - `Pharmacien`: Full access to all features (medicines, clients, orders, statistics)
   - `Admin`: Same as Pharmacien (reserved for future use)
   - `User`: Reserved for future use (currently not used)

## Database Structure

### Users Table

```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(64) NOT NULL,  -- SHA256 hash
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'Pharmacien',
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);
```

### Security Features

1. **Password Hashing**: All passwords are hashed using SHA256 algorithm
2. **Unique Username**: Username must be unique in the database
3. **Active Status**: Users can be deactivated without deletion
4. **Indexed Queries**: Username is indexed for fast login lookups

## How It Works

1. User enters username and password in LoginForm
2. Password is hashed using SHA256
3. System queries Users table for matching username and password hash
4. If found and user is active, session is created
5. User can access all features of the application

## Adding New Users (Future)

If you need to add additional pharmacist users in the future:

```sql
-- Example: Add a new pharmacist user
-- Password: newpassword123
-- Hash: (generate using AuthenticationService.HashPassword method)

INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive) VALUES
('newuser', 'generated_hash_here', 'New Pharmacist Name', 'Pharmacien', 1);
```

To generate a password hash, you can use the `AuthenticationService.HashPassword()` method in the application code, or use an online SHA256 hash generator.

## Best Practices

1. ✅ Use strong passwords (minimum 8 characters, mix of letters, numbers, symbols)
2. ✅ Change default password immediately
3. ✅ Don't share login credentials
4. ✅ Keep the database secure (proper access controls)
5. ✅ Regularly backup the database
6. ✅ Deactivate users instead of deleting (preserves audit trail)

## Troubleshooting

### Cannot Login
- Verify username is correct (case-sensitive)
- Verify password is correct
- Check if user account is active (`IsActive = 1`)
- Check database connection

### Password Hash Generation
If you need to generate a password hash manually, you can use:
- Online SHA256 hash generator
- Or run this in the application:
  ```csharp
  string hash = AuthenticationService.HashPassword("yourpassword");
  ```

## Notes

- The login system is designed for a single-pharmacist scenario
- All features are accessible once logged in (no role-based restrictions)
- The system is secure but simple - suitable for a local pharmacy management system

