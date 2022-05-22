using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject vision;
    // Start is called before the first frame update
    void Start()
    {
        // vision = GameObject.Find("CanvasVision");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            vision.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            vision.SetActive(false);
        }
    }
}
