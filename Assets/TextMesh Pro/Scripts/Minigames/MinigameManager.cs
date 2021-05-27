using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] Players;
    [HideInInspector]
    public int numPlayers;  // How many players are currently playing
    [HideInInspector]
    public string phase;  // Current phase
    [HideInInspector]
    public bool gameEnded = false;  // Is false while the game is running, can be turned true by calling EndGame
    public Text UIMainText;  // Reference to the UI Text to display winning text, etc.
    public Text UITimerText;  // Reference to the UI Text to display the timer


    [SerializeField]
    public bool UsesTimer = true; // Whether the game uses a timer
    [SerializeField]
    public int TotalGameTime;  // the start time in seconds for the minigame
    [HideInInspector]
    public float timer;  // Current timer for game in seconds

    [SerializeField]
    public float startWaitSec;  // How long the start of game phase lasts before it control is given
    [SerializeField]
    public float endWaitSec;  // How long the end of game phase lasts before it scene is switched
    [SerializeField]
    public float resultsWaitSec;  // How long the end of game phase lasts before it scene is switched

    [HideInInspector]
    public WaitForSeconds startWait;  // Used to have a delay whilst the round starts.
    [HideInInspector]
    public WaitForSeconds resultsWait;  // Used for delay when results how

    public GameObject scoreTracker;  // Reference to Scoretracker object




    // Start is called before the first frame update
    public virtual void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = TotalGameTime / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        resultsWait = new WaitForSeconds(resultsWaitSec);

        numPlayers = scoreTracker.GetComponent<ScoreTracker>().GetNumPlayers();
        //Debug.Log(numPlayers);

        phase = "Start";
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    public virtual void Update()
    {
    }



    public virtual void FixedUpdate()
    {
        //Debug.Log(timer);
        if (phase == "Playing" || phase == "End")
        {
            timer--;
        }
    }



    public virtual void EndGame()
    {
        gameEnded = true;
    }



    public virtual IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());
    }



    public virtual IEnumerator GameStarting()
    {
        UIMainText.text = "Ready?";
        UITimerText.text = "";

        LockMovement();

        // Adjust non used players
        yield return StartCoroutine(AdjustPlayers());

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return startWait;
    }



    // Called to move, disable, or delete players that aren't used, might have to be adjusted per minigame
    public virtual IEnumerator AdjustPlayers()
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
                //Players[3].gameObject.transform.position -= new Vector3(0, 100, 0);
                Players[3].gameObject.SetActive(false);
            }

            if (numPlayers < 3)
            {
                Debug.Log(Players[2].gameObject.name);
                //Players[2].gameObject.transform.position -= new Vector3(0, 100, 0);
                Players[2].gameObject.SetActive(false);
            }
        }

        yield return null;
    }



    public virtual IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

        UnlockMovement();

        timer = TotalGameTime / Time.fixedDeltaTime;

        // While the game hasn't ended and while the timer is greater than 0
        while (!gameEnded && (timer > 0))
        {
            // If more than 1.5 seconds has past, remove "GO!" from the UI
            if (((TotalGameTime / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            if (UsesTimer)
            {
                UITimerText.text = (Mathf.Ceil(timer * Time.fixedDeltaTime)).ToString();
            }

            // ... return on the next frame.
            yield return null;
        }
    }



    public virtual IEnumerator GameEnding()
    {
        phase = "End";
        UIMainText.text = "Finish";
        UITimerText.text = "";

        LockMovement();

        timer = endWaitSec / Time.fixedDeltaTime;

        while(timer > 0)
        {
            // If more than 1.5 seconds has past, remove "Finish!" from the UI
            if (((endWaitSec / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            yield return null;
        }
    }



    public virtual IEnumerator ShowResults()
    {
        UIMainText.text = "Someone won hopefully";
        yield return resultsWait;
    }

    public virtual IEnumerator ReturnToBoard()
    {
        SceneManager.LoadScene("BoardScene");
        yield return null;
    }



    // Locks all player movement
    public void LockMovement()
    {
        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].gameObject.GetComponent<PlayerController>().lockMovement = true;
        }
    }

    // Unlocks all player movement
    public void UnlockMovement()
    {
        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            Players[i].gameObject.GetComponent <PlayerController> ().lockMovement = false;
        }
    }
}
