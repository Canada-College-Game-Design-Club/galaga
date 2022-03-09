using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCShootingBullet : MonoBehaviour // SCShootingBullet inherets SideCars Script, can use variables from SideCars.cs
{
    //allows for an empty object to become the spawn point once in the scene.
    public Transform spawnPoint;
    //allows for the bullet prefab to be put in place
    public GameObject bullet;
    //the speed of the bullet once it spawns in
    public float speed = 10;

    //The True or False of isCoolDown is what is checked when checking to shoot again.
    private bool isCoolDown = false;
    // 0.0f <- value placed there is the amount of seconds for the coolDown
    private float coolDown = .3f;


    // Update is called once per frame
     void Update()
    {
        //checks to see if cool down is off
        if (!isCoolDown)
        {
            //checks to see if sideCarGun is activated in the SideCars.cs Script
            if (SideCars.sideCarGun)
            {
                //enables shooting
                Shoot();

                //starts countdown to make the shooting cool down actually work.
                StartCoroutine(CoolDown());
            }
        }

    }
    // Shooy(); calls to here and this is what allows the bullet to be initianted at the SpawnPoint and shoots it
    void Shoot()
    {
        var bullet = Instantiate(this.bullet, spawnPoint.position, this.bullet.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * speed;
    }


    //CoolDown for the shooting speed.
    IEnumerator CoolDown()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(coolDown);
        isCoolDown = false;
    }



}
