using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidFire : MonoBehaviour
{
    public static bool rapidFirePowerUp; // Static allows for rapidFirePowerUp to be used in other scripts. Thanks Serg. We'll never forget you.

    public Vector3 player;

    void Start()
    {
        // Starting field declarations
        rapidFirePowerUp = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Rapid Fire collided with player");
            ActivateRF();
            StartCoroutine(CoolDownRF());
        }
    }

    void ActivateRF()
    {
        player = GameObject.Find("Jeep").transform.position; // Gets the player's position

        transform.position = new Vector3(player.x, player.y - 100, player.z); // We need this because the object shouldn't be destroyed because the script still needs to run.
        Debug.Log("Rapid Fire ON");
    }

    // Cool down for rapid Fire power up. After certain time it sets rapidFirePowerUp to false.
    // After that happens changes are made in ShootingBullet Script
    public IEnumerator CoolDownRF()
    {
        rapidFirePowerUp = true;
        yield return new WaitForSeconds(10f);
        rapidFirePowerUp = false;

        Destroy(gameObject); // Destroys powerful from screen
        Debug.Log("Rapid Fire OFF");
    }
}