using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField]
    private GameObject point;  // reference to point of needle
    public GameObject target;  // reference to target
    //public GameObject player;  // reference to player
    public int playerNum;
    public GameObject gameManager; // reference to GameManager

    [SerializeField]
    private float speed;
    private bool stuck = false;  // Becomes true when it hits an object, cause it to stop

    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.fixedDeltaTime;


    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Rigidbody myRigid = GetComponent<Rigidbody>();

        if (stuck == false)
        {
            myRigid.velocity = transform.up * speed;
        }

        else
        {
            myRigid.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision obj)
    {
        stuck = true;
        //Debug.Log(obj.gameObject.name);
        GetScore();
    }

    public void GetScore()
    {
        float distance = Vector3.Distance(point.gameObject.transform.position, target.gameObject.transform.position);
        //Debug.Log(distance);
        //Debug.Log((2.5f - distance) / 2.5);

        // Distance rANGES FOR EACH RING
        // 0 - .33 - .75 - 1.2 - 1.67

        if (distance < .33f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 5);
        }
        else if (distance < .75f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 4);
        }
        else if (distance < 1.2f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 3);
        }
        else if (distance < 1.67f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 2);
        }
        else if (distance < 2.5f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 1);
        }
    }
}
