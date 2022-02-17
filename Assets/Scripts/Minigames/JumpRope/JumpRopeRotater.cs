using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRopeRotater : MonoBehaviour
{
    [SerializeField]
    private float startSpeed = 100f;

    [HideInInspector]
    public float rotationSpeed = 0;

    [SerializeField]
    private float growthRate;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0, rotationSpeed) * Time.fixedDeltaTime);

        // Increase speed as long as its not zero, oprevent it from gaining speed when stopped
        if (rotationSpeed != 0)
        {
            rotationSpeed -= growthRate;
        }
    }



    public void StartRotation()
    {
        rotationSpeed = startSpeed;
    }



    public void StopRotation()
    {
        rotationSpeed = 0;
    }
}
