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

    // Update is called once per frame
    public override void Update()
    {
    }

    public override IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        
        yield return StartCoroutine(GameStarting());
        Debug.Log("CHICKEN STRIP");
        UIMainText.text = "ASDF";

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }



    public override IEnumerator GamePlaying()
    {

        while (!finished)
        {

        }

        yield return null;
    }

}
