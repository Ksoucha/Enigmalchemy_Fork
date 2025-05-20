# EnigmAlchemy

## Open Source Game Contribution (Data Structures & Algorithms)

### Objective

This project was made to practically apply my knowledge of **data structures and algorithms** by contributing to an open-source game written in C#.

### Project Overview

The game EnigmAlchemy was taken from https://ceritrus.itch.io/enigmalchemy. It was chosen because it has a public Github page and contains at least 10 commits, which fits the description of an open-source game. 

These steps were followed in order to contribute to this project:

1. **Play and Analyze:** Play the game thoroughly to identify areas of gameplay improvement.
2. **Review the Code:** Examine the game's source code, focusing on existing data structures and algorithms.
3. **Implement Improvements:** Make meaningful code changes to incorporate and enhance data structures and algorithms.

### Features
1. **Array Implementation**
    - Commited a code change that modifies an existing list to specifically use an array
    - Reasoning: performance gain since the game has a definite number of item slots, so using a list is not needed when we already know how many item slots we have
2. **Linked List Implementation**
    - Commited a code change that modifies an existing data structure to specifically use a linked list
    - Reasoning: the logic of a linked list can be applied to a code sequence on a numpad in the game
3. **New Algorithm Implementation**
    - Commited a new algorithm to improve the code
    - Dynamic Programming: used to eliminate code redundancies and optimize the work done by each function
4. **Code Refactoring**
    - Commited code refactoring changes to improve readability and structure
    - Modified redundant IF-ELSE statements and IF statements that are too long
5. **Bug Fix and Accessibility Improvement**
    - Commited changes that fix a gameplay bug and enhance accessibility
    - Accessibility improvement: player movement was not natural when the player was walking down the stairs
    - Bug fix: the interactable books in the game were not always showing correctly when pressing **E** (to interact)

### Steps to run the game
1. Clone the repository
2. Navigate to the project folder
3. Open the GameScene in _NotAName_ > _Assets_ > _Scenes_ > GameScene.unity
