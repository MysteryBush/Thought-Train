using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] private Rigidbody2D rb;
    public KnockbackTrigger knockbackTrigger;
    //Initial runSpeed
    public float runSpeedInitial = 50f;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    // condition on being pushed
    public bool beingPushed = false;
    public float knockoutTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        runSpeed = runSpeedInitial;
        beingPushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (beingPushed == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

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
    }

    public void getPushed()
    {
        StartCoroutine(boolPushed());
    }

    IEnumerator boolPushed()
    {
        Debug.Log("Player just got pushed");
        beingPushed = true;
        horizontalMove = 0;

        if (beingPushed == true)
        {
            yield return new WaitForSeconds(knockoutTime);
            rb.velocity = Vector2.zero;
            // rb.isKinematic = true;
            beingPushed = false;
            knockbackTrigger.gameObject.SetActive(true);
            Debug.Log("Player is not being pushed");
        }
        yield return null;
    }
}
