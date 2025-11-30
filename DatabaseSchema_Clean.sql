-- ========================================
-- Pharmacy Management System - Clean Database Schema
-- ========================================
-- This script creates a clean database with all tables, constraints, and test data
-- Run this script to recreate the entire database from scratch

-- Drop existing database if it exists (USE WITH CAUTION - DELETES ALL DATA)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionPharmacie')
BEGIN
    ALTER DATABASE GestionPharmacie SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE GestionPharmacie;
END
GO

-- Create Database
CREATE DATABASE GestionPharmacie;
GO

USE GestionPharmacie;
GO

-- ========================================
-- Table: Users (Pharmacist/Admin Users)
-- ========================================
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(64) NOT NULL, -- SHA256 hash (64 hex characters)
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'Pharmacien',
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT CK_Users_ValidUsername CHECK (LEN(Username) >= 3),
    CONSTRAINT CK_Users_ValidRole CHECK (Role IN ('Pharmacien', 'Admin', 'User'))
);

-- Index for faster login
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_IsActive ON Users(IsActive);
GO

-- ========================================
-- Table: Medicaments (Medicines)
-- ========================================
CREATE TABLE Medicaments (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Reference NVARCHAR(50) NOT NULL UNIQUE,
    Nom NVARCHAR(100) NOT NULL,
    DatePeremption DATE NOT NULL,
    PrixUnitaire DECIMAL(10, 2) NOT NULL CHECK (PrixUnitaire >= 0),
    QuantiteStock INT NOT NULL DEFAULT 0 CHECK (QuantiteStock >= 0),
    Seuil INT NOT NULL DEFAULT 10 CHECK (Seuil >= 0)
);

-- Index for faster searches
CREATE INDEX IX_Medicaments_Reference ON Medicaments(Reference);
CREATE INDEX IX_Medicaments_Nom ON Medicaments(Nom);
CREATE INDEX IX_Medicaments_Stock ON Medicaments(QuantiteStock, Seuil);
GO

-- ========================================
-- Table: Clients
-- ========================================
CREATE TABLE Clients (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Numero NVARCHAR(50) NOT NULL UNIQUE,
    Nom NVARCHAR(100) NOT NULL,
    Prenom NVARCHAR(100) NOT NULL,
    Adresse NVARCHAR(255),
    Telephone NVARCHAR(20),
    CONSTRAINT CK_Clients_ValidNumero CHECK (LEN(Numero) > 0)
);

-- Indexes for faster searches
CREATE INDEX IX_Clients_Numero ON Clients(Numero);
CREATE INDEX IX_Clients_Nom ON Clients(Nom, Prenom);
GO

-- ========================================
-- Table: Fournisseurs (Suppliers)
-- ========================================
CREATE TABLE Fournisseurs (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nom NVARCHAR(100) NOT NULL,
    Adresse NVARCHAR(255),
    Telephone NVARCHAR(20)
);

CREATE INDEX IX_Fournisseurs_Nom ON Fournisseurs(Nom);
GO

-- ========================================
-- Table: Commandes (Orders)
-- ========================================
CREATE TABLE Commandes (
    ID INT PRIMARY KEY IDENTITY(1,1),
    DateCommande DATETIME NOT NULL DEFAULT GETDATE(),
    ClientID INT NOT NULL,
    MontantTotal DECIMAL(10, 2) NOT NULL DEFAULT 0 CHECK (MontantTotal >= 0),
    Statut NVARCHAR(50) NOT NULL DEFAULT 'En cours',
    EstPaye BIT NOT NULL DEFAULT 0,
    TypePaiement NVARCHAR(50) NULL,
    CONSTRAINT FK_Commandes_Clients FOREIGN KEY (ClientID) REFERENCES Clients(ID) ON DELETE NO ACTION,
    CONSTRAINT CK_Commandes_ValidStatut CHECK (Statut IN ('En cours', 'Livrée', 'Annulée'))
);

-- Indexes for faster queries
CREATE INDEX IX_Commandes_DateCommande ON Commandes(DateCommande);
CREATE INDEX IX_Commandes_ClientID ON Commandes(ClientID);
CREATE INDEX IX_Commandes_Statut ON Commandes(Statut);
CREATE INDEX IX_Commandes_EstPaye ON Commandes(EstPaye);
GO

