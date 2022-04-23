using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float speed = 10;

    private bool isCoolDown = false;
    private float coolDown = .5f;

    private void Update()
    {
        // Inputs for shooting
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isCoolDown) // Checks if cooldown is false in order to do stuff.
            {
                if (RapidFire.rapidFirePowerUp) // If the rapid fire power up was enabled change speed for rapid fire.
                {
                    coolDown = .1f;
                    Shoot();
                    StartCoroutine(CoolDown());
                }
                else
                {
                    coolDown = .5f;
                    Shoot();
                    StartCoroutine(CoolDown());
                }
            }
        }

        void Shoot()
        {
            var bullet = Instantiate(this.bullet, spawnPoint.position, this.bullet.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * -speed;
        }

        // Sets cooldown for how fast we can shoot bullet. Cant shoot if cooldown is true.
        IEnumerator CoolDown()
        {
            isCoolDown = true;
            yield return new WaitForSeconds(coolDown);
            isCoolDown = false;
        }
    }
}