# Tic-Tac-Toe With Singleton Design Pattern

## Introduction
The Tic-Tac-Toe game is implemented using the Singleton Design Pattern.

## Definition of Singleton Design Pattern
The Singleton Design Pattern ensures that:
- A class has only one instance throughout the lifetime of an application.
- Provides a global access point to that instance.
- Restricts the instantiation of the class to a single object.

This pattern is commonly used in scenarios where a single shared resource is required, such as:
- A player in a game.

## In the Context of the Tic-Tac-Toe Game Code
### Single Instance Control
- Both Player1 and Player2 are implemented using the Singleton pattern.
- Only one instance of Player1 and one instance of Player2 can exist at any time during the game.
- Guarantees that these two players are the only participants in the game, preventing accidental creation of multiple player instances.

### Global Access Point
- The `Instance()` method in Player1 and Player2 acts as the global access point for the respective players.
- Instead of creating new objects using a constructor, the game calls:
  - `Player1.Instance()` or `Player2.Instance()` to retrieve the single instance of each player.

## Note on Singleton Pattern
- The Singleton pattern can support multiple implementations by using:
  - An interface or an abstract class.
- This allows for polymorphism.

### In this Example
- The Player class is an abstract class, enabling multiple implementations such as Player1 and Player2 while maintaining a single instance for each.

## Polymorphism Explained in This Example
### Abstract Class Player
- Both Player1 and Player2 classes inherit from the Player abstract class.
- Defines common properties, including:
  - Name
  - Marker
- Includes a method:
  - `PrintPlayerInfo`.

### Overriding Methods
- The Player1 and Player2 classes override the `PrintPlayerInfo` method.
- Provide specific implementations of how to display player information.
- This is an example of method overriding, a key concept in polymorphism.

### Polymorphic Behavior in Action
- When the game logic interacts with Player objects:
  - It can use references to the abstract class Player.
  - The actual method that gets called (like `PrintPlayerInfo`) will depend on:
    - Whether the object is an instance of Player1 or Player2.

```csharp
currentPlayer = Player2.Instance("Bob", 'O'); // currentPlayer is now a Player2 instance
currentPlayer.PrintPlayerInfo(); // Calls Player2's implementation of PrintPlayerInfo