-- ========================================
-- Table: DetailsCommande (Order Details)
-- ========================================
CREATE TABLE DetailsCommande (
    ID INT PRIMARY KEY IDENTITY(1,1),
    CommandeID INT NOT NULL,
    MedicamentID INT NOT NULL,
    Quantite INT NOT NULL CHECK (Quantite > 0),
    PrixUnitaire DECIMAL(10, 2) NOT NULL CHECK (PrixUnitaire >= 0),
    CONSTRAINT FK_DetailsCommande_Commandes FOREIGN KEY (CommandeID) REFERENCES Commandes(ID) ON DELETE CASCADE,
    CONSTRAINT FK_DetailsCommande_Medicaments FOREIGN KEY (MedicamentID) REFERENCES Medicaments(ID) ON DELETE NO ACTION
);

-- Indexes
CREATE INDEX IX_DetailsCommande_CommandeID ON DetailsCommande(CommandeID);
CREATE INDEX IX_DetailsCommande_MedicamentID ON DetailsCommande(MedicamentID);
GO

-- ========================================
-- Table: Livraisons (Deliveries)
-- ========================================
CREATE TABLE Livraisons (
    ID INT PRIMARY KEY IDENTITY(1,1),
    DateLivraison DATETIME NOT NULL DEFAULT GETDATE(),
    FournisseurID INT NOT NULL,
    MedicamentID INT NOT NULL,
    Quantite INT NOT NULL CHECK (Quantite > 0),
    CONSTRAINT FK_Livraisons_Fournisseurs FOREIGN KEY (FournisseurID) REFERENCES Fournisseurs(ID) ON DELETE NO ACTION,
    CONSTRAINT FK_Livraisons_Medicaments FOREIGN KEY (MedicamentID) REFERENCES Medicaments(ID) ON DELETE NO ACTION
);

CREATE INDEX IX_Livraisons_DateLivraison ON Livraisons(DateLivraison);
CREATE INDEX IX_Livraisons_MedicamentID ON Livraisons(MedicamentID);
GO

-- ========================================
-- SAMPLE DATA FOR TESTING
-- ========================================

