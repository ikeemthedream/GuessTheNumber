using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersStory
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttkPwr { get; set; }
        public Player()
        {
            AttkPwr = 50;
            Health = 100;
        }
        public Player(string name)
        {
            Name = name;
            AttkPwr = 50;
            Health = 100;
        }

        public void DisplayPlayerStatus()
        {
            Console.WriteLine($"Name: {Name}" +
                $"\nHealth: {Math.Abs(Health)}" +
                $"\nAttkPwr: {AttkPwr}\n");
        }
    }
}
