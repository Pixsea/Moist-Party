using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public bool startOn = false;
    private bool lit;

    private float timer;
    public float interval;
    private float overideInterval = .5f; // Will overite the existing interval so I don't have to change each idnividual script

    public Material onMaterial;
    public Material offMaterial;

    // Start is called before the first frame update
    void Start()
    {
        interval = overideInterval;
        interval = interval / Time.fixedDeltaTime;
        timer = interval;

        if (startOn)
        {
            lit = true;
            gameObject.GetComponent<MeshRenderer>().material = onMaterial;
        }
        else
        {
            lit = false;
            gameObject.GetComponent<MeshRenderer>().material = offMaterial;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
            if (lit)
            {
                lit = false;
                gameObject.GetComponent<MeshRenderer>().material = offMaterial;
            }
            else
            {
                lit = true;
                gameObject.GetComponent<MeshRenderer>().material = onMaterial;
            }

            timer = interval;
        }

        timer--;
    }
}
