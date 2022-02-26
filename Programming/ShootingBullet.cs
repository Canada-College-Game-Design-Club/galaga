using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    // Public fields (Specify these through the inspector)
    public Transform spawnPoint;
    public GameObject bulletObject;
    public float speed = 10;

    private bool isCoolDown = false;
    private float coolDown = .5f;

    // Update is called once per frame
    void Update()
    {
        // Checking what keys are being pressed and shooting.
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            // Checking the state of the cooldown.
            if (!isCoolDown)
            {
                // Shooting
                Shoot();

                // Starting the cooldown
                StartCoroutine(CoolDown());
            }
        }
        if (!isCoolDown && GameObject.Find("ScrapMetal") != null)
        {
            BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
            powerUp.isTrigger = false;
        }
    }

    // Method for shooting
    void Shoot()
    {
        // Creating the new bullet.
        var bullet = Instantiate(bulletObject, spawnPoint.position, bulletObject.transform.rotation);

        if (GameObject.Find("ScrapMetal") != null)
        {
            BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
            powerUp.isTrigger = false;
        }

        // Using physics compmonent to move the bullet forward.
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }

    // Cooldown
    IEnumerator CoolDown()
    {
        if (GameObject.Find("ScrapMetal") != null)
        {
            BoxCollider powerUp = GameObject.Find("ScrapMetal").GetComponent<BoxCollider>() as BoxCollider;
            powerUp.isTrigger = true;
        }

        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }
}
