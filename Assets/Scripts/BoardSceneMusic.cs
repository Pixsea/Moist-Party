using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSceneMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
   {
    GameObject.FindGameObjectWithTag("Music").GetComponent<BackGroundAudio>().PlayMusic();       
   } 
}
