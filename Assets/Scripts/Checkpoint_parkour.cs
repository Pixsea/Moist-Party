using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_parkour : MonoBehaviour
{
    public Transform getFreeSpawnPoint() {
        if (this.transform.GetChild(0).GetComponent<RespawnPoint_Parkour>().occupied() == false) {
            return this.transform.GetChild(0).GetComponent<Transform>().transform;
        }
        else if (this.transform.GetChild(1).GetComponent<RespawnPoint_Parkour>().occupied() == false) {
            return this.transform.GetChild(1).GetComponent<Transform>().transform;
        }
        else if (this.transform.GetChild(2).GetComponent<RespawnPoint_Parkour>().occupied() == false) {
            return this.transform.GetChild(2).GetComponent<Transform>().transform;
        }
        else {
            return this.transform.GetChild(3).GetComponent<Transform>().transform;
        }
    }
}
