using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is only for the wall that destroys the bullet after it collides 
public class DestroyBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            //  Destroy(gameObject);
        }
    }
}