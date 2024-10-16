/*
Definition of Singleton Design Pattern:

The Singleton Design Pattern ensures that a class has only one instance throughout the lifetime of an application, while providing a global access point to that instance. It restricts the instantiation of the class to a single object and is commonly used in scenarios where a single shared resource, such as a player in a game, is required.

In the context of the Tic-Tac-Toe game code:

Single Instance Control: Both Player1 and Player2 are implemented using the Singleton pattern, meaning that only one instance of Player1 and one instance of Player2 can exist at any time during the game. This guarantees that these two players are the only participants in the game, and the system doesn’t accidentally create multiple instances of a player.

Global Access Point: The Instance() method in Player1 and Player2 acts as the global access point for the respective players. Instead of creating new objects using a constructor, the game calls Player1.Instance() or Player2.Instance() to retrieve the single instance of each player.
*/


/* 
 * Note: Singleton pattern can support multiple implementations by using an interface (or an abstract class),
 * which allows for polymorphism. In this example, the Player class is an abstract class, enabling multiple
 * implementations such as Player1 and Player2 while maintaining a single instance for each.
 */

 // Polymorphism Explained in This Example:

// Abstract Class Player:
// Both Player1 and Player2 classes inherit from the Player abstract class, which defines common properties 
// (Name, Marker) and a method (PrintPlayerInfo).

// Overriding Methods:
// The Player1 and Player2 classes override the PrintPlayerInfo method, meaning each class provides its own 
// specific implementation of how to display player information. This is method overriding, a key concept in polymorphism.

// Polymorphic Behavior in Action:
// When the game logic interacts with Player objects, it can use references to the abstract class Player, but 
// the actual method that gets called (like PrintPlayerInfo) will depend on whether the object is an instance 
// of Player1 or Player2.

// For example, when the game calls currentPlayer.PrintPlayerInfo(), it doesn't need to know whether currentPlayer 
// is of type Player1 or Player2. It simply calls the method, and the appropriate implementation is executed 
// based on the actual type of the object.

Example of Polymorphism:

Player currentPlayer = Player1.Instance("Alice", 'X');  // currentPlayer is of type Player, but holds Player1 instance
currentPlayer.PrintPlayerInfo();  // Calls Player1's implementation of PrintPlayerInfo

currentPlayer = Player2.Instance("Bob", 'O');  // currentPlayer is now a Player2 instance
currentPlayer.PrintPlayerInfo();  // Calls Player2's implementation of PrintPlayerInfo

// The same method PrintPlayerInfo is called, but different behavior occurs depending on the object type (Player1 or Player2).
