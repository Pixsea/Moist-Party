using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    static ScoreTrackerStats stats;  // a static instacne of the script to save score between scenes

    private int player1Score;
    private int player2Score;
    private int player3Score;
    private int player4Score;

    [SerializeField]
    private Text player1Text = null;
    [SerializeField]
    private Text player2Text;
    [SerializeField]
    private Text player3Text;
    [SerializeField]
    private Text player4Text;


    // Start is called before the first frame update
    void Start()
    {
        stats = new ScoreTrackerStats();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnEnable()
    {
        //player1Score = PlayerPrefs.GetInt("player1Score");
        //player2Score = PlayerPrefs.GetInt("player2Score");
        //player3Score = PlayerPrefs.GetInt("player3Score");
        //player4Score = PlayerPrefs.GetInt("player4Score");

        // Get scores from script

        player1Score = ScoreTrackerStats.player1Score;
        player2Score = ScoreTrackerStats.player2Score;
        player3Score = ScoreTrackerStats.player3Score;
        player4Score = ScoreTrackerStats.player4Score;


        if (player1Text != null)
        {
            player1Text.text = player1Score.ToString();
        }
        if (player2Text != null)
        {
            player2Text.text = player2Score.ToString();
        }
        if (player3Text != null)
        {
            player3Text.text = player3Score.ToString();
        }
        if (player4Text != null)
        {
            player4Text.text = player4Score.ToString();
        }
    }

    void OnDisable()
    {
        //PlayerPrefs.SetInt("player1Score", player1Score);
        //PlayerPrefs.SetInt("player2Score", player2Score);
        //PlayerPrefs.SetInt("player3Score", player3Score);
        //PlayerPrefs.SetInt("player4Score", player4Score);


        // Set scores into script

        ScoreTrackerStats.player1Score = player1Score;
        ScoreTrackerStats.player2Score = player2Score;
        ScoreTrackerStats.player3Score = player3Score;
        ScoreTrackerStats.player4Score = player4Score;
    }

    public void IncreaseScore(int playerNum)
    {
        if (playerNum == 1)
        {
            player1Score += 1;
        }
        if (playerNum == 2)
        {
            player2Score += 1;
        }
        if (playerNum == 3)
        {
            player3Score += 1;
        }
        if (playerNum == 4)
        {
            player4Score += 1;
        }
    }


    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        player3Score = 0;
        player4Score = 0;

        ScoreTrackerStats.player1Score = 0;
        ScoreTrackerStats.player2Score = 0;
        ScoreTrackerStats.player3Score = 0;
        ScoreTrackerStats.player4Score = 0;
    }
}
