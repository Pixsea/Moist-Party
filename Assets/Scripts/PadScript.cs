using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    Collider m_ObjectCollider;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        //m_ObjectCollider = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        //m_ObjectCollider.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        //Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            manager.GetComponent<ParkourManager>().playerWins(collider.gameObject.GetComponent<PlayerController>().playerNum);
        }
    }



}
