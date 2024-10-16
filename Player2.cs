using System;

namespace MyApp
{
    // Singleton class for Player2
    // Can support multiple implementations (IE: Interface) ****
    public class Player2 : Player
    {
        private static Player2 _instance;

        private Player2(string name, char marker) : base(name, marker) { }

        public static Player2 Instance(string name, char marker)
        {
            if (_instance == null)
            {
                _instance = new Player2(name, marker);
            }
            return _instance;
        }

        public override void PrintPlayerInfo()
        {
            Console.WriteLine($"{Name} is playing with '{Marker}'");
        }
    }
}
