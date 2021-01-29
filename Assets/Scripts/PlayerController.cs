using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_playerSpeed = 10.0f;
    public float m_jumpHeight = 3.0f;
    public float m_gravityValue = -9.81f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void Start()
    {
        // for movement 
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // stop rotating randomly
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // update y velocity when player touches ground
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // move player along x and z axis
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * m_playerSpeed);

        // if player is moving, make them move
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            // initial vertical velocity calculation
            playerVelocity.y += Mathf.Sqrt(- m_jumpHeight * m_gravityValue);
        }

        // drag player down with gravity
        playerVelocity.y += m_gravityValue * Time.deltaTime;

        // move player with their velocity
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("SOME TRIGGER");
        if (collider.gameObject.tag == "Pad")
        {
            //Destroy(collider.gameObject);
            Debug.Log("PAD TRIGGER");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("SOME COLLISION");
        if (collision.gameObject.tag == "Pad")
        {
            // Destroy(GetComponent<Collider>().gameObject);
            Debug.Log("PAD COLLISION");
        }
    }
}
