using System;
using System.Collections.Generic;
using System.Text;

//provides template for creating new games
//basic formatting according to today's topics, referencing JD Heckenliable's formatting for accuracy.
//All non-initialization code, unless marked otherwise, is my own.
namespace rpsProject
{
    class Game
    {
		#region List of Rounds
		//creates list of rounds played this game
		private List<Round> rounds = new List<Round>();
		public List<Round> Rounds
		{
			get { return rounds; }
			set { rounds = value; }
		}
		#endregion

		#region Player Creation
		//set player 1
		private Player player1;
		public Player Player1
		{
			get { return player1; }
			set { player1 = value; }
		}

		//set player 2
		private Player player2;

		public Player Player2
		{
			get { return player2; }
			set { player2 = value; }
		}
        #endregion

        #region Player Initialization
		//sets player names on game start
		void InitializePlayers() //name setting taken from JD Heckenliable's formatting
		{
			//set player 1 name
			Console.Write("Player 1, please enter your name: ");
			player1 = new Player(Console.ReadLine());
			//set player 2 name
			Console.Write("Player 2, please enter your name: ");
			player2 = new Player(Console.ReadLine());
		}
        #endregion

        #region Start Game Method
        internal void StartGame()
		{
			InitializePlayers();

			//create player score trackers, local variables make tracking scores easier
			int player1Score = 0;
			int player2Score = 0;

			//Loop game rounds until a player has two or more points
			do
			{
				//create game round
				Round round = PlayRound();

				//assign score
				if (round.Winner == player1) //Player 1 won the round
				{
					player1Score++;
					player1.AddPlayerWin();
					player2.AddPlayerLoss();
				}
				else if (round.Winner == player2) //Player 2 won the round
				{
					player2Score++;
					player2.AddPlayerWin();
					player1.AddPlayerLoss();
				}

				//add round to list of played rounds
				rounds.Add(round);

				//display end of round info
				DisplayRoundResults(round);
			} while ((player1Score < 2) && (player2Score < 2)); //end loop when one player has 2+ points

			//Display final results of the game, including winner, final score, and number of ties.
			DisplayGameResults(player1Score, player2Score);
		}
        #endregion

        #region Create Round
        //Creates and runs a round of the game
        Round PlayRound()
		{
			//create object to hold round information
			Round round = new Round();
			//randomly seed the game round
			Random random = new Random();

			//set both player's choices
			round.Player1Choice = (Choice)random.Next(0, 3);
			round.Player2Choice = (Choice)random.Next(0, 3);

            #region Main Gameplay Logic Tree
            switch (round.Player1Choice) //switch case statement to check player 1's choice
			{
				case Choice.rock:
					switch (round.Player2Choice) //switch case statement to check player 2 choice and find winner
					{
						case Choice.paper:
							round.Winner = player2;
							break;
						case Choice.scissors:
							round.Winner = player1;
							break;
					}
					break;
				case Choice.paper:
					switch (round.Player2Choice) //switch case statement to check player 2 choice and find winner
					{
						case Choice.scissors:
							round.Winner = player2;
							break;
						case Choice.rock:
							round.Winner = player1;
							break;
					}
					break;
				case Choice.scissors:
					switch (round.Player2Choice) //switch case statement to check player 2 choice and find winner
					{
						case Choice.rock:
							round.Winner = player2;
							break;
						case Choice.paper:
							round.Winner = player1;
							break;
					}
					break;
			}
            #endregion

            return round;
		}
        #endregion

        #region End of Game Display
        //displays the results when the game is completed
        void DisplayGameResults(int player1Score, int player2Score)
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
		void DisplayRoundResults(Round round)
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
