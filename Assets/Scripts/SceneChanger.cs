using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [HideInInspector]
    public SceneChangerInfo info;

    public string nextScene;

    [SerializeField]
    private ScoreTracker scoreTracker;


    //  Direction scene things
    [SerializeField]
    private bool isDirectionScreen = false;

    [SerializeField]
    private RawImage directionImage;

    [SerializeField]
    private Texture mashHappyDirections;
    [SerializeField]
    private Texture simonSaysDirections;
    [SerializeField]
    private Texture dartofGoldDirections;
    [SerializeField]
    private Texture glowRunDirections;
    [SerializeField]
    private Texture parkourDirections;
    [SerializeField]
    private Texture jumpRopeDirections;


    [SerializeField]
    private Text player1ReadyText;
    [SerializeField]
    private Text player2ReadyText;
    [SerializeField]
    private Text player3ReadyText;
    [SerializeField]
    private Text player4ReadyText;

    private int[] playersReady = { -1, -1, -1, -1 };
    private Text[] playerReadytext = { null, null, null, null };



    // Start is called before the first frame update
    void Start()
    {
        info = new SceneChangerInfo();
    }

    private void OnEnable()
    {
        nextScene = SceneChangerInfo.nextScene;

        if (directionImage != null)
        {
            if (nextScene == "MashHappy")
            {
                directionImage.texture = mashHappyDirections;
            }
            else if (nextScene == "SimonSays")
            {
                directionImage.texture = simonSaysDirections;
            }
            else if (nextScene == "DartofGold")
            {
                directionImage.texture = dartofGoldDirections;
            }
            else if (nextScene == "SampleScene")
            {
                directionImage.texture = glowRunDirections;
            }
            else if (nextScene == "ParkourScene")
            {
                directionImage.texture = parkourDirections;
            }
            else if (nextScene == "JumpRope")
            {
                directionImage.texture = jumpRopeDirections;
            }



            // Add player ready texts to the player ready texts array
            playerReadytext[0] = player1ReadyText;
            playerReadytext[1] = player2ReadyText;
            playerReadytext[2] = player3ReadyText;
            playerReadytext[3] = player4ReadyText;

            // Set the players to not ready, represented by 0
            playersReady[0] = 0;
            playersReady[1] = 0;
            if (SceneChangerInfo.numPlayers >= 3)
            {
                playersReady[2] = 0;
            }
            if (SceneChangerInfo.numPlayers == 4)
            {
                playersReady[3] = 0;
            }

            // Change the text/disable the ready texts for ach player
            for (int i = 0; i < playersReady.Length; i++)
            {
                if (playersReady[i] == 0)
                {
                    playerReadytext[i].text = "Not Ready";
                }
                else if (playersReady[i] == 1)
                {
                    playerReadytext[i].text = "Ready";
                }
                else if (playersReady[i] == -1)
                {
                    playerReadytext[i].gameObject.SetActive(false);
                }

            }
        }
    }

    private void Update()
    {
        if (isDirectionScreen)
        {
            // Leave the screen, go to minigame
            if (Input.GetKeyDown("space"))
            {
                LeaveDirectionsScreen();
            }

            if (Input.GetKeyDown("w"))
            {
                ReadyUpPlayer(1);
            }
            if (Input.GetKeyDown("a"))
            {
                ReadyUpPlayer(2);
            }
            if (Input.GetKeyDown("s"))
            {
                ReadyUpPlayer(3);
            }
            if (Input.GetKeyDown("d"))
            {
                ReadyUpPlayer(4);
            }
        }
    }

    // Doesn't actually go to the minigame, goes to the directions screen
    public void LoadMiniGame(string sceneName)
    {
        SceneChangerInfo.nextScene = sceneName;
        SceneManager.LoadScene("DirectionsScreen");
    }

    public void LeaveDirectionsScreen()
    {
        SceneManager.LoadScene(SceneChangerInfo.nextScene);
    }


    //  Set how many people are num playing
    public void SetNumPlayers(int numPlayers)
    {
        SceneChangerInfo.numPlayers = numPlayers;
    }


    public void ReadyUpPlayer(int playerNum)
    {
        playersReady[playerNum - 1] = 1;
        playerReadytext[playerNum - 1].text = "Ready";

        bool allReady = true;
        // Check to see if everyone is readied up, 0 is not ready, 1 is ready, -1 is not a player
        for (int i = 0; i < playersReady.Length; i+=1)
        {
            if (playersReady[i] == 0)
            {
                allReady = false;
            }
        }

        if (allReady)
        {
            LeaveDirectionsScreen();
        }
    }
}
