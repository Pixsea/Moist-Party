using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(ScoreTrackerStats))]
public class ScoreTrackerWindow : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ScoreTrackerStats.player1Score = 
            EditorGUILayout.IntField("Player 1 score: ", ScoreTrackerStats.player1Score);
        ScoreTrackerStats.player2Score = 
            EditorGUILayout.IntField("Player 2 score: ", ScoreTrackerStats.player2Score);
        ScoreTrackerStats.player3Score = 
            EditorGUILayout.IntField("Player 3 score: ", ScoreTrackerStats.player3Score);
        ScoreTrackerStats.player4Score = 
            EditorGUILayout.IntField("Player 4 score: ", ScoreTrackerStats.player4Score);

        ScoreTrackerStats.randomSelection =
            EditorGUILayout.Toggle("Random selection: ", ScoreTrackerStats.randomSelection);
    }
}

public class ScoreTrackerStats : MonoBehaviour
{
    public static ScoreTrackerStats instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static int player1Score = 0;
    public static int player2Score = 0;
    public static int player3Score = 0;
    public static int player4Score = 0;
    public static bool tournamentRunning = true;
    public static int scoreToWin = 3;  // Amount to win

    public static int numPlayers = 4;
    public static bool randomSelection = true;  // Whether minigames will be random
}
