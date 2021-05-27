using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParkourManager : MinigameManager
{
    // public Text UIMainText;  // Reference to the UI Text to display winning text, etc.
    // public Text UITimerText;  // Reference to the UI Text to display the timer


    // Start is called before the first frame update
    // void Start()
    // {
    //     phase = "Start";
    //     StartCoroutine(GameLoop());
    // }

    public bool finished = false;
    public int winner;

    // Update is called once per frame
    public override void Update()
    {
    }

    public override IEnumerator GameLoop()
    {
        LockMovement();

        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());
        UnlockMovement();

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        LockMovement();

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }


    public override IEnumerator GamePlaying()
    {
        UIMainText.text = "GO!";

        // Small delay for start
        yield return new WaitForSeconds(1.5f);

        // remove "Go!" from UI
        UIMainText.text = "";

        while (!finished)
        {
            yield return null;
        }


    }

    public void playerWins(int playerNum)
    {
        finished = true;
        winner = playerNum;
    }

    public override IEnumerator ShowResults()
    {
        UIMainText.text = "Player " + winner.ToString() + " Wins!";

        // Increase the winner's score
        scoreTracker.GetComponent<ScoreTracker>().IncreaseScore(winner);

        yield return resultsWait;
    }
}
