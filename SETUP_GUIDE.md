# Setup Guide - Making Code Work with Database

## Quick Setup Steps

### 1. Create the Database

**Option A: Using Batch Script (Recommended)**
```bash
# Double-click SetupDatabase.bat
# Or run from command line:
SetupDatabase.bat
```

**Option B: Manual Setup**
1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. Open and execute `DatabaseSchema_Clean.sql`
4. Verify the database was created successfully

### 2. Configure Connection String

The application uses `Data/DatabaseConnection.cs` for database connections.

#### Default Configuration (LocalDB)
The code is configured to use LocalDB by default:
```csharp
Server=(localdb)\MSSQLLocalDB;Database=GestionPharmacie;Integrated Security=true;TrustServerCertificate=true;
```

#### If Using Custom SQL Server
Edit `Data/DatabaseConnection.cs` and modify the `GetConnectionString()` method:

```csharp
private static string GetConnectionString()
{
    // Replace with your server name
    return @"Server=YOUR_SERVER_NAME;Database=GestionPharmacie;Integrated Security=true;TrustServerCertificate=true;";
}
```

#### If Using SQL Server Authentication
```csharp
private static string GetConnectionString()
{
    return @"Server=YOUR_SERVER;Database=GestionPharmacie;User Id=username;Password=password;TrustServerCertificate=true;";
}
```

### 3. Verify Database Connection

The application will automatically test the connection when you:
- Log in (checks Users table)
- Access any feature (repositories test connection)

If you get connection errors:
1. Check SQL Server is running
2. Verify database name is correct: `GestionPharmacie`
3. Check connection string in `DatabaseConnection.cs`
4. Ensure SQL Server allows connections

### 4. First Login

Use the default credentials:
- **Username**: `pharmacien`
- **Password**: `admin123`

⚠️ **Important**: Change the password after first login!

## Code Compatibility

### ✅ All Code is Compatible

The application code is fully compatible with the new database schema:

1. **Users Table** ✅
   - `AuthenticationService.cs` uses the Users table
   - Login form works with the default user

2. **Medicaments Table** ✅
   - `MedicamentRepository.cs` uses correct column names
   - All CRUD operations work

3. **Clients Table** ✅
   - `ClientRepository.cs` uses correct column names
   - Search functionality works

4. **Commandes Table** ✅
   - `CommandeRepository.cs` includes payment fields (EstPaye, TypePaiement)
   - All queries updated to include payment information

5. **DetailsCommande Table** ✅
   - Order details work correctly
   - Foreign keys properly handled

## Database Schema Compatibility

| Component | Status | Notes |
|-----------|--------|-------|
| Users Table | ✅ Compatible | Login system works |
| Medicaments | ✅ Compatible | All operations work |
| Clients | ✅ Compatible | All operations work |
| Commandes | ✅ Compatible | Payment fields included |
| DetailsCommande | ✅ Compatible | All operations work |
| Fournisseurs | ✅ Compatible | Available for future use |
| Livraisons | ✅ Compatible | Available for future use |

## Troubleshooting

### Error: "Cannot open database 'GestionPharmacie'"
**Solution**: 
1. Run `DatabaseSchema_Clean.sql` to create the database
2. Check connection string in `DatabaseConnection.cs`
3. Verify SQL Server is running

### Error: "Invalid object name 'Users'"
**Solution**: 
- The Users table might not exist. Run the database schema script again.

### Error: "Login failed for user"
**Solution**:
- Check connection string authentication method
- Verify SQL Server allows Windows Authentication (if using Integrated Security)
- Or switch to SQL Server Authentication with username/password

### Error: "The server was not found or was not accessible"
**Solution**:
1. Check SQL Server is running
2. For LocalDB, start it: `sqllocaldb start MSSQLLocalDB`
3. Verify server name in connection string

### Login Fails with "Incorrect username or password"
**Solution**:
- Verify you're using: `pharmacien` / `admin123`
- Check Users table exists and has data:
  ```sql
  SELECT * FROM Users;
  ```

## Testing the Setup

### 1. Test Database Connection
```csharp
// In your code or test:
bool connected = DatabaseConnection.TestConnection();
Console.WriteLine($"Connected: {connected}");
```

### 2. Test Login
- Run the application
- Try logging in with `pharmacien` / `admin123`
- Should successfully log in

### 3. Test Data Access
After login, try:
- View dashboard (should show statistics)
- Search medicines (should show 18 medicines)
- Search clients (should show 8 clients)
- View orders (should show 8 orders)

### 4. Verify Test Data
Run these SQL queries to verify:
```sql
USE GestionPharmacie;

-- Check users
SELECT COUNT(*) FROM Users;  -- Should be 1

-- Check medicines
SELECT COUNT(*) FROM Medicaments;  -- Should be 18
SELECT COUNT(*) FROM Medicaments WHERE QuantiteStock = 0;  -- Should be 3 (out of stock)

-- Check clients
SELECT COUNT(*) FROM Clients;  -- Should be 8

-- Check orders
SELECT COUNT(*) FROM Commandes;  -- Should be 8
SELECT COUNT(*) FROM Commandes WHERE EstPaye = 1;  -- Should be 5 (paid)
```

## Next Steps

1. ✅ Database created
2. ✅ Connection string configured
3. ✅ Test login
4. ✅ Change default password (recommended)
5. ✅ Start using the application!

## Support

If you encounter issues:
1. Check the error message carefully
2. Verify database exists and has data
3. Check connection string configuration
4. Review `README_DATABASE.md` for more details

