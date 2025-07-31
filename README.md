# Oh Noe - Tic Tac Toe

## Project Overview

Design a classic Tic Tac Toe game where the user can make turns against an AI. The user will be asked to place a symbol and your program should insert it into a multidimensional grid. After each turn an AI should also make its turn and the program detects when someone wins (or if there is a tie!)

## Requirements

### Architecture
- **Do not place all your code in Program.cs**
- Create additional separate files that handle all the functions for:
  - **User Interface** (like `Console.ReadLine` and `WriteLine`)
  - **Game Logic**

### File Structure
Create the following files to organize your code:

- `UI.cs` - Handle all user interface methods
- `Logic.cs` - Handle all game logic methods  
- `GameData.cs` - Store game data like text, constants, and configuration
- `Program.cs` - Main program entry point

### Technical Requirements
- Use a **multidimensional array** for the grid
- Implement proper **UI-Logic separation** using functions
- Player vs AI gameplay
- Win detection (horizontal, vertical, diagonal)
- Tie detection when board is full

## 🚀 Tips

- Utilize the things you have learned about **multidimensional arrays** from previous projects
- Apply your knowledge about **UI-Logic split** using functions
- Consider the AI strategy (blocking player moves, trying to win)

## Game Features

- ✅ Player vs AI gameplay
- ✅ 3x3 grid with bordered display
- ✅ Input validation
- ✅ Win/tie detection
- ✅ Play again functionality
- ✅ Smart AI opponent

## How to Play

1. You are **X** and the AI is **O**
2. Enter your move as `row column` (e.g., `0 1` for top-middle)
3. Try to get 3 in a row (horizontally, vertically, or diagonally)
4. The AI will automatically make its move after yours
5. Game ends when someone wins or the board is full (tie)