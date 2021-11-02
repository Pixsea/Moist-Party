using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private SceneChangerInfo info;

    public string nextScene;

    [SerializeField]
    private bool isDirectionScreen = false;

    [SerializeField]
    private ScoreTracker scoreTracker;



    // Start is called before the first frame update
    void Start()
    {
        info = new SceneChangerInfo();
    }

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        
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
