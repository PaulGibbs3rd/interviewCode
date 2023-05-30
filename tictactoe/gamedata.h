#ifndef GAMEDATA_H
#define GAMEDATA_H


class GameData
{
public:
    int playerCount = 1;                    // Used with % to determin player turns
    char boardArray [2][2];                 // Array where X or O is held
    bool isWinner = false;                      // Verify if a winner has been identified
    int winsP1 = 1;                         // Used to increment number of wins for player init to 1 for first win
    int winsP2 = 1;                         // Used to increment number of wins for player init to 1 for first win

public:
    GameData();                             // Base constructor
    int setPlayer();                        // Rotates the players
    void checkWinner();                     // Sets winner through setWinner if one is identifies in array check
    void setWinner(bool isWinner);          // Used to set isWinner if checkWinner identifies a winner
    bool getWinner();                       // Used to get isWinner if to verify a winner
    void zeroArray();
};

#endif // GAMEDATA_H
