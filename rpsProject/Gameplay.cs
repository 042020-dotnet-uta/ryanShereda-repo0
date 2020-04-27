using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//This class holds the two core gameplay loops used in the RPS game.
//basic formatting according to today's topics, referencing JD Heckenliable's formatting for accuracy.
//All non-stock code, unless marked otherwise, is my own.
namespace rpsProject
{
    class Gameplay : Game
    {

		//create logger for console app
		//creation code taken from Mark Moore class rps project
		private readonly ILogger _logger;
		public Gameplay(ILogger<Gameplay> logger)
		{
			_logger = logger;
		}

		#region Start Game Method
		internal void StartGame()
		{
			_logger.LogInformation("Game begun");
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
					//_logger.LogInformation("Player 1 won the round");
					player1Score++;
					player1.AddPlayerWin();
					player2.AddPlayerLoss();
				}
				else if (round.Winner == player2) //Player 2 won the round
				{
					//_logger.LogInformation("Player 2 won the round");
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
			//_logger.LogInformation("Player 1 selected something");
			round.Player2Choice = (Choice)random.Next(0, 3);
			//_logger.LogInformation("Player 2 selected something");

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
	}
}
