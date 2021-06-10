using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float spin_speed = -150f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, spin_speed, 0f) * Time.deltaTime);
    }
}
