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
            Console.WriteLine($"\nHi, {User.Name}\nYour Opponent is:\n{opponent.Name}");
            PausePhase();
        }
        public static void Game(Player User, Player opponent)
        {
            #region Data
            int targetNumber;
            int userNumber;
            int opponentNumber;
            #endregion
            while (true)
            {
                GetUsersInput(User, opponent, out targetNumber, out userNumber, out opponentNumber);
                CompareResults(User, opponent, userNumber, opponentNumber, targetNumber);
                if (User.Health > 0 && opponent.Health > 0)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Game Over");
                    return;
                }
            }
        }
        private static void GetUsersInput(Player User, Player opponent, out int targetNumber, out int userNumber, out int opponentNumber)
        {
            ShowStatus(User, opponent);
            #region Host Pick
            Console.WriteLine("Ask a friend to select a random " +
            "target number betweem 1 and 100");
            targetNumber = Convert.ToInt32(Console.ReadLine());
            PausePhase();
            #endregion
            #region Player Pick
            Console.WriteLine($"{User.Name}, guess what the target number is: ");
            userNumber = Convert.ToInt32(Console.ReadLine());
            PausePhase();
            #endregion
            #region Opponent Pick
            Console.WriteLine($"{opponent.Name}, guess what the target number is: ");
            opponentNumber = Convert.ToInt32(Console.ReadLine());
            PausePhase();
            #endregion
        }
        private static void CompareResults(Player User, Player opponent, int result1, int result2, int targetNumber)
        {
            #region Condition
            if (result1 >= targetNumber && result1 < result2 || result1 <= targetNumber && result1 > result2)
            {
                Console.WriteLine($"{User.Name} Wins\n");
                AttackPhase(User, opponent);
            }
            else if (result2 >= targetNumber && result2 < result1 || result2 <= targetNumber && result2 > result1)
            {
                Console.WriteLine("Ikeem Wins\n");
                AttackPhase(opponent, User);
            }
            ShowStatus(User, opponent);
            Console.ReadKey();
            Console.Clear();
            #endregion
        }
        private static void PausePhase()
        {
            Console.WriteLine($"Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void AttackPhase(Player Winner, Player Loser)
        {
            Loser.Health -= Winner.AttkPwr;
        }
        private static void ShowStatus(Player User, Player opponent)
        {
            UIManager.PrintStatus(User);
            UIManager.PrintStatus(opponent);
        }
    }
}
