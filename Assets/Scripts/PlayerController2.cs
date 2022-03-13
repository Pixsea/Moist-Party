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


    // Knockback avriables
    private bool beingKnockbacked;
    private Vector3 knockbackAngle;
    private float knockbackStrength;
    private float knockbackDelay;  // How long before the player can be knocked back again
    private bool knockbackRefresh = false;  //A bool that controls how long knockback must eb applied for before stopping


    [SerializeField]
    private Animator playerAnimator;

    private bool canAttack = true;

    [SerializeField]
    private bool attackEnabled = true;

    private ParticleSystem particles;
    private bool particlesPlaying;

    private bool alreadyLanded = true;
    private bool landRefresh = false;


    private bool walking = false;
    private float footstepNoiseRate = .4f;

    [SerializeField]
    private SkinnedMeshRenderer playerRenderer;

    [SerializeField]
    private Material[] playerSlimeMaterials;

    [SerializeField]
    private GameObject manager; // USed for concentration minigame




    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //controller = gameObject.GetComponent<CharacterController>();
        collider = gameObject.GetComponent<CapsuleCollider>();
        particles = gameObject.GetComponent<ParticleSystem>();
        if (particles) { particles.Stop(); }
        ParticleSystem.MainModule settings = particles.main;
        settings.startColor = gameObject.GetComponentInChildren < SkinnedMeshRenderer > ().material.color;
        distToGround = collider.height;

        //playerRenderer.material = playerSlimeMaterials[playerNum];
        settings.startColor = playerSlimeMaterials[playerNum-1].color;
    }

    private void Update()
    {
        if (isGrounded)
        {
            // Ensures soudn only plays once upon landing
            if (landRefresh)
            {
                Debug.Log("PAIN2");
                SoundManager.instance.PlaySound("land");
                if (!particlesPlaying)
                {
                    Debug.Log("Start Coroutine" + gameObject.name);
                    StartCoroutine(PlayParticles());
                }
                landRefresh = false;

                if (!particlesPlaying)
                {
                    Debug.Log("Start Coroutine" + gameObject.name);
                    StartCoroutine(PlayParticles());
                }
            }
        }

        //Debug.Log(isGrounded);
        // Jump
        if (Input.GetButtonDown("Jump" + playerNum.ToString()) && isGrounded && m_canJump && !lockMovement && !keepMovementLocked)
        {
            Debug.Log("We're trying jump");
            //playerVelocity.y += Mathf.Sqrt(jumpPower * -3.0f * gravityPower);
            SoundManager.instance.PlaySound("jump");
            StartCoroutine(LandWait(.2f));
            rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpPower), ForceMode.VelocityChange);
            
        }

        if (Input.GetButtonDown("Jump" + playerNum.ToString()) && !lockMovement && !keepMovementLocked && canAttack && attackEnabled)
        {
            canAttack = false;

            StartCoroutine(Attack());
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

        //Debug.Log(beingKnockbacked);
        if (beingKnockbacked)
        {
            rigidbody.AddForce(knockbackAngle * knockbackStrength * Time.fixedDeltaTime, ForceMode.VelocityChange);


            // STop applying knockback when it hits the ground or after a delay
            if (CheckGrounded() && !knockbackRefresh)
            {
                beingKnockbacked = false;
            }
        }
    }


    private void Move()
    {
        // Get the direction the player is moving
        Vector3 move = new Vector3(Input.GetAxis("Horizontal" + playerNum.ToString()), 0, Input.GetAxis("Vertical" + playerNum.ToString()));

        // Rotate character and start footsteps if starting to walk
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

            if (walking == false)
            {
                walking = true;
                StartCoroutine(StartFoosteps());
                
            }

            playerAnimator.SetBool("Moving", true);
        }
        else
        {
            walking = false;
            playerAnimator.SetBool("Moving", false);
        }

        //playerAnimator.SetFloat("Speed", )

        // Apply movements
        rigidbody.AddForce(move * speed, ForceMode.VelocityChange);
    }



    private void Gravity()
    {
        isGrounded = CheckGrounded();
        //Debug.Log(CheckGrounded());


        // If touching the ground, set y velocity to zero if falling so that they dont fall through the floor
        if (isGrounded && rigidbody.velocity.y < 0)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, -.05f, rigidbody.velocity.z);
        }

        // Apply gravity, higher gravuty increases fall speed, but requires higher jump power
        if (!isGrounded)
        {
            if (Input.GetButton("Jump" + playerNum.ToString()))
            {
                // Apply less gravity if holding jump for a floaty jump
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
        //Debug.DrawLine(transform.position, transform.position - new Vector3(0, distToGround / 2, 0), Color.cyan);
        //return Physics.Raycast(transform.position, -Vector3.up, distToGround / 2);
        return Physics.CheckBox(transform.position - new Vector3(0, distToGround / 2 - .9f, 0), new Vector3(collider.radius, .05f, collider.radius), Quaternion.identity, ground);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Slime")
        {
            speed *= 0.5f;
        }

        if (manager != null)
        {
            collision.GetComponent<CardScript>().player = playerNum;
            //collision.GetComponent<CardScript>().StartFlip();
            manager.GetComponent<ConcentrationManager>().Flip(collision.gameObject, collision.GetComponent<CardScript>().index);
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


    public void ApplyKnockback(Vector3 direction, float horizontalPower, float verticalPower, float delay)
    {
        // Upwards knockback
        if (!beingKnockbacked)
        {
            rigidbody.AddForce(Vector3.up * verticalPower, ForceMode.VelocityChange);
        }

        //SoundManager.instance.PlaySound("ow");

        SoundManager.instance.PlaySound("punch");
        if (!particlesPlaying)
        {
            Debug.Log("Start Coroutine" + gameObject.name);
            StartCoroutine(PlayParticles());
        }
        StartCoroutine(LandWait(.2f));

        knockbackRefresh = true;

        knockbackAngle = direction;
        knockbackStrength = horizontalPower;
        knockbackDelay = delay;

        beingKnockbacked = true;

        StartCoroutine(KnockbackWait(knockbackDelay));
    }

    public IEnumerator KnockbackWait(float delay)
    {
        yield return new WaitForSeconds(delay);

        knockbackRefresh = false;

        yield return new WaitForSeconds(delay);

        beingKnockbacked = false;

        yield return null;
    }

    public IEnumerator LandWait(float delay)
    {
        yield return new WaitForSeconds(delay);

        landRefresh = false;

        yield return new WaitForSeconds(delay);

        landRefresh = true;

        yield return null;
    }



    IEnumerator Attack()
    {
        playerAnimator.SetTrigger("Punch");

        Collider[] hits = Physics.OverlapBox(transform.position + (transform.forward * 1), new Vector3(1, 2, .2f), transform.rotation);
        for (int i = 0; i < hits.Length; i++)
        {
            if ((hits[i].tag == "Player")  && (hits[i].gameObject != gameObject))
            {
                hits[i].GetComponent<PlayerController2>().ApplyKnockback(transform.forward, 400, 20, 1f);
                //Debug.Log("test");
            }
        }
        yield return new WaitForSeconds(.5f);

        canAttack = true;

        yield return null;
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position - new Vector3(0, distToGround / 2 - .9f, 0), new Vector3(collider.radius, .05f, collider.radius));
    //}

    //Activate the particle system and then stop it after it's done.
    public IEnumerator PlayParticles()
    {
        if(particles != null)
        {
            particles.Play();
            particlesPlaying = true;
            Debug.Log("We should play particles now");
            yield return new WaitForSeconds(0.5f);
            particles.Stop();
            particlesPlaying = false;
            Debug.Log("We should stop particles now");
        }

        yield return null;
    }



    IEnumerator StartFoosteps()
    {
        while (walking)
        {
            SoundManager.instance.PlaySound("step");

            if (walking)
            {
                yield return new WaitForSeconds(footstepNoiseRate);
            }
        }
        yield return null;
    }
}
