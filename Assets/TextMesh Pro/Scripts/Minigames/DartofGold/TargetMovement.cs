using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public GameObject gameManager;

    
    private float speed = 0;  // Current speed
    private float speedGrowth = .03f;  // how much speed changes
    private string direction = "right";  // Direction of target currently
    private float range = 1f;  // How far in the X direction it goes

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();

        if (gameManager.GetComponent<DartofGold>().playing)
        {
            if (direction == "right")
            {
                speed += speedGrowth;
            }
            else
            {
                speed -= speedGrowth;
            }

            // Switch directions
            if (transform.position.x > range)
            {
                direction = "left";
            }
            else if (transform.position.x < -range)
            {
                direction = "right";
            }

            range += .001f;
            speedGrowth += .0001f;
            myRigid.velocity = transform.right * speed;
            //myRigid.AddForce(transform.right * speed);
        }
    }
}
