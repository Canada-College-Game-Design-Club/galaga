using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCShootingBullet : SideCars
{
    public Transform SpawnPoint;
    public GameObject Bullet;
    public float speed = 10;

    private bool isCoolDown = false;
    private float coolDown = .5f;


    // Update is called once per frame
    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetMouseButtonDown(0))))
        {
            if (!isCoolDown)
            {

                if (SideCars.scG)
                {
                    Shoot();
                    StartCoroutine(CoolDown());
                }
            
            }
        }

        void Shoot()
        {
            var bullet = Instantiate(Bullet, SpawnPoint.position, Bullet.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * speed;
        }

        IEnumerator CoolDown()
        {
            isCoolDown = true;
            yield return new WaitForSeconds(coolDown);
            isCoolDown = false;
        }







    }
}
