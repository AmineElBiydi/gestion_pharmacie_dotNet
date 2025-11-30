# Troubleshooting Login Issues

## Problem: "Nom d'utilisateur ou mot de passe incorrect"

This error means the database connection is working, but the user credentials don't match.

## Quick Fix Steps

### Step 1: Verify Database Has User

Run this SQL query in SQL Server Management Studio:

```sql
USE GestionPharmacie;
SELECT * FROM Users;
```

**Expected Result**: You should see one user with Username = 'pharmacien'

**If empty or no user found**: Run `FixUser.sql` to create the default user.

### Step 2: Create/Recreate Default User

**Option A: Using SQL Script**
1. Open SQL Server Management Studio
2. Connect to your SQL Server instance (Amine or LocalDB)
3. Open and execute `FixUser.sql`
4. Verify the user was created

**Option B: Manual SQL**
```sql
USE GestionPharmacie;

-- Delete existing user if exists
DELETE FROM Users WHERE Username = 'pharmacien';

-- Insert default user
INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive, CreatedDate) VALUES
('pharmacien', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a', 'Pharmacien Principal', 'Pharmacien', 1, GETDATE());
```

### Step 3: Verify Database Setup

Run `VerifyDatabase.sql` to check:
- Database exists
- All tables exist
- User exists
- Test data exists

### Step 4: Test Login Again

After creating the user:
1. Restart the application
2. Login with:
   - **Username**: `pharmacien`
   - **Password**: `admin123`

## Common Issues

### Issue 1: Users Table Doesn't Exist
**Solution**: 
- Run `DatabaseSchema_Clean.sql` to create all tables
- Or run `SetupDatabase.bat` for automatic setup

### Issue 2: User Exists But Login Fails
**Possible Causes**:
- Password hash is incorrect
- User is inactive (IsActive = 0)
- Username has extra spaces

**Solution**:
- Run `FixUser.sql` to recreate the user with correct hash
- Or manually delete and recreate the user

### Issue 3: Database Connection Works But No Data
**Solution**:
- Database exists but is empty
- Run `DatabaseSchema_Clean.sql` to populate with test data
- Or run `SetupDatabase.bat`

## Verification Queries

### Check if user exists:
```sql
USE GestionPharmacie;
SELECT Username, FullName, Role, IsActive FROM Users WHERE Username = 'pharmacien';
```

### Check password hash:
```sql
USE GestionPharmacie;
SELECT Username, PasswordHash FROM Users WHERE Username = 'pharmacien';
-- Should be: 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a
```

### Check if user is active:
```sql
USE GestionPharmacie;
SELECT Username, IsActive FROM Users WHERE Username = 'pharmacien';
-- IsActive should be 1 (true)
```

## After Fixing

Once the user is created:
1. ✅ Restart the application
2. ✅ Login with `pharmacien` / `admin123`
3. ✅ Should successfully log in!

## Still Having Issues?

1. **Check connection string** in `Data/DatabaseConnection.cs`
   - Make sure it points to the correct server
   - Verify database name is `GestionPharmacie`

2. **Check SQL Server is running**
   - For named instance: Verify "Amine" server is running
   - For LocalDB: Run `sqllocaldb start MSSQLLocalDB`

3. **Verify database exists**
   ```sql
   SELECT name FROM sys.databases WHERE name = 'GestionPharmacie';
   ```

4. **Run full database setup**
   - Execute `DatabaseSchema_Clean.sql` completely
   - This will create everything from scratch

