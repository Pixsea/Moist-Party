using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public bool tournamentRunning;
    private int scoreToWin;
    public Text mainText;

    public GameObject mashButton;  //  Buttons to disable when showing a win screen
    public GameObject simonButton;
    public GameObject dartButton;
    public GameObject parkourButton;
    private bool done = false;  // whether the game is done
    private float timer = 0;

    public Text numPlayertext;  // text to change to show how many players are in


    // Start is called before the first frame update
    void Start()
    {
        if (mainText != null)
        {
            //mainText.text = "";
        }

        stats = new ScoreTrackerStats();
        timer = 5f / Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            SetNumPlayers(2);
        }

        else if (Input.GetKeyDown("3"))
        {
            SetNumPlayers(3);
        }

        else if (Input.GetKeyDown("4"))
        {
            SetNumPlayers(4);
        }

        //else if (Input.GetKeyDown("5"))
        //{
        //    SetWinScore(2);
        //}
    }


    void FixedUpdate()
    {
        if (done)
        {
            if (timer <= 0)
            {
                ResetScore();
                SceneManager.LoadScene("BoardScene");
            }
            timer--;
        }
    }

    void OnEnable()
    {
        // Get scores from script
        player1Score = ScoreTrackerStats.player1Score;
        player2Score = ScoreTrackerStats.player2Score;
        player3Score = ScoreTrackerStats.player3Score;
        player4Score = ScoreTrackerStats.player4Score;
        tournamentRunning = ScoreTrackerStats.tournamentRunning;
        scoreToWin = ScoreTrackerStats.scoreToWin;


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


        if (tournamentRunning && (mainText != null))
        {
            if (player1Score >= scoreToWin)
            {
                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);

                mainText.text = "Player 1 Wins The Tournament!";

                done = true;
            }

            else if (player2Score >= scoreToWin)
            {
                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);

                mainText.text = "Player 2 Wins The Tournament!";

                done = true;
            }

            else if (player3Score >= scoreToWin)
            {
                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);

                mainText.text = "Player 3 Wins The Tournament!";

                done = true;
            }

            else if (player4Score >= scoreToWin)
            {
                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);

                mainText.text = "Player 4 Wins The Tournament!";

                done = true;
            }
        }
    }

    void OnDisable()
    {
        // Set scores into script

        ScoreTrackerStats.player1Score = player1Score;
        ScoreTrackerStats.player2Score = player2Score;
        ScoreTrackerStats.player3Score = player3Score;
        ScoreTrackerStats.player4Score = player4Score;
        ScoreTrackerStats.tournamentRunning = tournamentRunning;
        ScoreTrackerStats.scoreToWin = scoreToWin;
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



    //  Set how many people are num playing
    public void SetNumPlayers(int numPlayers)
    {
        ScoreTrackerStats.numPlayers = numPlayers;

        numPlayertext.text = "Players: " + numPlayers.ToString();
    }



    // Get the amount of players playing
    public int GetNumPlayers()
    {
        return ScoreTrackerStats.numPlayers;
    }


    public void SetWinScore(int newScore)
    {
        scoreToWin = newScore;
    }
}
