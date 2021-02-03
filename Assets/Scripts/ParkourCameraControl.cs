using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourCameraControl : MonoBehaviour
{
    public Transform[] players;
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
        Vector3 minPosition = new Vector3(transform.position.x, transform.position.y, players[0].position.z);

        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].gameObject.activeSelf)
                continue;
            
            if (players[i].position.z <= minPosition.z)
            {
                minPosition.z = players[i].position.z;
            }
        }
        newPosition = minPosition;
    }
}
