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

    // Used to move plaeyrs to the winner arena
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;  //Used to enable/disable the extra players if eneded
    [SerializeField]
    private GameObject player4;
    [SerializeField]
    private GameObject sceneCamera;
    [SerializeField]
    private GameObject winnerPodium;  //Used to warp the winner to the correct position


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

    public Text bigMiddleText;  // Used to Show who won

    public GameObject mashButton;  //  Buttons to disable when showing a win screen
    public GameObject simonButton;
    public GameObject dartButton;
    public GameObject parkourButton;
    public GameObject glowRunnerButton;
    public GameObject jumpRopeButton;
    private bool done = false;  // whether the game is done
    private float timer = 0;

    public Text numPlayertext;  // text to change to show how many players are in
    public Text scoreText;  // text to change to show score to win
    public Text randomSelectionText;  // text to change to show if minigame selection will be random

    public GameObject thingsToEnable;


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
        if (Input.GetKeyDown(KeyCode.M))
        {
            //WinScreen(1);
        }
    }


    void FixedUpdate()
    {
        // Random selection logic
        if (ScoreTrackerStats.randomSelection && onBoardScene && !done)
        {
            thingsToEnable.SetActive(false);

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
                player3.SetActive(false);
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
                player4.SetActive(false);
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
                WinScreen(1);
            }

            else if (player2Score >= scoreToWin)
            {
                WinScreen(2);
            }

            else if (player3Score >= scoreToWin)
            {
                WinScreen(3);
            }

            else if (player4Score >= scoreToWin)
            {
                WinScreen(4);
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
            scoreText.text = "Points to win:\n" + ScoreTrackerStats.scoreToWin.ToString();
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
                randomSelectionText.text = "Minigame selection:\nRandom";
                //Debug.Log("random");
            }
            else
            {
                randomSelectionText.text = "Minigame selection:\nChoose";
                //Debug.Log("choose");
            }
            //randomSelectionText.text = ScoreTrackerStats.randomSelection.ToString();
        }
    }


    void WinScreen(int playerNum)
    {
        scoretoWinText.gameObject.SetActive(false);
        done = true;
        thingsToEnable.SetActive(false);
        mainText.gameObject.SetActive(false);
        bigMiddleText.gameObject.SetActive(true);
       

        SoundManager.instance.PlaySound("disco");


        player1.transform.position += new Vector3(200, 0, 0);
        player2.transform.position += new Vector3(200, 0, 0);
        player3.transform.position += new Vector3(200, 0, 0);
        player4.transform.position += new Vector3(200, 0, 0);
        sceneCamera.gameObject.transform.position += new Vector3(200, -5, -10);
        sceneCamera.gameObject.transform.rotation = Quaternion.Euler(55, 0, 0);

        if (playerNum == 1)
        {
            player1.transform.position = new Vector3(winnerPodium.transform.position.x, winnerPodium.transform.position.y + 2.1f, winnerPodium.transform.position.z);
            player1.transform.rotation = Quaternion.Euler(0, 180, 0);
            bigMiddleText.text = "Player 1 Wins The Tournament!";
        }
        else if (playerNum == 2)
        {
            player2.transform.position = new Vector3(winnerPodium.transform.position.x, winnerPodium.transform.position.y + 2.1f, winnerPodium.transform.position.z);
            player2.transform.rotation = Quaternion.Euler(0, 180, 0);
            bigMiddleText.text = "Player 2 Wins The Tournament!";
        }
        else if (playerNum == 3)
        {
            player3.transform.position = new Vector3(winnerPodium.transform.position.x, winnerPodium.transform.position.y + 2.1f, winnerPodium.transform.position.z);
            player3.transform.rotation = Quaternion.Euler(0, 180, 0);
            bigMiddleText.text = "Player 3 Wins The Tournament!";
        }
        else if (playerNum == 4)
        {
            player4.transform.position = new Vector3(winnerPodium.transform.position.x, winnerPodium.transform.position.y + 2.1f, winnerPodium.transform.position.z);
            player4.transform.rotation = Quaternion.Euler(0, 180, 0);
            bigMiddleText.text = "Player 4 Wins The Tournament!";
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
