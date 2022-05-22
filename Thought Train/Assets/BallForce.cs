using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    public Vector2 ballForce;
    public Vector2 ballPush;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(ballForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     GameObject collisionGameObject = collision.gameObject;
    //     PlayerMovement playerMovement = collisionGameObject.GetComponent<PlayerMovement>();
    //     // if (collisionGameObject.tag == "KnockCheck" && playerMovement.beingPushed == false)
    //     if (collisionGameObject.tag == "KnockCheck")
    //     {
    //         collisionGameObject.SetActive(false);
    //         //Getting rigidbody of player through knockback collider child
    //         Rigidbody2D pushObject = playerMovement.gameObject.GetComponent<Rigidbody2D>();
    //         // pushObject.isKinematic = false;
    //         Vector2 difference = transform.position - collisionGameObject.transform.position;
    //         difference = difference.normalized * ballPush;
    //         pushObject.AddForce(difference, ForceMode2D.Impulse);
    //         playerMovement.getPushed();
    //         Debug.Log("Ball pushed the player!");
    //     }
    // }
}
