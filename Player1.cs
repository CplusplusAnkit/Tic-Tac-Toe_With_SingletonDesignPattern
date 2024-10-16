using System;

namespace MyApp
{
    // Singleton class for Player1
    // Can support multiple implementations (IE: Interface) ****

    /* 
        * Note: Singleton pattern can support multiple implementations by using an interface (or an abstract class),
        * which allows for polymorphism. In this example, the Player class is an abstract class, enabling multiple
        * implementations such as Player1 and Player2 while maintaining a single instance for each.
    */

    public class Player1 : Player
    {
        private static Player1 _instance;

        private Player1(string name, char marker) : base(name, marker) { }

        public static Player1 Instance(string name, char marker)
        {
            if (_instance == null)
            {
                _instance = new Player1(name, marker);
            }
            return _instance;
        }

        public override void PrintPlayerInfo()
        {
            Console.WriteLine($"{Name} is playing with '{Marker}'");
        }
    }

}
