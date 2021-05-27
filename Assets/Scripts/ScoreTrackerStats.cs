using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrackerStats
{
    public static int player1Score = 0;
    public static int player2Score = 0;
    public static int player3Score = 0;
    public static int player4Score = 0;
    public static bool tournamentRunning = true;
    public static int scoreToWin = 3;  // Amount to win

    public static int numPlayers = 4;
    public static bool randomSelection = true;  // Whether minigames will be random
}
