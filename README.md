# MazeMunchers

MazeMunchers is a 2D Pac-Man-style game developed in Unity using C#. The game features maze-based movement, enemy AI, collectible-based scoring and persistent high scores.

## Features

- Player movement and collision detection
- Collectible-based scoring system
- Enemy AI with dynamic pathfinding
- Different enemy chasing behaviours
- Game state management
- Persistent high-score system

## Enemy AI

Enemies use Unity's NavMesh system to navigate the maze and chase the player. Different chasing mechanics create variation in enemy behaviour and increase the challenge for the player.

## Save System

High scores are stored locally using JSON file read and write operations, allowing the player's best score to persist between game sessions.

## Download and Play

1. Go to the [Releases](../../releases) section.
2. Download the latest Windows build.
3. Extract the downloaded ZIP file.
4. Run `MazeMunchers.exe`.

> Windows may display a security warning because the application is not digitally signed.

## Opening the Unity Project

1. Clone or download this repository.
2. Open the project through Unity Hub.
3. Use Unity version `2022.1.7f1` or a compatible version.
4. Open the main game scene and press **Play**.
