using System;
using System.Collections.Generic;

namespace MyApp
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char Marker { get; set; }
        // Print Move from 1 to last
        public List<Tuple<int,int>> AllMoves {get;set;}

        protected Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
            AllMoves = new List<Tuple<int,int>>();
        }

        // Abstract method to print player information

        //polymorphism allows for code reuse and flexibility, making the game engine code more modular and scalable.
        //The same method PrintPlayerInfo is called, but different behavior occurs depending on whether currentPlayer is Player1 or Player2. 
        //This is polymorphism in action—one interface, many implementations.
        public abstract void PrintPlayerInfo();
    }
}