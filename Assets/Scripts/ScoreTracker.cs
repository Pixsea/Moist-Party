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
    [SerializeField]
    private Text scoretoWinText;

    public bool tournamentRunning;
    private int scoreToWin;
    public Text mainText;

    public GameObject mashButton;  //  Buttons to disable when showing a win screen
    public GameObject simonButton;
    public GameObject dartButton;
    public GameObject parkourButton;
    public GameObject glowRunnerButton;
    private bool done = false;  // whether the game is done
    private float timer = 0;

    public Text numPlayertext;  // text to change to show how many players are in
    public Text scoreText;  // text to change to show score to win
    public Text randomSelectionText;  // text to change to show if minigame selection will be random


    // stuff to handle choosing random
    [SerializeField]
    private bool onBoardScene;
    private float randomTimer;  //How long the player is on the board scene
    [SerializeField]
    private SceneChanger sceneChanger;




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
        //if (Input.GetKeyDown("2"))
        //{
        //    SetNumPlayers(2);
        //}

        //else if (Input.GetKeyDown("3"))
        //{
        //    SetNumPlayers(3);
        //}

        //else if (Input.GetKeyDown("4"))
        //{
        //    SetNumPlayers(4);
        //}

        //else if (Input.GetKeyDown("5"))
        //{
        //    SetWinScore(2);
        //}
    }


    void FixedUpdate()
    {
        //if (done)
        //{
        //    if (timer <= 0)
        //    {
        //        ResetScore();
        //        SceneManager.LoadScene("BoardScene");
        //    }
        //    timer--;
        //}


        // Random selection logic
        if (ScoreTrackerStats.randomSelection && onBoardScene && !done)
        {
            //Disable buttons
            mashButton.SetActive(false);
            simonButton.SetActive(false);
            dartButton.SetActive(false);
            parkourButton.SetActive(false);
            glowRunnerButton.SetActive(false);
            scoretoWinText.text = "";

            mainText.text = "Selecting next minigame...";

            if (randomTimer <= 0)
            {
                float temp = Random.Range(0f, 5f);

                if (temp <= 1)
                {
                    sceneChanger.LoadMiniGame("MashHappy");
                }
                else if (temp <= 2)
                {
                    sceneChanger.LoadMiniGame("SimonSays");
                }
                else if (temp <= 3)
                {
                    sceneChanger.LoadMiniGame("DartofGold");
                }
                else if (temp <= 4)
                {
                    sceneChanger.LoadMiniGame("ParkourScene");
                }
                else if (temp <= 5)
                {
                    sceneChanger.LoadMiniGame("SampleScene");
                }
            }
            randomTimer--;
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
        randomTimer = 5f / Time.fixedDeltaTime;

        done = false;


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
            if (ScoreTrackerStats.numPlayers < 3)
            {
                player3Text.gameObject.SetActive(false);
            }
            else
            {
                player3Text.gameObject.SetActive(true);
                player3Text.text = player3Score.ToString();
            }
        }
        if (player4Text != null)
        {
            if (ScoreTrackerStats.numPlayers < 4)
            {
                player4Text.gameObject.SetActive(false);
            }
            else
            {
                player4Text.gameObject.SetActive(true);
                player4Text.text = player4Score.ToString();
            }
        }
        if (scoretoWinText != null)
        {
            scoretoWinText.text = "Points to Win: " + scoreToWin.ToString();
        }


        if (tournamentRunning && onBoardScene)
        {
            // Check for winners
            if (player1Score >= scoreToWin)
            {
                done = true;

                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);
                glowRunnerButton.SetActive(false);
                scoretoWinText.text = "";

                mainText.text = "Player 1 Wins The Tournament!";

                done = true;
            }

            else if (player2Score >= scoreToWin)
            {
                done = true;

                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);
                glowRunnerButton.SetActive(false);
                scoretoWinText.text = "";

                mainText.text = "Player 2 Wins The Tournament!";

                done = true;
            }

            else if (player3Score >= scoreToWin)
            {
                done = true;

                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);
                glowRunnerButton.SetActive(false);
                scoretoWinText.text = "";

                mainText.text = "Player 3 Wins The Tournament!";

                done = true;
            }

            else if (player4Score >= scoreToWin)
            {
                done = true;

                //Disable buttons
                mashButton.SetActive(false);
                simonButton.SetActive(false);
                dartButton.SetActive(false);
                parkourButton.SetActive(false);
                glowRunnerButton.SetActive(false);
                scoretoWinText.text = "";

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
        //ScoreTrackerStats.scoreToWin = scoreToWin;
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

        if (numPlayertext != null)
        {
            numPlayertext.text = "Players: " + numPlayers.ToString();
        }
    }



    // Get the amount of players playing
    public int GetNumPlayers()
    {
        return ScoreTrackerStats.numPlayers;
    }


    // -1 = decrease by one, -2 = increase by 1
    public void SetWinScore(int newScore)
    {
        if (newScore == -2)
        {
            ScoreTrackerStats.scoreToWin += 1;
        }
        else if (newScore == -1)
        {
            ScoreTrackerStats.scoreToWin -= 1;
        }
        else
        {
            ScoreTrackerStats.scoreToWin = newScore;
        }

        if (ScoreTrackerStats.scoreToWin < 1)
        {
            ScoreTrackerStats.scoreToWin = 1;
        }
        else if (ScoreTrackerStats.scoreToWin > 9)
        {
            ScoreTrackerStats.scoreToWin = 9;
        }

        if (scoreText != null)
        {
            scoreText.text = ScoreTrackerStats.scoreToWin.ToString();
        }
    }


    // Change whether minigame selection is random or not
    public void ChangeRandomSelection()
    {
        ScoreTrackerStats.randomSelection = !ScoreTrackerStats.randomSelection;
        
        if (randomSelectionText != null)
        {
            if (ScoreTrackerStats.randomSelection == true)
            {
                randomSelectionText.text = "Random";
                //Debug.Log("random");
            }
            else
            {
                randomSelectionText.text = "Choose";
                //Debug.Log("choose");
            }
            //randomSelectionText.text = ScoreTrackerStats.randomSelection.ToString();
        }
    }

}