-- Insert Default Pharmacist User
-- Username: pharmacien
-- Password: admin123
-- Password Hash (SHA256): 240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a
INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive, CreatedDate) VALUES
('pharmacien', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a', 'Pharmacien Principal', 'Pharmacien', 1, GETDATE());
GO

-- Insert Suppliers
INSERT INTO Fournisseurs (Nom, Adresse, Telephone) VALUES
('Pharmacie Centrale', '123 Rue de Paris, 75001 Paris', '01 23 45 67 89'),
('MediSupply France', '456 Avenue des Sciences, 69000 Lyon', '04 78 90 12 34'),
('PharmaDistrib', '789 Boulevard de la Santé, 33000 Bordeaux', '05 56 78 90 12'),
('EuroPharma', '321 Rue du Médicament, 13000 Marseille', '04 91 23 45 67');
GO

-- Insert Medicines with various stock levels for testing alerts
INSERT INTO Medicaments (Reference, Nom, DatePeremption, PrixUnitaire, QuantiteStock, Seuil) VALUES
-- In Stock - Good quantities
('MED001', 'Paracétamol 500mg', '2026-12-31', 5.50, 150, 20),
('MED002', 'Ibuprofène 400mg', '2025-12-15', 8.00, 80, 15),
('MED003', 'Amoxicilline 500mg', '2026-06-30', 12.50, 60, 10),
('MED004', 'Vitamine C 1000mg', '2027-01-20', 6.00, 120, 25),
('MED005', 'Aspirine 500mg', '2026-08-15', 4.25, 200, 30),
('MED006', 'Doliprane 1000mg', '2026-11-30', 7.50, 90, 20),
('MED007', 'Spasfon', '2025-10-20', 9.75, 70, 15),
('MED008', 'Smecta', '2026-05-10', 8.50, 100, 25),

-- Low Stock - Below threshold
('MED009', 'Nurofen 400mg', '2025-09-15', 9.00, 5, 15),  -- Low stock
('MED010', 'Efferalgan 500mg', '2026-03-20', 6.50, 8, 20),  -- Low stock
('MED011', 'Dafalgan 1000mg', '2026-07-10', 7.25, 12, 25),  -- Low stock
('MED012', 'Strepsils', '2025-12-31', 5.75, 3, 10),  -- Very low stock

-- Out of Stock
('MED013', 'Advil 400mg', '2026-04-15', 8.50, 0, 15),  -- Out of stock
('MED014', 'Actifed', '2025-11-30', 7.00, 0, 10),  -- Out of stock
('MED015', 'Humex', '2026-02-28', 6.25, 0, 12),  -- Out of stock

-- Expiring Soon (within 3 months)
('MED016', 'Doliprane Enfant', '2025-04-15', 5.00, 45, 20),  -- Expiring soon
('MED017', 'Sirop Toux', '2025-05-20', 8.50, 30, 15),  -- Expiring soon
('MED018', 'Gaviscon', '2025-06-10', 9.50, 25, 10);  -- Expiring soon
GO

-- Insert Clients
INSERT INTO Clients (Numero, Nom, Prenom, Adresse, Telephone) VALUES
('CLI001', 'Dupont', 'Jean', '10 Rue Victor Hugo, 75016 Paris', '06 01 02 03 04'),
('CLI002', 'Martin', 'Marie', '25 Boulevard Haussmann, 75009 Paris', '06 05 06 07 08'),
('CLI003', 'Durand', 'Pierre', '5 Avenue Foch, 75008 Paris', '06 09 10 11 12'),
('CLI004', 'Bernard', 'Sophie', '15 Rue de Rivoli, 75004 Paris', '06 12 13 14 15'),
('CLI005', 'Petit', 'Luc', '30 Rue de la Paix, 75002 Paris', '06 16 17 18 19'),
('CLI006', 'Moreau', 'Isabelle', '8 Place Vendôme, 75001 Paris', '06 20 21 22 23'),
('CLI007', 'Lefebvre', 'Thomas', '12 Rue Saint-Honoré, 75001 Paris', '06 24 25 26 27'),
('CLI008', 'Garcia', 'Ana', '20 Avenue des Champs-Élysées, 75008 Paris', '06 28 29 30 31');
GO

-- Insert Sample Orders with various statuses and payment information
-- Order 1: Paid, Delivered
DECLARE @OrderID1 INT;
-- Insert Sample Orders with various statuses and payment information
-- Note: IDs will be auto-generated by IDENTITY, so we use sequential inserts
-- Order 1: Paid, Delivered
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-12-01 10:30:00', 1, 19.00, 'Livrée', 1, 'Carte Bancaire');
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(1, 1, 2, 5.50),
(1, 2, 1, 8.00);

-- Order 2: Paid, In Progress
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-12-15 14:20:00', 2, 30.50, 'En cours', 1, 'Espèces');
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(2, 3, 1, 12.50),
(2, 4, 3, 6.00);

-- Order 3: Not Paid, In Progress
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-12-20 09:15:00', 3, 16.00, 'En cours', 0, NULL);
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(3, 5, 2, 4.25),
(3, 6, 1, 7.50);

-- Order 4: Paid, Delivered (Cheque)
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-11-25 16:45:00', 4, 26.75, 'Livrée', 1, 'Chèque');
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(4, 7, 1, 9.75),
(4, 8, 2, 8.50);

-- Order 5: Not Paid, Cancelled
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-12-10 11:00:00', 5, 9.00, 'Annulée', 0, NULL);
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(5, 9, 1, 9.00);

-- Order 6: Paid, Delivered (Virement)
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
('2024-12-18 13:30:00', 6, 32.00, 'Livrée', 1, 'Virement');
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(6, 10, 2, 6.50),
(6, 11, 1, 7.25),
(6, 12, 3, 5.75);

-- Order 7: Recent order, Not Paid
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
(GETDATE(), 7, 51.50, 'En cours', 0, NULL);
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(7, 1, 5, 5.50),
(7, 3, 2, 12.50),
(7, 4, 4, 6.00);

-- Order 8: Today's order, Paid
INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement) VALUES
(GETDATE(), 8, 32.50, 'Livrée', 1, 'Carte Bancaire');
INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire) VALUES
(8, 2, 3, 8.00),
(8, 5, 2, 4.25);
GO

-- Insert Sample Deliveries
INSERT INTO Livraisons (DateLivraison, FournisseurID, MedicamentID, Quantite) VALUES
('2024-11-01 10:00:00', 1, 1, 200),
('2024-11-05 14:30:00', 2, 2, 100),
('2024-11-10 09:15:00', 1, 3, 80),
('2024-11-15 11:20:00', 3, 4, 150),
('2024-12-01 08:00:00', 2, 5, 250);
GO

PRINT '========================================';
PRINT 'Database created successfully!';
PRINT '========================================';
PRINT 'Summary:';
PRINT '  - 1 Pharmacist User (Username: pharmacien, Password: admin123)';
PRINT '  - 4 Suppliers';
PRINT '  - 18 Medicines (3 out of stock, 4 low stock)';
PRINT '  - 8 Clients';
PRINT '  - 8 Orders (various statuses and payment types)';
PRINT '  - 5 Deliveries';
PRINT '========================================';
PRINT '';
PRINT 'IMPORTANT: Default Login Credentials';
PRINT '  Username: pharmacien';
PRINT '  Password: admin123';
PRINT '  Please change the password after first login!';
PRINT '========================================';
GO

