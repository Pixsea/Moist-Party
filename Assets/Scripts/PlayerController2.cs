using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public int playerNum;

    //private CharacterController controller;
    private Rigidbody rigidbody;
    private CapsuleCollider collider;
    private float distToGround;

    public float speed = 10f;
    public float jumpPower = 10f;
    public float gravityPower = 1f;  // How much to increase gravity by

    private Vector3 playerVelocity;
    private bool isGrounded;
    public LayerMask ground;

    private bool m_canJump = true;

    [HideInInspector]
    public bool lockMovement = false;  //Whether the player's movement should locked
    public bool keepMovementLocked = false;  // Whether the movement should always be locked

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //controller = gameObject.GetComponent<CharacterController>();
        collider = gameObject.GetComponent<CapsuleCollider>();

        distToGround = collider.height;
    }

    private void Update()
    {
        Debug.Log(isGrounded);
        // Jump
        if (Input.GetButtonDown("Jump" + playerNum.ToString()) && isGrounded && m_canJump && !lockMovement && !keepMovementLocked)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpPower * -3.0f * gravityPower);
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpPower), ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lockMovement && !keepMovementLocked)
        {
            Move();
        }
        
        Gravity();
    }


    private void Move()
    {
        // Get the direction the player is moving
        Vector3 move = new Vector3(Input.GetAxis("Horizontal" + playerNum.ToString()), 0, Input.GetAxis("Vertical" + playerNum.ToString()));

        // Rotate character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Apply movements
        rigidbody.MovePosition(rigidbody.position + move * speed * Time.fixedDeltaTime);
    }



    private void Gravity()
    {

        //isGrounded = controller.isGrounded;
        isGrounded = CheckGrounded();

        // If touching the ground, set y velocity toxzero if fallign so that they dont fall through the floor
        if (isGrounded && rigidbody.velocity.y < 0)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        }

        // Apply gravity, higher gravuty increases fall speed, but requires higher jump power
        if (!isGrounded)
        {
            if (Input.GetButton("Jump" + playerNum.ToString()))
            {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * gravityPower * Time.deltaTime;
            }
            else
            {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * gravityPower * Time.deltaTime * 2;
            }
        }
    }

    bool CheckGrounded()
    {
        return Physics.CheckBox(transform.position - new Vector3(0, distToGround / 2 - .9f, 0), new Vector3(collider.radius*2, .1f, collider.radius*2), Quaternion.identity, ground);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            speed *= 0.5f;
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
            speed /= 0.5f;
            m_canJump = true;
        }
    }
}
