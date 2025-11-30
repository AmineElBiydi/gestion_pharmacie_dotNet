# Database Setup Guide

## Quick Setup

### Option 1: Using the Batch Script (Recommended)
1. Double-click `SetupDatabase.bat`
2. Follow the prompts
3. The database will be created with test data

### Option 2: Manual Setup
1. Open SQL Server Management Studio (SSMS) or use `sqlcmd`
2. Connect to your SQL Server instance
3. Execute `DatabaseSchema_Clean.sql`

## Database Structure

### Tables
- **Medicaments** - Medicine inventory with stock levels and expiration dates
- **Clients** - Customer information
- **Fournisseurs** - Supplier information
- **Commandes** - Order headers with payment status
- **DetailsCommande** - Order line items
- **Livraisons** - Delivery records from suppliers

### Test Data Included

#### Users (1)
- **Default Pharmacist Account**
  - Username: `pharmacien`
  - Password: `admin123`
  - Role: Pharmacien
  - ⚠️ **IMPORTANT**: Change the password after first login!

#### Suppliers (4)
- Pharmacie Centrale
- MediSupply France
- PharmaDistrib
- EuroPharma

#### Medicines (18)
- **8 In Stock** - Good quantities above threshold
- **4 Low Stock** - Below threshold (for testing alerts)
- **3 Out of Stock** - Stock = 0 (for testing alerts)
- **3 Expiring Soon** - Within 3 months

#### Clients (8)
- Various test clients with complete information

#### Orders (8)
- Various statuses: En cours, Livrée, Annulée
- Various payment types: Carte Bancaire, Espèces, Chèque, Virement
- Mix of paid and unpaid orders
- Orders from different dates including today

#### Deliveries (5)
- Sample delivery records

## Connection String

The application uses the connection string in `Data/DatabaseConnection.cs`. 

**Default (LocalDB):**
```
Server=(localdb)\MSSQLLocalDB;Database=GestionPharmacie;Integrated Security=true;
```

**Custom Server:**
Update the connection string in `Data/DatabaseConnection.cs`:
```csharp
private static readonly string connectionString = 
    @"Server=YOUR_SERVER_NAME;Database=GestionPharmacie;Integrated Security=true;";
```

## Important Notes

1. **The script will DROP the existing database** if it exists. All data will be lost!
2. Make sure SQL Server is running before executing the script
3. The script includes proper constraints, indexes, and foreign keys
4. All payment fields (EstPaye, TypePaiement) are included in the schema

## Troubleshooting

### Error: "Cannot connect to SQL Server"
- Make sure SQL Server is installed and running
- Check if LocalDB is installed (comes with Visual Studio)
- Verify the server name in the connection string

### Error: "Database already exists"
- The script will ask if you want to drop and recreate it
- Or manually drop the database first: `DROP DATABASE GestionPharmacie;`

### Error: "Permission denied"
- Make sure you have sufficient permissions to create databases
- Try running as Administrator

## Verifying the Setup

After running the script, you can verify the setup:

```sql
USE GestionPharmacie;
SELECT COUNT(*) AS TotalUsers FROM Users;
SELECT COUNT(*) AS TotalMedicaments FROM Medicaments;
SELECT COUNT(*) AS TotalClients FROM Clients;
SELECT COUNT(*) AS TotalCommandes FROM Commandes;
SELECT COUNT(*) AS OutOfStock FROM Medicaments WHERE QuantiteStock = 0;
SELECT COUNT(*) AS LowStock FROM Medicaments WHERE QuantiteStock > 0 AND QuantiteStock <= Seuil;
```

Expected results:
- TotalUsers: 1
- TotalMedicaments: 18
- TotalClients: 8
- TotalCommandes: 8
- OutOfStock: 3
- LowStock: 4

## Default Login Credentials

When you first run the application, use these credentials to log in:

- **Username**: `pharmacien`
- **Password**: `admin123`

⚠️ **Security Note**: Please change the default password after your first login for security purposes.

