# 🚗 TP - Application de Location de Voitures (ASP.NET)

Projet réalisé dans le cadre d'un TP en **ASP.NET Core MVC**.  
L'objectif est de développer une application web permettant de gérer la location de véhicules.

## 📋 Fonctionnalités

- Gestion des voitures
  - Ajouter une voiture
  - Modifier une voiture
  - Supprimer une voiture
  - Consulter la liste des véhicules

- Gestion des locations
  - Réserver un véhicule
  - Consulter les locations
  - Restituer un véhicule

- Gestion des clients
  - Ajouter un client
  - Modifier un client
  - Supprimer un client

- Interface web réalisée avec ASP.NET MVC

---

## 🛠️ Technologies utilisées

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server (LocalDB ou SQL Server)
- Razor Views
- Bootstrap

---

## 📂 Structure du projet

```
TP-location-voiture-aspdotnet
│
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
├── Migrations/
├── Program.cs
└── appsettings.json
```

---

## ⚙️ Installation

### 1. Cloner le dépôt

```bash
git clone -b dev https://github.com/Cyril-Mathe/TP-location-voiture-aspdotnet.git
```

### 2. Ouvrir le projet

Ouvrir la solution avec **Visual Studio 2022**.

### 3. Configurer la base de données

Modifier la chaîne de connexion dans :

```json
appsettings.json
```

Exemple :

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LocationVoitureDB;Trusted_Connection=True;"
}
```

### 4. Créer la base de données

Dans la Console du Gestionnaire de packages :

```powershell
Update-Database
```

ou avec le CLI :

```bash
dotnet ef database update
```

### 5. Lancer l'application

```bash
dotnet run
```

ou directement depuis Visual Studio.

---

## 👨‍💻 Auteur

**Cyril Mathe**