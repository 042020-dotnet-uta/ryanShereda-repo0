using System;
using System.Collections.Generic;
using System.Text;

//Provides templates for building each round of the game
//basic formatting according to today's topics, referencing JD Heckenliable's formatting for accuracy.
//All non-stock code, unless marked otherwise, is my own.
namespace rpsProject
{
    internal class Round
    {
        #region Winner
        //creates holder for winner
        private Player winner;
		public Player Winner
		{
			get { return winner; }
			set { winner = value; }
		}
        #endregion

        public int roundID { get; set; }

        #region Player1Choice
        //creates holder for player 1's choice
        private Choice player1Choice;
		public Choice Player1Choice
		{
			get { return player1Choice; }
			set { player1Choice = value; }
		}
        #endregion

        #region Player2Choice
        //creates holder for player 2's choice
        private Choice player2Choice;
        public Choice Player2Choice
        {
            get { return player2Choice; }
            set { player2Choice = value; }
        }
        #endregion
    }
}
