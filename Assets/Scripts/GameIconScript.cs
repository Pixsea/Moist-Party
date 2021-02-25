using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIconScript : MonoBehaviour
{
    [SerializeField]
    private string sceneName; 

    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
