using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_playerSpeed = 10.0f;
    public float m_jumpSpeed = 10.0f;
    public float m_gravityValue = -9.81f;
    public int playerNum;

    public LayerMask groundLayers;

    [HideInInspector]
    public bool lockMovement = false;  //Whether the player's movement should be able to move
    public bool keepMovementLocked = false;  // Whether the movement should always be locked

    private CharacterController controller;
    private Rigidbody rigidbody;
    private Animator animator; 
    private CapsuleCollider collider;
    private Vector3 playerVelocity;
    private bool playerGrounded;
    private float verticalSpeed;
    private bool m_isGrounded;

    private bool m_canJump = true;

    float distToGround; // the distance between the center of the rigid boidy to the ground to draw a raycast to check if grounded

    private void Start()
    {
        // for movement 
        rigidbody = gameObject.GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>(); 
        collider = gameObject.GetComponent<CapsuleCollider>();

        // get the distance to ground
        float distToGround = collider.bounds.extents.y;
    }

    void Update()
    {
        Move3();
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
            
            //if (IsGrounded()) {
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
        playerGrounded = controller.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
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

        if (Input.GetButton("Jump" + playerNum.ToString()) && playerGrounded  && !lockMovement)
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


    private void Move2()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (!lockMovement && !keepMovementLocked)
        {
            float horizontalMove = Input.GetAxis("Horizontal" + playerNum.ToString());
            float verticalMove = Input.GetAxis("Vertical" + playerNum.ToString());

            Debug.Log(IsGrounded());

            if (IsGrounded())
            {
                if (Input.GetButton("Jump" + playerNum.ToString()) && m_canJump == true)
                {
                    verticalSpeed = m_jumpSpeed;
                }
                //else
                //{
                //    verticalSpeed = 0;
                //}
            }
            else if (Input.GetButton("Jump" + playerNum.ToString()))
            {
                // Makes it so that if you hold the jump button in the air, you fall slower,
                // can probably make it less floaty by adding half the gravityValue to verticalSpeed here

                verticalSpeed += m_gravityValue * Time.deltaTime *.5f;
            }
            else
            {
                verticalSpeed += m_gravityValue * Time.deltaTime;
            }


            Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
            Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
            controller.Move(m_playerSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
        }
    }


    private void Move3()
    {
        playerGrounded = controller.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal" + playerNum.ToString()), 0, Input.GetAxis("Vertical" + playerNum.ToString()));
        move *= m_playerSpeed;
        //controller.Move(move * Time.deltaTime * m_playerSpeed);


        // Rotate character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player/make player jump
        if (Input.GetButton("Jump" + playerNum.ToString()) && playerGrounded && m_canJump)
        {
            playerVelocity.y += Mathf.Sqrt(m_jumpSpeed * -3.0f * m_gravityValue);
        }

        // Apply gravity
        if (!playerGrounded && Input.GetButton("Jump" + playerNum.ToString()))
        {
            playerVelocity.y += m_gravityValue * Time.deltaTime;
        }
        else if (!playerGrounded && !Input.GetButton("Jump" + playerNum.ToString()))
        {
            playerVelocity.y += m_gravityValue * Time.deltaTime * 2;
        }

        //playerVelocity.y += m_gravityValue * Time.deltaTime;


        // Apply movements
        controller.Move(move * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);
    }


    // private void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag == "Pad")
    //     {
    //         //Destroy(collider.gameObject);
    //         Debug.Log("PAD TRIGGER");
    //     }
    // }


    bool IsGrounded()
    {
        //return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        return Physics.CheckBox(transform.position - new Vector3(0, distToGround, 0), new Vector3(.5f, .1f, .5f));
        
    }

    // Fucntion to show box check for if the player is grounded
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position - new Vector3(0, distToGround, 0), new Vector3(.5f, .1f, .5f));
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("SOME COLLISION");
        m_isGrounded = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            m_playerSpeed *= 0.75f;
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
