using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "ScrapMetal" && collision.gameObject.tag != "Gun" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "ScrapMetal")
        {
            Debug.Log("Scrap Metal hit");
            BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
            powerUp.isTrigger = true;
        }
    }
}
