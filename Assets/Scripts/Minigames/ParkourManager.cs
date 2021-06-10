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
    private void Awake()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Music");
        if (temp != null)
        {
            temp.GetComponent<BackGroundAudio>().StopMusic();
        }
    }
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

    public override IEnumerator AdjustPlayers()
    {
        Debug.Log("test1");
        Debug.Log(Players.Length);
        // Only c=change players if there are players to change
        if (Players.Length > 0)
        {
            Debug.Log("test1");
            // Remove players who aren't palying from the arena
            if (numPlayers < 4)
            {
                Players[3].gameObject.transform.position -= new Vector3(0, 100, 0);
                //Players[3].gameObject.SetActive(false);
            }

            if (numPlayers < 3)
            {
                Debug.Log(Players[2].gameObject.name);
                Players[2].gameObject.transform.position -= new Vector3(0, 100, 0);
                //Players[2].gameObject.SetActive(false);
            }
        }

        yield return null;
    }
    
}
