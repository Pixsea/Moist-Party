using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationPlayerController : MonoBehaviour
{
    public float m_playerSpeed = 10.0f;
    public float m_jumpSpeed = 10.0f;
    public float m_gravityValue = -9.81f;
    public int playerNum;

    public LayerMask groundLayers;

    public GameObject manager;

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

    private bool m_canJump = true;

    private void Start()
    {
        // for movement 
        rigidbody = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); 
        collider = gameObject.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        /*
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        float horizontalMove = Input.GetAxis("Horizontal" + playerNum.ToString());
        float verticalMove = Input.GetAxis("Vertical" + playerNum.ToString());

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

        rigidbody.AddForce(movement * m_playerSpeed);

        if (Input.GetButton("Jump" + playerNum.ToString())) {
            rigidbody.AddForce(Vector3.up * m_jumpSpeed, ForceMode.Impulse);
        }
        /*/
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!lockMovement && !keepMovementLocked) {
            float horizontalMove = Input.GetAxis("Horizontal" + playerNum.ToString());
            float verticalMove = Input.GetAxis("Vertical" + playerNum.ToString());
            
            if (m_isGrounded) {
                if (Input.GetButton("Jump" + playerNum.ToString()) && m_canJump == true) {
                    verticalSpeed = m_jumpSpeed;
                } else {
                    verticalSpeed = 0;
                }
            } else {
                verticalSpeed += m_gravityValue * Time.deltaTime;
            }
            

            Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
            Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
            controller.Move(m_playerSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
        }
        


        /*
        // stop rotating randomly
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // update y velocity when player touches ground
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // move player along x and z axis
        Vector3 move = new Vector3(Input.GetAxis("Horizontal" + playerNum.ToString()), 0, Input.GetAxis("Vertical" + playerNum.ToString()));

        // If movement is locked, set velocity to zero
        if (lockMovement || keepMovementLocked)
        {
            move = Vector3.zero;
        }

        controller.Move(move * Time.deltaTime * m_playerSpeed);

        // if player is moving, make them move
        if (move.x != 0 && move.z != 0)
        {
            animator.SetInteger("condition",1); //changes animation from idle to walking if they are moving 
            gameObject.transform.forward = move;
        }

        if (move == Vector3.zero)
        {
            animator.SetInteger("condition",0); //this chnages walking animation to idle animation 
        }

        // Changes the height position of the player..

        if (Input.GetButton("Jump" + playerNum.ToString()) && groundedPlayer  && !lockMovement)
        {
            Debug.Log("Jump recognized");
            // initial vertical velocity calculation
            playerVelocity.y = Mathf.Sqrt(- m_jumpHeight * m_gravityValue);
        }

        // drag player down with gravity
        playerVelocity.y += m_gravityValue * Time.deltaTime;
        
        //Debug.Log(playerVelocity.y);

        // move player with their velocity
        //controller.Move(playerVelocity * Time.deltaTime);
        */
    }


    // private void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Pad")
    //     {
    //         //Destroy(collider.gameObject);
    //         Debug.Log("PAD TRIGGER");
    //     }
    // }
    
    
   

    private void OnTriggerEnter(Collider collision)
    {
        collision.GetComponent<CardScript>().player = playerNum;
        //collision.GetComponent<CardScript>().StartFlip();
        manager.GetComponent<ConcentrationManager>().Flip(collision.gameObject, collision.GetComponent<CardScript>().index);
    }

    private void OnTriggerStay(Collider collision)
    {
    }

    private void OnTriggerExit(Collider collision)
    {
    }

}
