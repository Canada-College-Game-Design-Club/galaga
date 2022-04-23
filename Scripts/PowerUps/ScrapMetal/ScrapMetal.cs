using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapMetal : MonoBehaviour
{
    public GameObject shield;
    public GameObject shieldPrefab;

    public Vector3 player;
    public bool isActivated;

    void Start()
    {
        // Setting the starting fields
        isActivated = false;

        // Note we shouldn't declare the player vector3 here because it will only get the CURRENT position of the player.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")// Checks to see if the collision is with the Player
        {
            Debug.Log("Player has collided with the Scrap Metal");
            ActivateShield();
            StartCoroutine(PowerUpCoolDown());
        }
    }

    // Timer that destroys PowerUp after a set time.
    public IEnumerator PowerUpCoolDown()
    {
        yield return new WaitForSeconds(10);

        if (gameObject.tag == "ScrapMetal")
        {
            isActivated = false;
            Destroy(gameObject);
            Destroy(shield);
        }

        Debug.Log("Scrap Metal OFF");
    }

    void ActivateShield()
    {
        // When the jeep collides with the toolbox it should spawn a prefab that acts as a shield surrounding the front half
        // of the jeep. The toolbox should then be destroyed as the shield is now spawned and parented to the jeep.

        Vector3 pos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z - 5);

        shield = Instantiate(shieldPrefab, pos, transform.rotation); // Spawns the shield
        shield.transform.parent = GameObject.Find("Jeep").transform; // Parent the shield to the jeep

        player = GameObject.Find("Jeep").transform.position; // Finds player and its positions

        gameObject.transform.position = new Vector3(player.x, player.y - 100, player.z); // Sends the toolbox away

        isActivated = true;

        // Commented out for now. This makes it so bullets can go through the scrap metal. We're probably going to change this.

        // BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
        // powerUp.isTrigger = true;

        Debug.Log("Scrap Metal ON");
    }
}