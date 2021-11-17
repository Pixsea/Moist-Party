using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdatedPlayerController : MonoBehaviour
{
    public float m_playerSpeed = 10.0f;
    public float jumpForce = 25f;
    public Transform respawnPoint;

    public LayerMask groundLayers;

    [HideInInspector]
    public bool lockMovement = false;  //Whether the player's movement should be able to move
    public bool keepMovementLocked = false;  // Whether the movement should always be locked

    private CharacterController controller;
    private Rigidbody rigidbody;
    private Animator animator; 
    private CapsuleCollider collider;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float verticalSpeed;
    private bool m_isGrounded;
    private bool isJumping = false;
    private bool m_canJump = true;
    public Vector2 lastDir;

    private void Start()
    {
        // for movement 
        rigidbody = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); 
        collider = gameObject.GetComponent<CapsuleCollider>();
    }

    public void PlayerMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        lastDir = dir;
        if (context.phase == InputActionPhase.Canceled)
        {
            lastDir = Vector2.zero;
        }

        //print($"Set lastDir to {lastDir}");
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started)
            return;
        if (gameObject && gameObject.activeInHierarchy == false)
            return;
        isJumping = true;
        m_isGrounded = false;
        if (rigidbody == null || rigidbody != GetComponent<Rigidbody>())
        {
            Start();
        }
        print($"Jumped {(Vector3.up * jumpForce)}! velocity is now {rigidbody.velocity}");
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        print($"Jumped {(Vector3.up * jumpForce)}! velocity is now {rigidbody.velocity}");
    }

    private void Update()
    {
        Move(lastDir);
    }


    private void Move(Vector2 dir)
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!lockMovement && !keepMovementLocked) {
            
            //calculate speed due to gravity
            
            Vector3 move = new Vector3(dir.x, 0f, dir.y);
            move = m_playerSpeed * Time.deltaTime * move;
            //move.y = transform.position.y;
            //move += gravityMove;
            controller.Move(move);
        }
        


    }

    public IEnumerator Respawn(Vector3 pos)
    {
        transform.position = pos;
        int i = 0;
        do
        {
            i++;
            transform.position = pos;
            yield return new WaitForEndOfFrame();
        } while (transform.position != pos);
        print($"Set position to {pos} after {i} tries");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            m_isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            print("Hit respawn platform collision");
            //Respawn(respawnPoint.position);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            m_playerSpeed *= 0.75f;
        }
        if (collision.gameObject.CompareTag("Respawn"))
        {
            print("Hit respawn platform trigger");
            StartCoroutine(Respawn(respawnPoint.position));
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            m_canJump = false;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            m_playerSpeed /= 0.75f;
            m_canJump = true;
        }
    }

}
