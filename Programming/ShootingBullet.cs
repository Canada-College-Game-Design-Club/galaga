using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : RapidFire //ShootingBullet inherets RapidFire Script
{

    public Transform spawnPoint;
    public GameObject bullet;
    public float speed = 10;

    private bool isCoolDown = false;
    private float coolDown = .5f;


    // Update is called once per frame
    private void Update()
    {
        // inputs for shooting
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetMouseButtonDown(0))))
        {
            if (!isCoolDown)//checks if cooldown is false in order to do stuff.
            {

                if (rapidFirePowerUp) //if the rapid fire powerup was enabled change speed for rapid fire.
                {

                    coolDown = .1f;
                    Shoot();
                    StartCoroutine(CoolDown());
                }
                else //if rapidFirePowerUp isn't on set the cooldown back to normal and proceed to normal shots. 
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
            bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
        }

        //sets cooldown for how fast we can shoot bullet. Cant shoot if cooldown is true.
        IEnumerator CoolDown()
        {
            isCoolDown = true;
            yield return new WaitForSeconds(coolDown);
            isCoolDown = false;
        }







    }
}
