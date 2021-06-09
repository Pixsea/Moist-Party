using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimonSays : MinigameManager
{
    [SerializeField]
    private string player1Up;  // player 1 input buttons
    [SerializeField]
    private string player1Left;
    [SerializeField]
    private string player1Down;
    [SerializeField]
    private string player1Right;

    [SerializeField]
    private string player2Up;  // player 2 input buttons
    [SerializeField]
    private string player2Left;
    [SerializeField]
    private string player2Down;
    [SerializeField]
    private string player2Right;

    [SerializeField]
    private string player3Up;  // player 3 input buttons
    [SerializeField]
    private string player3Left;
    [SerializeField]
    private string player3Down;
    [SerializeField]
    private string player3Right;

    [SerializeField]
    private string player4Up;  // player 4 input buttons
    [SerializeField]
    private string player4Left;
    [SerializeField]
    private string player4Down;
    [SerializeField]
    private string player4Right;


    private Dictionary<int, bool> playerDict;  // List of player by number that can remove them as they do the wrong input,
                                               //boolian value represents if the player has inputted the correct input in time

    //private bool inputValid;  // Whether a player input is valid at this time
    private string correctInput;  //  The correct input to hit, can be "up", "down", "left", "right"

    private float inputWindow;  //  How long the player ahs to input the correct input in seconds
    private float delayWindow;  //  Delay in seconds between input windows
    [SerializeField]
    private float inputWindowStart;  //  Start amount
    [SerializeField]
    private float delayWindowStart;  //  Start amount

    public Text ScreenText;  // Text to show the the correct inputs

    [SerializeField]
    private GameObject player1;  // Used to get the players position
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;
    [SerializeField]
    private GameObject player4;


    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<BackGroundAudio>().StopMusic();       
    } 

    public override void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = TotalGameTime / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        resultsWait = new WaitForSeconds(resultsWaitSec);

        phase = "Start";

        playerDict = new Dictionary<int, bool>();
        //inputValid = false;
        correctInput = "";
        inputWindow = inputWindowStart;
        delayWindow = delayWindowStart;

        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            playerDict.Add(i+1, false);
            playerDict[i+1] = false;
        }

        numPlayers = scoreTracker.GetComponent<ScoreTracker>().GetNumPlayers();
        Debug.Log(numPlayers);

        StartCoroutine(GameLoop());
    }



    public override void Update()
    {
        if (phase == "Playing")
        {
            if (Input.GetKeyDown(player1Up) && (Players.Length >= 1))
            {
                player1.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(1, "up");
            }
            else if (Input.GetKeyDown(player1Down) && (Players.Length >= 1))
            {
                player1.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(1, "down");
            }
            else if (Input.GetKeyDown(player1Left) && (Players.Length >= 1))
            {
                player1.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(1, "left");
            }
            else if (Input.GetKeyDown(player1Right) && (Players.Length >= 1))
            {
                player1.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(1, "right");
            }


            if (Input.GetKeyDown(player2Up) && (Players.Length >= 2))
            {
                player2.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(2, "up");
            }
            else if (Input.GetKeyDown(player2Down) && (Players.Length >= 2))
            {
                player2.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(2, "down");
            }
            else if (Input.GetKeyDown(player2Left) && (Players.Length >= 2))
            {
                player2.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(2, "left");
            }
            else if (Input.GetKeyDown(player2Right) && (Players.Length >= 2))
            {
                player2.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(2, "right");
            }


            if (Input.GetKeyDown(player3Up) && (Players.Length >= 3))
            {
                player3.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(3, "up");
            }
            else if (Input.GetKeyDown(player3Down) && (Players.Length >= 3))
            {
                player3.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(3, "down");
            }
            else if (Input.GetKeyDown(player3Left) && (Players.Length >= 3))
            {
                player3.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(3, "left");
            }
            else if (Input.GetKeyDown(player3Right) && (Players.Length >= 3))
            {
                player3.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(3, "right");
            }


            if (Input.GetKeyDown(player4Up) && (Players.Length >= 4))
            {
                player4.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(4, "up");
            }
            else if (Input.GetKeyDown(player4Down) && (Players.Length >= 4))
            {
                player4.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(4, "down");
            }
            else if (Input.GetKeyDown(player4Left) && (Players.Length >= 4))
            {
                player4.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(4, "left");
            }
            else if (Input.GetKeyDown(player4Right) && (Players.Length >= 4))
            {
                player4.GetComponent<Animator>().SetTrigger("Punch");
                PlayerInput(4, "right");
            }
        }
    }



    public void PlayerInput(int playerNum, string input)
    {
        if (input != correctInput)
        {
            //Debug.Log("Player " + playerNum.ToString() + " Loses");
            playerDict.Remove(playerNum);
            //Destroy(GameObject.Find("Player" + playerNum.ToString()));
            //GameObject.Find("Player" + playerNum.ToString()).GetComponent<Rigidbody>().velocity = new Vector3(0, 1000, 0);
            //GameObject.Find("Player" + playerNum.ToString()).GetComponent<Rigidbody>().AddForce(transform.up * 100);
            GameObject.Find("Player" + playerNum.ToString()).GetComponent<IncreaseHeight>().Rise();
            GameObject.Find("Spring " + playerNum.ToString()).GetComponent<IncreaseHeight>().Rise();

        }

        else
        {
            // Record that the player hit he right input
            playerDict[playerNum] = true;
        }
    }



    public override IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }



    public override IEnumerator AdjustPlayers()
    {
        // Remove players who aren't palying from the arena
        if (numPlayers < 4)
        {
            Players[3].gameObject.transform.position -= new Vector3(0, 100, 0);
        }

        if (numPlayers < 3)
        {
            Players[2].gameObject.transform.position -= new Vector3(0, 100, 0);
        }

        yield return null;
    }



    public override IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

        LockMovement();

        // Small delay for start
        yield return new WaitForSeconds(1.5f);

        // remove "Go!" from UI
        UIMainText.text = "";


        // While the more than 1 player is alive
        while (playerDict.Count > 1)
        {
            //Debug.Log(playerDict.Count);

            //  Delay between inputs
            ScreenText.text = "";
            yield return new WaitForSeconds(delayWindow);


            // Choose input randomly
            int temp = Random.Range(0, 4);

            if (temp < 1)
            {
                correctInput = "up";
            }
            else if (temp >= 1 && temp < 2)
            {
                correctInput = "down";
            }
            else if (temp >= 2 && temp < 3)
            {
                correctInput = "left";
            }
            else if (temp >= 3 && temp < 4)
            {
                correctInput = "right";
            }
            else
            {
                Debug.Log(temp);
            }
            ScreenText.text = correctInput;


            // Input window
            yield return new WaitForSeconds(inputWindow);

            delayWindow *= .95f;
            inputWindow *= .95f;


            //  if a player didn't hit the correct input, kill them

            List<int> toRemove = new List<int>(); // Temp list of players to kill

            foreach (KeyValuePair<int, bool> kvp in playerDict)
            {
                if (kvp.Value == false)
                {
                    // Add numbers of players to kill to temp list
                    toRemove.Add(kvp.Key);
                }
            }


            foreach (int playerNum in toRemove)
            {
                playerDict.Remove(playerNum);
                //GameObject.Find("Player" + playerNum.ToString()).GetComponent<Rigidbody>().velocity = new Vector3(0, 1000, 0);
                //GameObject.Find("Player" + playerNum.ToString()).GetComponent<Rigidbody>().AddForce(transform.up * 100);
                //Destroy(GameObject.Find("Player" + playerNum.ToString()));
                GameObject.Find("Player" + playerNum.ToString()).GetComponent<IncreaseHeight>().Rise();
                GameObject.Find("Spring " + playerNum.ToString()).GetComponent<IncreaseHeight>().Rise();
            }

            toRemove.Clear();


            // Set all players back to false

            List<int> toChange = new List<int>(); // Temp list of players change
            
            // get numbers of all living players
            foreach (KeyValuePair<int, bool> kvp in playerDict)
            {
                toChange.Add(kvp.Key);
            }

            // Change them
            foreach (int playerNum in toChange)
            {
                playerDict[playerNum] = false;
            }





            // ... return on the next frame.
            yield return null;
        }
    }



    public override IEnumerator GameEnding()
    {
        phase = "End";
        UIMainText.text = "Finish";
        UITimerText.text = "";

        timer = endWaitSec / Time.fixedDeltaTime;

        while (timer > 0)
        {
            // If more than 1.5 seconds has past, remove "Finish!" from the UI
            if (((endWaitSec / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            yield return null;
        }
    }



    public override IEnumerator ShowResults()
    {
        ScreenText.text = ":>";

        if (playerDict.Count == 0)
        {
            ScreenText.text = ":<";
            UIMainText.text = "TIE";
        }

        else
        {
            ScreenText.text = ":>";

            // Get the last remaining player's number
            foreach (KeyValuePair<int, bool> kvp in playerDict)
            {
                UIMainText.text = "Player " + kvp.Key.ToString() + " Wins!";

                // Increase the winner's score
                scoreTracker.GetComponent<ScoreTracker>().IncreaseScore(kvp.Key);
            }
        }

        
        yield return resultsWait;
    }
}
