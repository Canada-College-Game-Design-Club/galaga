using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFire : MonoBehaviour
{
    public static bool rapidFirePowerUp; // static allows for rapidFirePowerUp to be used in other scripts
    public GameObject rapidFire;
    public Vector3 player;




    void Start()
    {
        //starting instances
        rapidFire = GameObject.Find("RapidFire");
      
        rapidFirePowerUp = false;


    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Activate RapidFire");
            ActivateRF();
            StartCoroutine(rfCoolDown());
           
        }
    }


    void ActivateRF()
    {

        player = GameObject.Find("Player").transform.position; //gets the player object

        transform.position = new Vector3(player.x, player.y-100, player.z); // sets sidecar next to player
        Debug.Log("Rapid Fire Activated");
    }



    // cool down for rapid Fire power up. After certain time it sets rapidFirePowerUp to false.
    // after that happens changes are made in ShootingBullet Script
    public IEnumerator rfCoolDown()
    {
        rapidFirePowerUp = true;
        yield return new WaitForSeconds(10f);
        rapidFirePowerUp = false;
        Destroy(gameObject); //destroys powerup from screen
        Debug.Log("Rapid Fire OFF");
    }

}
