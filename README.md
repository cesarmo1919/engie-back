# Documentation du Projet : Application de Publication de Prix

## Objectif

L'objectif de cette application est de créer une solution complète front-end et back-end qui gère et publie en temps réel les mises à jour de prix de paires de devises (EUR/USD, EUR/GBP, USD/GBP). Les prix sont générés aléatoirement à des intervalles également aléatoires (entre 1 ms et 100 ms), et sont ensuite envoyés au front-end via une API WebSocket.

## Architecture du Projet

Le projet suit une architecture basée sur les principes du **Domain-Driven Design (DDD)**. Il est organisé en plusieurs couches pour séparer les responsabilités :

1. **EngiePrice.Api** : C'est la couche Web API qui expose l'API pour les WebSockets et qui sert d'interface entre le client (front-end) et la logique métier.
2. **EngiePrice.Application** : Contient la logique applicative, responsable de la gestion des prix (génération et publication) et de leur diffusion en temps réel.
3. **EngiePrice.Domain** : Définit les entités du domaine et les services métier. Ici, les paires de devises et la logique de génération de prix sont modélisées.
4. **EngiePrice.Infrastructure** : Implemente la gestion des WebSockets pour transmettre les données de prix en temps réel au front-end.

## Fonctionnalités Principales

### Back-end (C#)

#### 1. **Génération de prix aléatoires**
Le service métier génère des prix aléatoires pour chaque paire de devises (EUR/USD, EUR/GBP, USD/GBP). Ces prix sont calculés à partir d'un générateur de nombres aléatoires.

#### 2. **Publication des prix à des intervalles aléatoires**
Une boucle asynchrone s'exécute pour chaque paire de devises, mettant à jour le prix à des intervalles aléatoires compris entre 1 ms et 100 ms.

#### 3. **Diffusion via WebSocket**
Le WebSocket est utilisé pour diffuser en temps réel les mises à jour des prix générés au front-end. Cela permet au client de recevoir et d'afficher les prix sans avoir à demander continuellement les données.

### Front-end (Angular)

#### 1. **Connexion au WebSocket**
Le front-end Angular se connecte au WebSocket du serveur pour recevoir les mises à jour des prix. Les données sont transmises sous forme de messages JSON.

#### 2. **Affichage en temps réel**
Les prix des paires de devises sont affichés en temps réel sur le front-end, avec des cartes (cards) dédiées à chaque paire de devises. À chaque mise à jour, l'interface utilisateur se rafraîchit automatiquement pour refléter le nouveau prix.

### Principe de Fonctionnement Global

1. Le back-end génère des prix pour chaque paire de devises à des intervalles aléatoires.
2. Les prix sont diffusés via WebSocket.
3. Le front-end écoute en temps réel les mises à jour et met à jour l'interface utilisateur dès qu'un nouveau prix est reçu.

## Points Clés

- **Gestion de la concurrence** : Le projet utilise une approche asynchrone pour gérer la génération et la publication des prix, garantissant une performance élevée même avec des mises à jour fréquentes.
- **WebSocket** : L'utilisation du WebSocket permet de transmettre des données en temps réel, minimisant les latences entre le back-end et le front-end.
- **Architecture DDD** : L'organisation en couches (API, Application, Domain, Infrastructure) permet une séparation claire des responsabilités, facilitant la maintenance et l'évolution du projet.

## Technologies Utilisées

- **Back-end** : C# avec ASP.NET Core, gestion des WebSockets.
- **Front-end** : Angular pour l'affichage dynamique des prix en temps réel.
- **Communication** : WebSockets pour la transmission en temps réel des données de prix.

## Conclusion

Cette application démontre une solution efficace et réactive pour la gestion et la diffusion de prix en temps réel. Elle peut être étendue pour ajouter plus de fonctionnalités comme des notifications d'alertes de prix, la persistance des données ou encore des visualisations graphiques en temps réel des variations des prix.
