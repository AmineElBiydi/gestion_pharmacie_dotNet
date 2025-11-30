# Système de Gestion de Pharmacie

Application Windows Forms pour la gestion complète d'une pharmacie, développée en C# avec .NET 10 et SQL Server LocalDB.

## Fonctionnalités

### 📦 Gestion des Médicaments
- ✅ Créer, modifier, supprimer des médicaments
- ✅ Rechercher par référence ou nom
- ✅ **Alertes automatiques** pour :
  - Stock faible (en dessous du seuil)
  - Médicaments proches de la péremption (< 3 mois)
- ✅ Gestion du stock et des prix

### 🛒 Gestion des Commandes
- ✅ Créer des commandes avec plusieurs médicaments
- ✅ Rechercher par date ou client
- ✅ **Impression des factures**
- ✅ Mise à jour automatique du stock
- ✅ Statistiques des commandes

### 👥 Gestion des Clients
- ✅ Créer, modifier, supprimer des clients
- ✅ Rechercher par numéro, nom ou prénom
- ✅ Historique des commandes par client

### 📊 Statistiques
- ✅ Nombre total de commandes
- ✅ Revenus total
- ✅ Commandes du mois en cours
- ✅ Médicament le plus vendu
- ✅ Valeur moyenne des commandes

## Configuration Requise

- Windows 10 ou supérieur
- .NET 10 SDK
- SQL Server LocalDB (inclus avec Visual Studio ou .NET SDK)

## Installation

### 1. Créer la Base de Données

**Option A: Script Automatique (Recommandé)**
```bash
# Double-cliquez sur SetupDatabase.bat
# Ou exécutez depuis la ligne de commande:
SetupDatabase.bat
```

**Option B: Manuel**
Exécutez le script SQL `DatabaseSchema_Clean.sql` pour créer la base de données :

```bash
# Option 1: Avec SQLCmd
sqlcmd -S "(localdb)\MSSQLLocalDB" -i DatabaseSchema_Clean.sql

# Option 2: Avec Visual Studio
# Ouvrez SQL Server Object Explorer et exécutez le script
```

**Note**: Le script crée automatiquement:
- La base de données avec toutes les tables
- Un utilisateur par défaut (pharmacien/admin123)
- Des données de test complètes

### 2. Restaurer les Packages NuGet

```bash
cd GestionPharmacie
dotnet restore
```

### 3. Compiler le Projet

```bash
dotnet build
```

### 4. Lancer l'Application

```bash
dotnet run
```

Ou ouvrez le projet dans Visual Studio et appuyez sur F5.

## Structure de la Base de Données

### Tables Principales

1. **Medicaments** - Informations sur les médicaments
   - ID, Reference, Nom, DatePeremption, PrixUnitaire, QuantiteStock, Seuil

2. **Clients** - Informations des clients
   - ID, Numero, Nom, Prenom, Adresse, Telephone

3. **Commandes** - En-tête des commandes
   - ID, DateCommande, ClientID, MontantTotal, Statut

4. **DetailsCommande** - Détails des commandes (lignes)
   - ID, CommandeID, MedicamentID, Quantite, PrixUnitaire

5. **Fournisseurs** - Informations des fournisseurs
   - ID, Nom, Adresse, Telephone

6. **Livraisons** - Livraisons des médicaments
   - ID, DateLivraison, FournisseurID, MedicamentID, Quantite

## Utilisation

### Démarrage
1. Lancez l'application
2. Utilisez le menu principal pour naviguer entre les modules

### Gestion des Médicaments
- **Médicaments** → **Gérer les médicaments** : CRUD complet
- **Médicaments** → **Rechercher** : Recherche rapide
- **Médicaments** → **Alertes de péremption** : Voir les alertes

### Créer une Commande
1. **Commandes** → **Nouvelle commande**
2. Sélectionnez un client
3. Ajoutez des médicaments avec quantités
4. Le total se calcule automatiquement
5. Enregistrez la commande (le stock est mis à jour automatiquement)

### Imprimer une Facture
1. **Commandes** → **Rechercher commandes**
2. Trouvez la commande souhaitée
3. Cliquez sur le bouton **Imprimer**

### Voir les Statistiques
- **Statistiques** → **Tableau de bord**

## Architecture du Projet

```
GestionPharmacie/
├── Models/                 # Classes de modèles de données
│   ├── Medicament.cs
│   ├── Client.cs
│   ├── Commande.cs
│   ├── DetailsCommande.cs
│   ├── Fournisseur.cs
│   └── Livraison.cs
├── Data/                   # Couche d'accès aux données
│   ├── DatabaseConnection.cs
│   ├── MedicamentRepository.cs
│   ├── ClientRepository.cs
│   └── CommandeRepository.cs
├── Forms/                  # Formulaires Windows Forms
│   ├── MedicamentForm.cs
│   ├── MedicamentSearchForm.cs
│   ├── MedicamentAlertForm.cs
│   ├── ClientForm.cs
│   ├── ClientSearchForm.cs
│   ├── CommandeForm.cs
│   ├── CommandeSearchForm.cs
│   └── StatistiquesForm.cs
├── Form1.cs               # Formulaire principal
└── DatabaseSchema.sql     # Script de création de la base
```

## Technologies Utilisées

- **Framework**: .NET 10
- **UI**: Windows Forms
- **Base de Données**: SQL Server LocalDB
- **ADO.NET**: System.Data.SqlClient pour l'accès aux données
- **Pattern**: Repository Pattern pour la séparation des préoccupations

## Fonctionnalités Clés

### ✨ Alertes Intelligentes
Le système vérifie automatiquement :
- Stock en dessous du seuil défini
- Médicaments expirant dans les 3 prochains mois
- Affichage avec code couleur (rouge, orange, jaune)

### 🔒 Intégrité des Données
- Contraintes de clés étrangères
- Validation des données avant insertion
- Transactions pour les opérations critiques
- Mise à jour automatique du stock lors des commandes

### 🖨️ Impression
- Génération de factures formatées
- Support de l'impression système Windows

## Dépannage

### Problème de Connexion à la Base de Données
Si vous rencontrez une erreur de connexion :
1. Vérifiez que SQL Server LocalDB est installé
2. Exécutez `sqllocaldb info` pour voir les instances disponibles
3. Si nécessaire, changez la chaîne de connexion dans `DatabaseConnection.cs`

### La Base de Données n'Existe Pas
Assurez-vous d'avoir exécuté le script `DatabaseSchema.sql` avant de lancer l'application.

## Licence

Projet développé pour le cours de Gestion de Pharmacie - ENSA Tétouan 2025

## Auteur

Projet G12 2025 - Université Abdelmalek Essaadi
