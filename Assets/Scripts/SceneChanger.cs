using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private SceneChangerInfo info;

    private string nextScene;

    [SerializeField]
    private bool isDirectionScreen = false;

    [SerializeField]
    private ScoreTracker scoreTracker;

    [SerializeField]
    private RawImage directionImage;

    [SerializeField]
    private Texture mashHappyDirections;


    [SerializeField]
    private Text player1Ready;
    [SerializeField]
    private Text player2Ready;
    [SerializeField]
    private Text player3Ready;
    [SerializeField]
    private Text player4Ready;



    // Start is called before the first frame update
    void Start()
    {
        info = new SceneChangerInfo();
    }

    private void OnEnable()
    {
        if (isDirectionScreen)
        {
            if (directionImage != null)
            {
                if (SceneChangerInfo.nextScene == "MashHappy")
                {
                    directionImage.texture = mashHappyDirections;
                }
            }

            Debug.Log(SceneChangerInfo.numPlayers);
        }
    }

    private void Update()
    {
        if (isDirectionScreen)
        {
            if (Input.GetKeyDown("space"))
            {
                LeaveDirectionsScreen();
            }
        }
    }

    // Doesn't actually go to the minigame, goes to the directions screen
    public void LoadMiniGame(string sceneName)
    {
        SceneChangerInfo.nextScene = sceneName;
        SceneManager.LoadScene("DirectionsScreen");
    }

    private void LeaveDirectionsScreen()
    {
        SceneManager.LoadScene(SceneChangerInfo.nextScene);
    }


    //  Set how many people are num playing
    public void SetNumPlayers(int numPlayers)
    {
        SceneChangerInfo.numPlayers = numPlayers;
    }
}
