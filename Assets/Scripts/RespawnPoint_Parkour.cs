using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint_Parkour : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOccupied = false;

    void onTriggerEnter(Collider other) {
        isOccupied = true;
    }
    void onTriggerStay(Collider other) {
        isOccupied = true;
    }

    void onTriggerExit(Collider other) {
        isOccupied = false;
    }

    public bool occupied() {
        return isOccupied;
    }
}
