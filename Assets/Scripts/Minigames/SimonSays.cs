using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimonSays : MinigameManager
{
    [SerializeField]
    private string player1Button;  // Button for player 1 to mash
    [SerializeField]
    private string player2Button;
    [SerializeField]
    private string player3Button;
    [SerializeField]
    private string player4Button;

    private Dictionary<int, bool> playerDict;  // List of player by number that can remove them as they do the wrong input,
                                                        //boolian value represents if the player has inputted the correct input in time




    public override void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = TotalGameTime / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        resultsWait = new WaitForSeconds(resultsWaitSec);

        phase = "Start";

        playerDict = new Dictionary<int, bool>();

        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            playerDict.Add(i+1, false);
        }

        StartCoroutine(GameLoop());
    }



    public override void Update()
    {
        if (phase == "Playing")
        {
            if (Input.GetKeyDown(player1Button) && (Players.Length >= 1))
            {
                PlayerInput(1, "up");
            }

            if (Input.GetKeyDown(player2Button) && (Players.Length >= 2))
            {
                PlayerInput(2, "up");
            }

            if (Input.GetKeyDown(player3Button) && (Players.Length >= 3))
            {
                PlayerInput(3, "up");
            }

            if (Input.GetKeyDown(player4Button) && (Players.Length >= 4))
            {
                PlayerInput(4, "up");
            }
        }
    }



    public void PlayerInput(int playerNum, string input)
    {
        Debug.Log("Player " + playerNum.ToString() + " Loses");
        playerDict.Remove(playerNum);
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



    public override IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

        LockMovement();

        timer = TotalGameTime / Time.fixedDeltaTime;

        // While the game hasn't ended and while the timer is greater than 0
        while (playerDict.Count > 1)
        {
            // If more than 1.5 seconds has past, remove "GO!" from the UI
            if (((TotalGameTime / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            // ... return on the next frame.
            yield return null;
        }
    }



    public override IEnumerator ShowResults()
    {
        foreach (KeyValuePair<int, bool> kvp in playerDict)
        {
            UIMainText.text = "Player " + kvp.Key.ToString() + " Wins!";
        }
            //UIMainText.text = "Player " + playerDict.Keys[0].ToString() + " Wins!";

        yield return resultsWait;
    }
}
