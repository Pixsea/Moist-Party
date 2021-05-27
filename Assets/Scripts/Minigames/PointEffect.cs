using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEffect : MonoBehaviour
{

    public Text pointText;
    private float timer = 60f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        timer--;

        transform.position += new Vector3(0, .05f, 0);
    }
}
