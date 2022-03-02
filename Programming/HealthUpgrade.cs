using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    // Fields
    int healthToUpgrade; // This is how much the health will go up.

    // Start is called before the first frame update
    void Start()
    {
        // Setting the starting health to 5.
        healthToUpgrade = 5;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Checks if the the health upgrade is touching the player.
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Increasing health");

            // Increases the players health through the other script.
            PlayerHealth.health = PlayerHealth.health + healthToUpgrade;

            Debug.Log("New health: " + PlayerHealth.health);
        }
    }
}
