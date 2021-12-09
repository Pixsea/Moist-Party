using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float rightLimit = 15.0f;
    public float leftLimit = -15.0f;
    public float speed = 2.0f;
    private int direction = 1;
    private Vector3 movement;
    public bool oppositeDirection = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (oppositeDirection)
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightLimit) {
            direction = -1;
        }
        else if (transform.position.x < leftLimit) {
            direction = 1;
        }

        movement = Vector3.right * direction * speed * Time.deltaTime; 
        transform.Translate(movement); 
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("COLLISION DETECTED");
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
