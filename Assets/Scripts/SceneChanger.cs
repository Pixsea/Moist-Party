using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private SceneChangerInfo info;

    private string nextScene;

    public bool isDirectionScreen = false;



    // Start is called before the first frame update
    void Start()
    {
        info = new SceneChangerInfo();
    }

    private void OnEnable()
    {
        if (isDirectionScreen)
        {

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
        Debug.Log(SceneChangerInfo.nextScene);
        SceneManager.LoadScene("DirectionsScreen");
    }

    private void LeaveDirectionsScreen()
    {
        SceneManager.LoadScene(SceneChangerInfo.nextScene);
    }
}
