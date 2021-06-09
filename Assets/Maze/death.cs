using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    Vector3 startPos;

    private void Awake()
    {
        startPos = this.transform.position;
    }

    //void OnCollisionEnter(Collision other)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("spike"))
        {
            Respawn();
        }
            
    }
    
    void Respawn()
    {
        this.transform.position = startPos;
    }

}
