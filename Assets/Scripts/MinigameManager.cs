using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject[] Players;
    private string phase;  // Current phase
    private bool gameEnded = false;  // Is false while the game is running, can be turned true by calling EndGame
    public Text UIMainText;  // Reference to the UI Text to display winning text, etc.
    public Text UITimerText;  // Reference to the UI Text to display the timer


    [SerializeField]
    private bool UsesTimer = true; // Whether the game uses a timer
    [SerializeField]
    private int TotalGameTime;  // the start time in seconds for the minigame
    private float timer;  // Current timer for game in seconds

    [SerializeField]
    private float startWaitSec;  // How long the start of game phase lasts before it control is given
    [SerializeField]
    private float endWaitSec;  // How long the end of game phase lasts before it scene is switched

    private WaitForSeconds startWait;  // Used to have a delay whilst the round starts.
    private WaitForSeconds endWait;  // Used for delay on round end




    // Start is called before the first frame update
    void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = TotalGameTime / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        endWait = new WaitForSeconds(endWaitSec);

        phase = "Start";
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Debug.Log(timer);
        if (phase == "Playing")
        {
            timer--;
        }
    }

    void Startgame()
    {

    }

    void EndGame()
    {
        gameEnded = true;
    }

    private IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        UIMainText.text = "";
    }

    private IEnumerator GameStarting()
    {
        UIMainText.text = "Ready?";
        UITimerText.text = "";

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return startWait;
    }

    private IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

        // While the game hasn't ended and while the timer is greater than 0
        while(!gameEnded && (timer > 0))
        {
            // If more than 1.5 seconds has past, remove "GO!" from the UI
            if (((TotalGameTime / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            UITimerText.text = (Mathf.Ceil(timer * Time.fixedDeltaTime)).ToString();

            // ... return on the next frame.
            yield return null;
        }
    }


    private IEnumerator GameEnding()
    {
        phase = "End";
        UIMainText.text = "Finish";

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return endWait;
    }
}
