using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlayersStory
{
    class UIManager
    {
        public static void PrintStatus(Player playerStatus)
        {
            Console.WriteLine($"Name: {playerStatus.Name}");
            Console.WriteLine($"Health: {Math.Abs(playerStatus.Health)}");
            Console.WriteLine($"AttkPwr: {playerStatus.AttkPwr}\n");
        }
    }
}
