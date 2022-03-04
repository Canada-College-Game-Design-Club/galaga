using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour
{
    public HealthBar healthBar;


    public Text test;
    public bool flag = false;



    // Fields
    int healthToUpgrade; // This is how much the health will go up.

    // Start is called before the first frame update
    void Start()
    {
        // Setting the starting health to 5.
        healthToUpgrade = 5;

        test.text = " ";
        flag = false;
        
     }

    void OnCollisionEnter(Collision collision)
    {
        // Checks if the the health upgrade is touching the player.
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerHealth.health < 100)
            {
                Debug.Log("Increasing health");

                // Increases the players health through the other script.
                PlayerHealth.health = PlayerHealth.health + healthToUpgrade;
                flag = true;
                IncreaseHealth();

                StartCoroutine(oneSecond());
                
                
                Debug.Log("New health: " + PlayerHealth.health);

            }
        }
       


    }
    public IEnumerator oneSecond()
    {
        flag = false;
        yield return new WaitForSeconds(.25f);
        IncreaseText();

    }

    void IncreaseHealth()
    {

        if (flag)
        {
            test.text = "+ 5";
        }
        PlayerHealth.currentHealth += healthToUpgrade;
        healthBar.SetHealth(PlayerHealth.currentHealth);

    }
    void IncreaseText()
    {
        flag = false;
        if (!flag)
        {
            test.text = "";
        }

    }

}   
