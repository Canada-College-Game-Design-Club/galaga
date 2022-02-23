using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Collider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>();

        // Check if the object hit is the scrap metal. if it is not the scrap metal than Destroy.
        if (Vector3.Distance(powerUp.transform.position, gameObject.transform.position) < 5)
        {
            Destroy(gameObject, life);//bullet destroy object
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "ScrapMetal" && collision.gameObject.tag != "Gun" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
