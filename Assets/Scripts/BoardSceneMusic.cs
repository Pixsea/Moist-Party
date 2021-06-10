using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSceneMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
   {
        GameObject temp = GameObject.FindGameObjectWithTag("Music");
        if (temp != null)
        {
            temp.GetComponent<BackGroundAudio>().PlayMusic();
        }       
   } 
}
