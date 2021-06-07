using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeight : MonoBehaviour
{
    public bool rising;
    public bool stopShort;  // Used for the spring to stop short

    private float startHeight;

    // Start is called before the first frame update
    void Start()
    {
        startHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rising && !(stopShort && (gameObject.transform.position.y > (startHeight + 1))))
        {
            //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 1000, 0);
            gameObject.transform.Translate(Vector3.up * 100 * Time.deltaTime);
        }
    }

    public void Rise()
    {
        Debug.Log("temp");
        rising = true;
    }
}
