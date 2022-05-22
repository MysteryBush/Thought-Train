using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    public KnockbackTrigger knockbackTrigger;
    //Initial runSpeed
    public float walkSpeedInitial = 50f;
    public float walkSpeed = 40f;
    float horizontalMove = 0f;
    [SerializeField] bool jump = false;
    //running
    public float runSpeed = 60f;
    bool run = false;

    // condition on being pushed
    public bool beingPushed = false;
    public float knockoutTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        walkSpeed = walkSpeedInitial;
        beingPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPushed == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Jump2"))
            {
                jump = true;
            }
        }

    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false;

        Animating(horizontalMove);
        anim.SetFloat("Horizontal", horizontalMove);
    }

    public void getPushed()
    {
        StartCoroutine(boolPushed());
    }

    IEnumerator boolPushed()
    {
        // Debug.Log("Player just got pushed");
        beingPushed = true;
        horizontalMove = 0;

        if (beingPushed == true)
        {
            yield return new WaitForSeconds(knockoutTime);
            rb.velocity = Vector2.zero;
            // rb.isKinematic = true;
            beingPushed = false;
            knockbackTrigger.gameObject.SetActive(true);
            // Debug.Log("Player is not being pushed");
        }
        yield return null;
    }

    void Animating(float x)
    {
        bool isWalking = x != 0f;
        anim.SetBool("isWalking", isWalking);

        // bool isJumping = jump;
        // anim.SetBool("isJumping", isJumping);
        anim.SetBool("isJumping", jump);

        anim.SetBool("isRunning", run);
    }
}
