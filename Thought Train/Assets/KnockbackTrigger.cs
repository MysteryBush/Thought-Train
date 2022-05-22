using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTrigger : MonoBehaviour
{
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        BallForce ballForce = collisionGameObject.GetComponent<BallForce>();
        // if (collisionGameObject.tag == "KnockCheck" && playerMovement.beingPushed == false)
        if (collisionGameObject.tag == "Ball")
        {
            gameObject.SetActive(false);
            //Getting rigidbody of player through knockback collider child
            Rigidbody2D pushObject = playerMovement.gameObject.GetComponent<Rigidbody2D>();
            // pushObject.isKinematic = false;
            // Vector2 difference = transform.position - collisionGameObject.transform.position;
            // difference = difference.normalized * ballForce.ballPush;
            //push horizontally
            Vector2 difference = transform.position - collisionGameObject.transform.position;
            // difference = new Vector2(difference.normalized.x, 1);
            // Debug.Log("difference normalized = " + difference);

            float xValue = difference.x > 0 ? 1 : -1;
            difference = new Vector2(xValue, 1);

            difference = difference * ballForce.ballPush;
            Debug.Log("difference = " + difference);
            pushObject.AddForce(difference, ForceMode2D.Impulse);
            playerMovement.getPushed();
            // Debug.Log("Ball pushed the player!");
        }
    }
}
