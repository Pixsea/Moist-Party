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
    private Text player1ReadyText;
    [SerializeField]
    private Text player2ReadyText;
    [SerializeField]
    private Text player3ReadyText;
    [SerializeField]
    private Text player4ReadyText;

    [SerializeField]
    private bool player1Ready;
    [SerializeField]
    private bool player2Ready;
    [SerializeField]
    private bool player3Ready;
    [SerializeField]
    private bool player4Ready;



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
        }

        player1Ready = false;
        player2Ready = false;
        player3Ready = false;
        player4Ready = false;
    }

    private void Update()
    {
        // Leave the screen, go to minigame
        if (Input.GetKeyDown("space"))
        {
            LeaveDirectionsScreen();
        }

        if (Input.GetKeyDown("w"))
        {
            player1Ready = !player1Ready;

            //if (player)
        }
        if (Input.GetKeyDown("a"))
        {
            player1Ready = !player1Ready;
        }
        if (Input.GetKeyDown("s"))
        {
            player1Ready = !player1Ready;
        }
        if (Input.GetKeyDown("d"))
        {
            player1Ready = !player1Ready;
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
}
