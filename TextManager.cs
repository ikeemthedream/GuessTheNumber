using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PlayersStory
{
    public class TextManager
    {
        public static void IntroText(Player User, Player opponent)
        {
            Console.WriteLine("Enter a Name: ");
            User.Name = Console.ReadLine();
            Console.WriteLine($"Hi, {User.Name}\nYour Opponent is:\n{opponent.Name}");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Game(Player User, Player opponent)
        {
            #region Data
            int targetNumber;
            int userNumber;
            int opponentNumber;

            int result1;
            int result2;
            #endregion
            #region Game Loop
            while (true)
            {
                #region Host Pick
                Console.WriteLine("Ask a friend to select a random " +
                "target number betweem 1 and 100");
                targetNumber = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();
                #endregion
                #region Player Pick
                Console.WriteLine($"{User.Name}, guess what the target number is: ");
                userNumber = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();
                #endregion
                #region Opponent Pick
                Console.WriteLine($"{opponent.Name}, guess what the target number is: ");
                opponentNumber = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
                Console.Clear();
                #endregion
                #region Results
                result1 = targetNumber - userNumber;
                result2 = targetNumber - opponentNumber;
                #endregion
                #region Condition
                if (result1 < result2)
                {
                    Console.WriteLine($"{User.Name} Wins\n");
                    Attack(User, opponent);
                }
                else if (result2 < result1)
                {
                    Console.WriteLine("Ikeem Wins\n");
                    Attack(opponent, User);
                }
                Console.ReadKey();
                Console.Clear();
                #endregion
                #region EndGame
                if (User.Health > 0 && opponent.Health > 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Game Over");
                    return;
                }

                return;
                #endregion
            }
            #endregion
        }

        public static void Attack(Player Winner, Player Loser)
        {

            Loser.Health -= Winner.AttkPwr;
            UIManager.PrintStatus(Winner);
            UIManager.PrintStatus(Loser);  

        }
    }
}
