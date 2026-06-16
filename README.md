# Routine_Saas

## MVP :
Un utilisateur authentifié peut programmer sa semaine de musculation avec des exercices classés par groupe musculaire et suivre ses performances actuelles.

## Découpage du projet :
### 1 - Authentification :
- Inscription
- Connexion
- Déconnexion
- Données liées à l'utilisateurs
- Rôle utilisateur / administrateur

### 2 - Catalogues d'exercices :
- Création des groupes musculaires
    - Création des exercices
- Association des exercices avec les groupes musculaires

Groupes et exercices pour la démo : Jambes, Dos, Pectoraux.

### 3 - Interfaces :
- Stylisation des champs, fonds et polices
- Page d'accueil
- Page dashboard
- Page (ou popup) sélection groupe et exercice
- Page (ou popup) renseignement des performances des exercices
- Page ajout, modification, suppression catégories (administrateur)
- Page ajout, modification, suppression exercices (administrateur)

### 4 - Métier :
- Association des exercices avec des jours de la semaines
- Dissociation
- Renseignement performances exercices à un profil utilisateur


## Commandes :
- Création de l'app par VS Code :
```bash
dotnet new mvc -au Individual -o Routine_SaaS
cd Routine_Saas
```

## Sources : 
