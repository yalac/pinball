# 🎱 Pinball — flipper 2D (Unity)

Un petit flipper 2D vu de dessus, réalisé avec **Unity 6.5** et le **pipeline de rendu URP 2D**.
Une bille est éjectée depuis le bas du plateau, rebondit sur les murs et les bumpers, et les zones
de score attribuent 1, 2 ou 3 points.

> **État du projet :** prototype jouable dans l'éditeur Unity. Les points sont pour l'instant
> écrits dans la *Console* Unity (pas encore d'interface ni de score cumulé).
> Aucun exécutable n'est fourni : le jeu se lance depuis l'éditeur (ou après un build, voir
> [Compiler le jeu](#-compiler-le-jeu)).

![Unity](https://img.shields.io/badge/Unity-6000.5.7f1-000000?logo=unity)
![URP](https://img.shields.io/badge/URP-2D-blue)
![Langage](https://img.shields.io/badge/langage-C%23-239120)
![Licence](https://img.shields.io/badge/licence-non%20sp%C3%A9cifi%C3%A9e-lightgrey)

---

## Table des matières

- [Aperçu](#-aperçu)
- [Fonctionnalités](#-fonctionnalités)
- [Prérequis](#-prérequis)
- [Installation](#-installation)
- [Comment jouer](#-comment-jouer)
- [Structure du projet](#-structure-du-projet)

---

## 👀 Aperçu

Le plateau est entièrement construit avec des formes géométriques colorées (sprites intégrés
d'Unity, aucune image externe) :

| Élément | Apparence |
| --- | --- |
| Fond | grand rectangle bleu nuit |
| Murs (`Mur1` → `Mur22`, `MursPoint1` → `MursPoint4`) | rectangles bordeaux |
| Bumpers / obstacles (`Obstacle`, `Obstacle1` → `Obstacle7`) | cercles cyan |
| Bumpers neutres (`CerclePoint1` → `CerclePoint4`) | cercles bordeaux |
| Zones de score | rectangles violets (1 pt), verts (2 pts) et orange (3 pts) |
| Bille | petit cercle blanc |
| Éclairage | *Global Light 2D* (URP 2D) |

La caméra est orthographique (`size = 5`), le jeu est prévu pour un écran 1920 × 1080
(`ProjectSettings/ProjectSettings.asset`).

---

## ✨ Fonctionnalités

- **Tir de bille** avec une force verticale aléatoire (entre 475 et 675), via le nouvel
  *Input System* (clavier ou manette).
- **Physique 2D rebondissante** : matériau physique `PM_Rebond` (rebond à 100 %) appliqué à la bille.
- **Zones de score** détectées par *tags* : `UnPoint` (1), `DeuxPoint` (2), `TroisPoint` (3).
- **Anti-spam** : une seule bille peut être tirée à la fois (`apparition` dans `S_Controller`).
- Aucun asset externe : tout tient dans une scène + un prefab.

---

## ✅ Prérequis

| Outil | Version / détail |
| --- | --- |
| **Unity Editor** | **6.5 — `6000.5.7f1`** (version exacte du projet, voir `ProjectSettings/ProjectVersion.txt`) |
| **Unity Hub** | pour installer l'éditeur et ouvrir le projet |
| **Module de build** | « Windows Build Support (Mono) », « Mac Build Support (Mono) » ou « Web Build Support » selon la plateforme visée — *facultatif pour jouer dans l'éditeur* |
| **Git** | pour cloner le dépôt (ou télécharger le ZIP) |
| **Git LFS** | *facultatif*, voir la note ci-dessous |
| Espace disque | ~2 Go (éditeur non compris) ; les packages sont téléchargés à la première ouverture |

> **Note Git LFS :** le fichier `.gitattributes` déclare Git LFS pour les images et les sons
> (`*.png`, `*.jpg`, `*.psd`, `*.wav`, `*.mp3`, `*.ogg`, `*.fbx`, `*.obj`, `*.mp4`, `*.tga`).
> Le dépôt ne contient aujourd'hui aucune de ces extensions, mais si vous en ajoutez, installez
> d'abord Git LFS (`git lfs install`) pour éviter des fichiers corrompus chez les autres personnes.

---

## 🚀 Installation

### 1. Récupérer le projet

**Avec Git :**

```bash
git clone https://github.com/yalac/pinball.git
cd pinball
```

**Sans Git :** sur la page GitHub, cliquez sur **Code → Download ZIP**, puis décompressez l'archive.

### 2. Installer Unity 6.5 (6000.5.7f1)

1. Ouvrez **Unity Hub → Installs → Install Editor**.
2. Onglet **Archive**, cherchez la version **6000.5.7f1** et installez-la
   (lien direct : <https://unity.com/releases/editor/whats-new/6000.5.7f1>).
3. Cochez au minimum le module de build de votre système.

### 3. Ouvrir le projet

1. **Unity Hub → Add → Add project from disk**.
2. Sélectionnez le dossier qui contient `Assets/`, `Packages/` et `ProjectSettings/`
   (pas un sous-dossier).
3. Ouvrez-le avec **6000.5.7f1**. La première ouverture importe les assets et télécharge les
   packages déclarés dans `Packages/manifest.json` : cela peut prendre quelques minutes et
   nécessite une connexion Internet.

### 4. Lancer le jeu

1. Dans la fenêtre **Project**, ouvrez `Assets/Scenes/SampleScene.unity`
   (elle est déjà la scène de démarrage dans *Build Settings*).
2. Cliquez sur **▶ Play** en haut de l'éditeur.
3. Appuyez sur **Espace** pour tirer une bille.

---

## 🎮 Comment jouer

| Action | Clavier | Manette |
| --- | --- | --- |
| **Tirer une bille** | `Espace` | bouton **Sud** (A sur Xbox, ✕ sur PlayStation) |

- La bille apparaît au point `SpawnPoint` (bas-droite du plateau) et part vers le haut avec une
  force aléatoire.
- Elle rebondit sur les murs, les bumpers cyan et les cercles bordeaux.
- Quand elle traverse une zone de score, un message s'affiche dans la **Console** Unity :

  ```
  1 point      (zone violette  — UnPoint)
  2 point      (zone verte     — DeuxPoint)
  3 point      (zone orange    — TroisPoint)
  ```

  Pour voir la Console : **Window → General → Console** (raccourci `Ctrl + Shift + C`).

- **Une seule bille à la fois.** Le script autorise un nouveau tir quand la bille précédente est
  sortie de la zone du `Controller` (le « puisard » en bas du plateau). Si la bille tombe ailleurs
  et disparaît de l'écran, il faut relancer le mode Play (voir
  [Limites connues](#-limites-connues--pistes-damélioration)).

> 💡 Il n'y a pour l'instant **ni score cumulé, ni écran de fin, ni bouton Rejouer** : les points
> ne sont que des lignes de log.

---

## 📁 Structure du projet

```text
pinball/
├── Assets/
│   ├── Materials/
│   │   └── PM_Rebond.physicsMaterial2D   # matériau physique de la bille (rebond 100 %)
│   ├── Prefabs/
│   │   └── Balle.prefab                  # prefab de la bille (+ S_Balle)
│   ├── Scenes/
│   │   └── SampleScene.unity             # le plateau (seule scène du projet)
│   ├── Scripts/
│   │   ├── S_Controller.cs               # tir de la bille, gestion du puisard
│   │   └── S_Balle.cs                    # force initiale et détection des zones de score
│   └── Settings/                         # URP 2D, renderer 2D, Input Actions, profils de volume
│       ├── InputSystem_Actions.inputactions
│       ├── UniversalRP.asset
│       ├── Renderer2D.asset
│       └── ...
├── Packages/
│   ├── manifest.json                     # packages Unity utilisés
│   └── packages-lock.json
├── ProjectSettings/                      # réglages du projet (version, physique, tags, build…)
├── .vsconfig                             # composants Visual Studio recommandés
├── .gitattributes                        # normalisation des fins de ligne + Git LFS
├── .gitignore                            # ignore Library/, Temp/, Logs/, *.csproj…
├── pinball.slnx                          # solution (générée à partir des .csproj Unity)
└── README.md
```

### Hiérarchie de la scène

```text
SampleScene
├── SpawnPoint          # position d'apparition de la bille
├── Controller          # S_Controller + PlayerInput + BoxCollider2D (trigger) : le puisard
├── Main Camera         # caméra orthographique (size 5)
├── Global Light 2D     # lumière globale URP 2D
├── ArrierePlan         # fond bleu nuit
├── Obstacle            # conteneur : Obstacle, Obstacle1 … Obstacle7 (bumpers cyan)
├── ZonePoint           # conteneur : UnPointDroite, UnPointGauche, DeuxPointDroite,
│                       #             DeuxPointGauche, TroisPoint
└── Murs                # conteneur : Mur1 … Mur22 + MursPoint
                        #             └── MursPoint1..4 et CerclePoint1..4
```
