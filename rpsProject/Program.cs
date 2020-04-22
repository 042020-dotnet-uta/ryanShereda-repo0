using System;

//Ryan Shereda, JD Heckenliable, Michael Hall
namespace rpsProject
{
    //create enumerated list for each possible choice
    //{rock, paper, scissors}
    public enum Choice
    {
        rock,
        paper,
        scissors
    }

    class Program
    {
        //number tie count
        public static int tieCount = 0;
        //round counter
        public static int roundNumber = 1;

        static void Main(string[] args)
        {
            
            //create player 1 object
            Player player1 = new Player();
            //create player 2 object
            Player player2 = new Player();

            //set player 1 name (readLine)
            System.Console.WriteLine("Player 1, please input your name:");
            player1.playerName = Console.ReadLine();
            //set player 2 name (readLine)
            System.Console.WriteLine("Player 2, please input your name:");
            player2.playerName = Console.ReadLine();

            //repeat main gameplay method until one wins
            //Do while loop {

                //Infinite loop, player scores not being adjusted correctly?
            do
            {
                //run main gameplay method
                MainGameplay(player1, player2);
            } while ((player1.playerScore < 2) && (player2.playerScore < 2));    //ends when one player has 2 or more points


            //if player 1 score more than 2
            if (player1.playerScore >= 2) {
                //write to console "[player1] wins [player1.score]-[player2.score] with [tie count] ties"
                System.Console.WriteLine($"{player1.playerName} wins {player1.playerScore}-{player2.playerScore} with {tieCount} tie(s).");
            } else if (player2.playerScore >= 2) {   //} else if player 2 score more than 2 {
                //write to console "[player2] wins [player2.score]-[player1.score] with [tie count] ties"
                System.Console.WriteLine($"{player2.playerName} wins {player2.playerScore}-{player1.playerScore} with {tieCount} tie(s).");
            } else {
                System.Console.WriteLine($" Player 1 score: {player1.playerScore}");
                System.Console.WriteLine($" Player 2 score: {player2.playerScore}");
                System.Console.WriteLine("Critical Failure");
            }
            
        }

        //main gameplay method(round # parameter){
        public static void MainGameplay(Player player1, Player player2)
        {
            Random rnd = new Random();
            //variable to hold winner
            Player winner = player1;
            //variable to hold player 1 choice
            Choice player1Choice;
            //variable to hold player 2 choice
            Choice player2Choice;


            //player 1 gets random enum/number
            player1Choice = (Choice)rnd.Next(0,3);
            //player 2 gets random enum/number
            player2Choice = (Choice)rnd.Next(0,3);

            //if statement checking player 1's choice
            if (player1Choice == Choice.rock) {
                //nested if statement checking player 2's choice
                if (player2Choice == Choice.paper) {
                    //player 2 wins
                    winner = player2;
                } else if (player2Choice == Choice.scissors) {
                    //player 1 wins
                    winner = player1;
                }
            } else if (player1Choice == Choice.paper) {
                //nested if statement checking player 2's choice
                if (player2Choice == Choice.scissors) {
                    //player 2 wins
                    winner = player2;
                } else if (player2Choice == Choice.rock) {
                    //player 1 wins
                    winner = player1;
                }
            } else if (player1Choice == Choice.scissors) {
                //nested if statement checking player 2's choice
                if (player2Choice == Choice.rock) {
                    //player 2 wins
                    winner = player2;
                } else if (player2Choice == Choice.paper) {
                    //player 1 wins
                    winner = player1;
                }
            }

            //check winner ([IF] there is a tie)
            if(player1Choice == player2Choice) {
                //write there was a tie
                System.Console.WriteLine($"Round {roundNumber}: {player1.playerName} and {player2.playerName} had {player1Choice} -- No winner.");
            
                //increment tie counter
                tieCount++;
            } else {        //[ELSE] a player won
                //Winner's score + 1
                winner.IncreaseScore();

                //write results to console
                //round # - [player1] had [value], [player2] had [value] - [winner] won
                System.Console.WriteLine($"Round {roundNumber}: {player1.playerName} had {player1Choice}, {player2.playerName} had {player2Choice} -- {winner.playerName} wins.");            
            }
            roundNumber++;

        }
    }

    //small struct to hold player names/scores {
    public class Player
    {
        //player name variable holder
        public String playerName;
        //player score variable holder
        public int playerScore;

        //method for increasing player's score
        public void IncreaseScore() 
        {
            playerScore++;
        }

        //because this is public, don't need getters/setters

        //initialize player variables(name) method
        //public void SetPlayerName(String setPlayerName)
        //{
        //    playerName = setPlayerName;
        //}
    }
    
}
