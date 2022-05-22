using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public float onSlowSpeed = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            Rigidbody2D slowObject = collisionGameObject.GetComponent<Rigidbody2D>();
            PlayerMovement playerMovement = collisionGameObject.GetComponent<PlayerMovement>();
            slowObject.velocity *= 999f/1000f;
            playerMovement.walkSpeed = onSlowSpeed;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            Rigidbody2D slowObject = collisionGameObject.GetComponent<Rigidbody2D>();
            PlayerMovement playerMovement = collisionGameObject.GetComponent<PlayerMovement>();
            slowObject.velocity *= 0;
            playerMovement.walkSpeed = playerMovement.walkSpeedInitial;
        }
    }
}
