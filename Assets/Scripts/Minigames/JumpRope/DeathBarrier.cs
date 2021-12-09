using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public JumpRopeManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.playerDies(collision.gameObject.GetComponent<PlayerController2>().playerNum);
            collision.gameObject.transform.position -= new Vector3(0, 1000, 0);
        }
    }
}
