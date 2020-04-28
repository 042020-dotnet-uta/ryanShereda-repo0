using System;
using System.Collections.Generic;
using System.Text;

//provides template for creating new games
//basic formatting according to today's topics, referencing JD Heckenliable's formatting for accuracy.
//All non-stock code, unless marked otherwise, is my own.
namespace rpsProject
{
    internal class Game
    {
		public int GameID { get; set; }

		#region List of Rounds
		//creates list of rounds played this game
		private protected List<Round> rounds = new List<Round>();
		public List<Round> Rounds
		{
			get { return rounds; }
			set { rounds = value; }
		}
		#endregion

		#region Player Creation
		//set player 1
		private protected Player player1;
		public Player Player1
		{
			get { return player1; }
			set { player1 = value; }
		}

		//set player 2
		private protected Player player2;

		public Player Player2
		{
			get { return player2; }
			set { player2 = value; }
		}
        #endregion

        #region Player Initialization
		//sets player names on game start
		protected void InitializePlayers() //name setting taken from JD Heckenliable's formatting
		{
			//set player 1 name
			Console.Write("Player 1, please enter your name: ");
			player1 = new Player(Console.ReadLine());
			//set player 2 name
			Console.Write("Player 2, please enter your name: ");
			player2 = new Player(Console.ReadLine());
		}
        #endregion

        #region End of Game Display
        //displays the results when the game is completed
        internal void DisplayGameResults(int player1Score, int player2Score)
		{
			//calculates number of tie rounds, equation created by JD Heckenliable (as far as I know)
			//subtract player scores from number of rounds to find number of ties
			int tieCount = rounds.Count - (player1Score + player2Score);

			//determine winner
			if (player1Score >= 2) //player 1 wins
			{
				//write results to console: Player 1 won
				Console.WriteLine($"{player1.PlayerName} wins {player1Score}-{player2Score} with {tieCount} tie(s).");
			}
			else //player 2 won
			{
				//write results to console: Player 2 won
				Console.WriteLine($"{player2.PlayerName} wins {player2Score}-{player1Score} with {tieCount} tie(s).");
			}
		}
        #endregion

        #region End of Round Display
		//displays results when round is completed
		internal void DisplayRoundResults(Round round)
		{
			//check to see who won
			if (round.Winner == null) //tie round, no winner
			{
				//display the round was tied, on which choice
				Console.WriteLine($"Round {rounds.Count}: {player1.PlayerName} and {player2.PlayerName} both chose {round.Player1Choice} -- No winner.");
			}
			else //round did not end in tie
			{
				//display player choices, as well as the winner
				Console.WriteLine($"Round {rounds.Count}: {player1.PlayerName} had {round.Player1Choice}, {player2.PlayerName} had {round.Player2Choice} -- {round.Winner.PlayerName} wins.");
			}
		}
        #endregion
    }
}
