using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotation_speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -rotation_speed) * Time.deltaTime);
    }
}
