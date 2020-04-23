using System;
using System.Collections.Generic;
using System.Text;

//Provides template for storing player attributes, such as name and scores
//basic formatting according to today's topics, referencing JD Heckenliable's formatting for accuracy.
//All non-stock code, unless marked otherwise, is my own.
namespace rpsProject
{
    internal class Player
    {
        #region Player Creator
        //Allow creation of player, code created by JD Heckenliable
        public Player(String name) //when object is created, assign it parameter as name
        {
            playerName = name; //sets player name to parameter name
        }
        #endregion

        #region Player Name
        //provides holder for player name
        private String playerName;
        public String PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        #endregion

        #region Player Wins
        //tracks player wins
        private int playerWins;
        public int PlayerWins
        {
            get { return playerWins; }
            set { playerWins = value; }
        }
        #endregion

        #region Player Losses
        //tracks player losses
        private int playerLosses;
        public int PlayerLosses
        {
            get { return playerLosses; }
            set { playerLosses = value; }
        }
        #endregion

        #region Player Wins/Losses Adjustors
        //provide method for incrementing player wins
        public void AddPlayerWin()
        {
            playerWins++;
        }

        //provide method for incrementing player losses
        public void AddPlayerLoss()
        {
            playerLosses++;
        }
        #endregion
    }
}
