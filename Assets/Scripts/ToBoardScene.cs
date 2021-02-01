using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//this script will be called by the minigames after they have ended to load back to board room


//things to consider: 
// getting player info to save between scenes (i.e. minigames won) 

public class ToBoardScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("BoardScene"); //loads the scene to the index given 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
