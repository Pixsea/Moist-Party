using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] Players;
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




    // Start is called before the first frame update
    public virtual void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = TotalGameTime / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        resultsWait = new WaitForSeconds(resultsWaitSec);

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
        if ((phase == "Playing" || phase == "End") && UsesTimer)
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

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return startWait;
    }



    public virtual IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

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
}
