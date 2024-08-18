# TicTacToeRepo
# Tic Tac Toe Game

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [AI Strategy](#ai-strategy)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project is a console-based implementation of the classic **Tic Tac Toe** game written in C#. It allows players to play against each other or against a basic AI. The game is built with simplicity in mind, focusing on clean code and easy-to-understand logic.

## Features

- Play in two modes: 
  - **Player vs Player**
  - **Player vs AI**
- Simple AI that uses basic strategies to provide a challenge.
- Input validation to handle incorrect user inputs.
- Clear and intuitive console-based interface.

## Installation

To run the Tic Tac Toe game, you’ll need:

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Steps:

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/tic-tac-toe.git

2. Navigate to the Project Directory
   ```sh
   cd tic-tac-toe

3. Build the project:
   ```sh
   dotnet build

4. Run the game:
   ```sh
   dotnet run

## How to Play

### Player vs Player

- **Start the Game**: The game will prompt you to choose between Player vs Player or Player vs AI.
- **Make a Move**: Players take turns entering the position (row and column) where they want to place their mark (X or O).
- **Winning the Game**: The first player to get three marks in a row (horizontally, vertically, or diagonally) wins. If all spots are filled without a winner, the game ends in a draw.

### Player vs AI

- **Start the Game**: Select the Player vs AI option when prompted.
- **Player's Turn**: You make your move first, entering the row and column as in Player vs Player mode.
- **AI's Turn**: The AI will automatically make its move using a simple strategy.
- **Winning the Game**: As with Player vs Player, the goal is to get three marks in a row.

## Input Format

- Players will be asked to enter a number between 1 and 3 for row and column selection.
- The grid positions are as follows:

  ```scss
  (1,1) | (1,2) | (1,3)
  ---------------------
  (2,1) | (2,2) | (2,3)
  ---------------------
  (3,1) | (3,2) | (3,3)

## AI Strategy

The AI in this game is designed to be competitive but simple. It follows these basic strategies:

- **Win**: If the AI can win in its next move, it will.
- **Block**: If the player is about to win, the AI will block them.
- **Center Preference**: If the center spot is available, the AI will take it.
- **Corner Preference**: The AI prefers corners if the center is taken.
- **Random Choice**: If no strategic move is available, the AI will pick a random available spot.

## Contributing

Contributions are welcome! If you'd like to improve the game, please fork the repository and submit a pull request. Before contributing, consider the following:

- Follow the existing code style.
- Write clear and concise commit messages.
- Test your changes thoroughly before submitting.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

