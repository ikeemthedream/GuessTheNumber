using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PlayersStory
{
    public class GameManager
    {
        public static void IntroText(Player User, Player opponent)
        {
            Console.WriteLine("Enter a Name: ");
            User.Name = Console.ReadLine();
            Console.WriteLine($"Hi, {User.Name}\nYour Opponent is:\n{opponent.Name}");
            StopPhase();
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
            while (true)
            {
                PhaseOne(User, opponent, out targetNumber, out userNumber, out opponentNumber, out result1, out result2);
                PhaseTwo(User, opponent, result1, result2);
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
        }
        private static void PhaseOne(Player User, Player opponent, out int targetNumber, out int userNumber, out int opponentNumber, out int result1, out int result2)
        {
            #region Host Pick
            Console.WriteLine("Ask a friend to select a random " +
            "target number betweem 1 and 100");
            targetNumber = Convert.ToInt32(Console.ReadLine());
            StopPhase();
            #endregion
            #region Player Pick
            Console.WriteLine($"{User.Name}, guess what the target number is: ");
            userNumber = Convert.ToInt32(Console.ReadLine());
            StopPhase();
            #endregion
            #region Opponent Pick
            Console.WriteLine($"{opponent.Name}, guess what the target number is: ");
            opponentNumber = Convert.ToInt32(Console.ReadLine());
            StopPhase();
            #endregion
            #region Results
            result1 = targetNumber - userNumber;
            result2 = targetNumber - opponentNumber;
            #endregion
        }
        private static void PhaseTwo(Player User, Player opponent, int result1, int result2)
        {
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
        }
        private static void StopPhase()
        {
            Console.ReadKey();
            Console.Clear();
        }
        public static void Attack(Player Winner, Player Loser)
        {
            Loser.Health -= Winner.AttkPwr;
        }
    }
}
