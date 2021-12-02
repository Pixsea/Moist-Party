using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRopeManager : MinigameManager
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
    private List<int> playersAlive;
    [SerializeField]
    private JumpRopeRotater rotater;

    [SerializeField]
    private float dropTimer;

    [SerializeField]
    private Transform[] platforms;
    private int platformIndex = 0;

    [SerializeField]
    private Material warningMaterial;



    // Update is called once per frame
    //private void Awake()
    //{
    //    GameObject temp = GameObject.FindGameObjectWithTag("Music");
    //    if (temp != null)
    //    {
    //        temp.GetComponent<BackGroundAudio>().StopMusic();
    //    }

    //    playersAlive = new List<int>();
    //    Debug.Log(numPlayers);

    //    for (int i = 1; i <= numPlayers; i++)
    //    {
    //        playersAlive.Add(i);
    //    }

    //    Debug.Log(playersAlive.Count);
    //}

    public override void Start()
    {
        // Since we decrease timer by 1 every FixedUpdate, set the timer to the TotalGameTime
        // divided by Time.fixedDeltaTime (a decimal of the delay between frames of FixedUpdateCalls)
        timer = dropTimer / Time.fixedDeltaTime;

        startWait = new WaitForSeconds(startWaitSec);
        resultsWait = new WaitForSeconds(resultsWaitSec);

        numPlayers = scoreTracker.GetComponent<ScoreTracker>().GetNumPlayers();

        GameObject temp = GameObject.FindGameObjectWithTag("Music");
        if (temp != null)
        {
            temp.GetComponent<BackGroundAudio>().StopMusic();
        }

        playersAlive = new List<int>();

        for (int i = 1; i <= numPlayers; i++)
        {
            playersAlive.Add(i);
        }

        phase = "Start";
        StartCoroutine(GameLoop());
    }



    //public override void FixedUpdate()
    //{
    //    //Debug.Log(timer);
    //    if (phase == "End")
    //    {
    //        timer--;
    //    }
    //    else if (phase == "Playing")
    //    {
    //        timer++;
    //    }
    //}




    public override IEnumerator GameLoop()
    {
        LockMovement();

        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());
        UnlockMovement();
        rotater.StartRotation();

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        LockMovement();
        rotater.StopRotation();

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }




    public override IEnumerator GamePlaying()
    {
        UIMainText.text = "GO!";
        phase = "Playing";

        // Small delay for start
        yield return new WaitForSeconds(1.5f);

        // remove "Go!" from UI
        UIMainText.text = "";

        while (!finished)
        {

            if ((timer) < (0))
            {
                //Debug.Log(platformIndex);
                //Debug.Log(platforms.Length);
                timer = dropTimer / Time.fixedDeltaTime;
                if (platformIndex < platforms.Length)
                {
                    //StartDropSurface(platforms[platformIndex]);
                    StartDropSurface(platforms[platformIndex]);
                }
                platformIndex += 1;
            }
            

            //timer++;
            yield return null;
        }
    }

    public void playerWins(int playerNum)
    {
        Debug.Log(playersAlive.Count);
        finished = true;
        winner = playerNum;
    }

    public void playerDies(int playerNum)
    {
        playersAlive.Remove(playerNum);
        //Debug.Log(playerNum);

        //Debug.Log(playersAlive.Count);

        if (playersAlive.Count == 1)
        {
            playerWins(playersAlive[0]);
        }
    }



    private void StartDropSurface(Transform surface)
    {
        StartCoroutine(DropSurface(surface));
        //surface.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
    }



    IEnumerator DropSurface(Transform surface)
    {
        //while (true)
        //{
        //    Debug.Log("TESt");
        //    surface.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
        //    yield return null;
        //}

        if (surface.childCount > 0)
        {
            for (int i = 0; i < surface.childCount; i++)
            {
                Debug.Log(surface.GetChild(i).name);
                surface.GetChild(i).GetComponent<MeshRenderer>().material = warningMaterial;
            }
        }
        else
        {
            Debug.Log(surface.gameObject.name);
            surface.GetComponent<MeshRenderer>().material = warningMaterial;
        }


        yield return new WaitForSeconds(3.0f);

        Destroy(surface.gameObject);
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
        //Debug.Log("test1");
        //Debug.Log(Players.Length);
        // Only c=change players if there are players to change
        if (Players.Length > 0)
        {
            //Debug.Log("test1");
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
