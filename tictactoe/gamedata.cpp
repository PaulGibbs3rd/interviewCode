#include "gamedata.h"
// Base constructor uses zeroArray() to initialize all zero's in array
GameData::GameData()
{
    zeroArray();
}
// Sets the winner based off mod and then increments player for next check
int GameData::setPlayer()
{
  int player = 0;
  if(playerCount % 2 == 1)
  {
      player = 0;
  }
  else if(playerCount % 2 == 0)
  {
      player = 1;
  }
  playerCount++;
   return player;
}
// Checks for a winner from the array.  If winner is found sets isWinner to 1 through setWinner()
void GameData::checkWinner()
{
    // CHECK WINNER FOR PLAYER X
    if(boardArray[0][0] == 1 && boardArray[0][1] == 1 && boardArray[0][2] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[1][0] == 1 && boardArray[1][1] == 1 && boardArray[1][2] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[2][0] == 1 && boardArray[2][1] == 1 && boardArray[2][2] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[0][0] == 1 && boardArray[1][0] == 1 && boardArray[2][0] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[0][1] == 1 && boardArray[1][1] == 1 && boardArray[2][1] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[0][2] == 1 && boardArray[1][2] == 1 && boardArray[2][2] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[0][0] == 1 && boardArray[1][1] == 1 && boardArray[2][2] == 1)
    {
        setWinner(true);
    }
    else if(boardArray[2][0] == 1 && boardArray[1][1] == 1 && boardArray[0][2] == 1)
    {
        setWinner(true);
    }
    // CHECK WINNER FOR PLAYER O
    else if(boardArray[0][0] == 2 && boardArray[0][1] == 2 && boardArray[0][2] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[1][0] == 2 && boardArray[1][1] == 2 && boardArray[1][2] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[2][0] == 2 && boardArray[2][1] == 2 && boardArray[2][2] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[0][0] == 2 && boardArray[1][0] == 2 && boardArray[2][0] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[0][1] == 2 && boardArray[1][1] == 2 && boardArray[2][1] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[0][2] == 2 && boardArray[1][2] == 2 && boardArray[2][2] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[0][0] == 2 && boardArray[1][1] == 2 && boardArray[2][2] == 2)
    {
        setWinner(true);
    }
    else if(boardArray[2][0] == 2 && boardArray[1][1] == 2 && boardArray[0][2] == 2)
    {
        setWinner(true);
    }
    else
    {
        setWinner(false);
    }
}
// Sets isWinner to 1 to indicate a winner was identified
void GameData::setWinner(bool isWinner)
{
    this->isWinner = isWinner;
}
// Sets isWinner to 1 to indicate a winner was identified
bool GameData::getWinner()
{
    bool winner = isWinner;
    return winner;
}
void GameData::zeroArray()
{
    for(int i = 0; i <3;i++)
    {
    for(int j = 0; j<3;j++)
    {
        boardArray[i][j] = 0;
    }
    }
}
