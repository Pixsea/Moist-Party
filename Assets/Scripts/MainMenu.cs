using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    // When "PLAY" is selected, load the next scene in the queue
    // The next scene comes from the "Build Settings" window in the editor
    public void PlayGame()
    {
        //SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
        //SceneManager.LoadScene("OptionsScene", LoadSceneMode.Single);
        SceneManager.LoadScene("BetterOptions", LoadSceneMode.Single);
    }

    // Quits game when "QUIT" is selected
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
