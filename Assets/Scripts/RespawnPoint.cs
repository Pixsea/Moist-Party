using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject player in ControllerManager.instance.players)
        {
            UpdatedPlayerController pc = player.GetComponentInChildren<UpdatedPlayerController>();
            pc.respawnPoint = transform;
            
            pc.transform.position = transform.position;
            print($"Set {pc.gameObject.name} pos to {pc.transform.position}");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
