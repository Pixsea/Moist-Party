using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn_Parkour : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject checkpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Checkpoint") {
            Debug.Log("Checkpoint Set");
            checkpoint = other.gameObject;
        }
        if (other.tag == "OutOfBounds") {
            Debug.Log("Out of Bounds");
            Transform spawn = checkpoint.GetComponent<Checkpoint_parkour>().getFreeSpawnPoint();
            this.transform.position = spawn.transform.position;
        }
    }
}
