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
            if (isCoolDown == false)
            {
                // Shooting
                Shoot();

                // Starting the cooldown
                StartCoroutine(CoolDown());
            }
        }        
    }

    // Method for shooting
    void Shoot()
    {
        // Creating the new bullet.
        var bullet = Instantiate(bulletObject, spawnPoint.position, bulletObject.transform.rotation);

        // Using physics compmonent to move the bullet forward.
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }

    // Cooldown
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }
}
