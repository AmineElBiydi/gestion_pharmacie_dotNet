# Gestion Pharmacie - Structure du Projet

Ce projet suit la structure standard de Visual Studio pour les applications Windows Forms.

## Structure des Dossiers

```
GestionPharmacie/
│
├── GestionPharmacie.sln          # Solution Visual Studio
├── GestionPharmacie.csproj       # Fichier de projet
│
├── Properties/                    # Métadonnées de l'assemblage
│   └── AssemblyInfo.cs
│
├── Data/                          # Couche d'accès aux données
│   ├── DatabaseConnection.cs
│   ├── AuthenticationService.cs
│   ├── MedicamentRepository.cs
│   ├── ClientRepository.cs
│   ├── CommandeRepository.cs
│   └── DetailCommandeRepository.cs
│
├── Models/                        # Modèles de données
│   ├── User.cs
│   ├── Medicament.cs
│   ├── Client.cs
│   ├── Commande.cs
│   └── DetailCommande.cs
│
├── Forms/                         # Formulaires (Dialogs)
│   ├── LoginForm.cs
│   ├── MedicamentForm.cs
│   ├── ClientForm.cs
│   ├── CommandeForm.cs
│   └── StatistiquesForm.cs
│
├── Controls/                      # Contrôles utilisateur
│   ├── DashboardControl.cs
│   └── MedicamentControl.cs
│
├── Utils/                         # Utilitaires
│   ├── Session.cs
│   └── StyleHelper.cs
│
├── Form1.cs                       # Formulaire principal
├── Program.cs                     # Point d'entrée
│
├── DatabaseSchema.sql             # Schéma de base de données
├── DatabaseSchema_Users.sql       # Schéma des utilisateurs
├── SetupDatabase.bat             # Script de configuration DB
│
└── README.md                      # Documentation
```

## Ouvrir dans Visual Studio

1. Double-cliquez sur `GestionPharmacie.sln`
2. Ou ouvrez Visual Studio → Fichier → Ouvrir → Projet/Solution → Sélectionnez `GestionPharmacie.sln`

## Solution Explorer

Dans Visual Studio, vous verrez:
- **Dépendances** - Packages NuGet et références
- **Properties** - Configuration de l'assemblage
- **Data** - Repositories et connexion BD
- **Models** - Entités métier
- **Forms** - Formulaires Windows
- **Controls** - Contrôles réutilisables
- **Utils** - Classes utilitaires

## Organisation du Code

### Couches de l'Application

1. **Présentation** (Forms + Controls)
   - Interface utilisateur
   - Gestion des événements
   
2. **Logique Métier** (Models)
   - Entités du domaine
   - Règles métier

3. **Accès aux Données** (Data)
   - Connexion BD
   - Repositories (CRUD)
   - Services (Authentication)

4. **Utilitaires** (Utils)
   - Helpers
   - Session management
   - Styling

## Configuration Visual Studio

Le projet est configuré pour:
- **.NET 10.0** (ou version installée)
- **Windows Forms Application**
- **Architecture x64**
- **C# 12.0**
