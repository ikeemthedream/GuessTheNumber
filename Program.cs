using PlayersStory;
using System;

class Program
{
    private static void Main(string[] args)
    {
        Player player = new Player();
        Player opponent= new Player("Ikeem");

        GameManager.IntroText(player, opponent);
        GameManager.Game(player, opponent);

    }
}