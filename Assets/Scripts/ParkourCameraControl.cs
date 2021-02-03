using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourCameraControl : MonoBehaviour
{
    public Transform players;
    private Camera camera;

    private Vector3 newPosition;
    
    private void Awake()
    {
        camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        GetNewPosition();
        transform.position = newPosition;
    }

    private void GetNewPosition()
    {
        Vector3 testPosition = new Vector3();

        testPosition.y = transform.position.y;
        testPosition.x = transform.position.x;
        testPosition.z = players.position.z;
        newPosition = testPosition;
    }
}
