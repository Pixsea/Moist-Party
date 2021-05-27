using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dart : MonoBehaviour
{
    [SerializeField]
    private GameObject point;  // reference to point of needle
    public GameObject target;  // reference to target
    //public GameObject player;  // reference to player
    public int playerNum;
    public GameObject gameManager; // reference to GameManager

    public Renderer baseRenderer;  // Reference to the renderer of the dart base
    public Material P1Color;  // Player 1 color
    public Material P2Color;
    public Material P3Color;
    public Material P4Color;

    [SerializeField]
    private float speed;
    private bool stuck = false;  // Becomes true when it hits an object, cause it to stop

    private float timer = 100f;

    public GameObject pointText;  // prefab used to display points earned

    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.fixedDeltaTime;

        if (playerNum == 1)
        {
            baseRenderer.material = P1Color;
        }
        else if (playerNum == 2)
        {
            baseRenderer.material = P2Color;
        }
        else if (playerNum == 3)
        {
            baseRenderer.material = P3Color;
        }
        else if (playerNum == 4)
        {
            baseRenderer.material = P4Color;
        }
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

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        timer--;
    }

    void OnCollisionEnter(Collision obj)
    {
        transform.parent = obj.transform;
        Rigidbody myRigid = GetComponent<Rigidbody>();
        myRigid.isKinematic = true;

        Debug.Log(obj.gameObject.name);

        //Debug.Log(obj.gameObject.name);
        if (stuck == false)
        {
            stuck = true;
            GetScore();
        }
    }

    public void GetScore()
    {
        float distance = Vector3.Distance(point.gameObject.transform.position, target.gameObject.transform.position);
        //Debug.Log(distance);
        //Debug.Log((2.5f - distance) / 2.5);

        // Distance rANGES FOR EACH RING
        // 0 - .33 - .75 - 1.2 - 1.67

        GameObject pointEffect = Instantiate(pointText, new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z - 1), Quaternion.Euler(0, 0, 0));
        Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
        if (playerNum == 1)
        {
            textEdit.color = Color.red;
            pointEffect.transform.position += new Vector3(-1.5f, 0, 0);
        }
        if (playerNum == 2)
        {
            textEdit.color = Color.blue;
            pointEffect.transform.position += new Vector3(-.5f, 0, 0);
        }
        if (playerNum == 3)
        {
            textEdit.color = Color.yellow;
            pointEffect.transform.position += new Vector3(.5f, 0, 0);
        }
        if (playerNum == 4)
        {
            textEdit.color = Color.green;
            pointEffect.transform.position += new Vector3(1.5f, 0, 0);
        }


        if (distance < .33f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 5);
            textEdit.text = "+5";
        }
        else if (distance < .75f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 4);
            textEdit.text = "+4";
        }
        else if (distance < 1.2f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 3);
            textEdit.text = "+3";
        }
        else if (distance < 1.67f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 2);
            textEdit.text = "+2";
        }
        else if (distance < 2.5f)
        {
            gameManager.GetComponent<DartofGold>().IncreaseScore(playerNum, 1);
            textEdit.text = "+1";
        }
    }
}
