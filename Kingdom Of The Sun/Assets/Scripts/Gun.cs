using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public Rigidbody bullet;
    public float bulletSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Rigidbody bulletRigidbody;
            bulletRigidbody = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;
            bulletRigidbody.AddForce(bulletSpawn.forward * bulletSpeed * Time.deltaTime);
        }
    }
}
