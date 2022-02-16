using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{

    /*
    Notes:
    1. Add hitting object in this script, not a new one... it was added in a new one to get the game object, but use the examples in this file to avoid that. (GameObject.Find("GameObject"))
        |_ Add this to ShootBullet method
     */

    // Public fields (Accessible throughout the project and on the inspector in the script component)
    public Transform spawnPoint;
    public GameObject bulletObject;
    public float speed;

    // Private fields (Only accessible in this file)
    private Rigidbody bulletRigidbody;
    private bool isCoolDown;
    private float coolDown;


    // Called once before the first frame.
    void Start()
    {
        // Defining starting variables
        speed = 10;
        isCoolDown = false;
        coolDown = 0.5f;

        // This gets the position of the "Gun" and stores it into a Transform variable. Note a Transform is NOT the same as a Vector3!
        spawnPoint = GameObject.Find("Gun").transform;

        // This store the GameObject "Bullet" in a GameObject variable.
        bulletObject = GameObject.Find("Bullet");

        // This gets the Rigidbody component of our "Bullet". You must add this component to the GameObject for it to work.
        bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        // Checks if the key pressed is "space" or the "up arrow".
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            // Checks if the cooldown is false (AKA if the cooldown is over)
            if (isCoolDown == false)
            {
                // Calls the "ShootBullet" function that makes the bullet go across the screen.
                ShootBullet();

                // Starts the cooldown.
                StartCoroutine(CoolDown());
            }
        }      
    }

    // This method handles the bullet moving across the screen and what occurs when something hits it.
    void ShootBullet()
    {
        // Creates a new GameObject for each time the user shoots.
        var bullet = Instantiate(bulletObject, spawnPoint.position, bulletObject.transform.rotation);

        // Moves the bullet across the screen.
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }

    // This handles the cooling down for when the user can shoot, to avoid the user spamming.
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }
}
