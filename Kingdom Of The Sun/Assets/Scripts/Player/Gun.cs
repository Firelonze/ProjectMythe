using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 100f;
    public float impactForce = 30f;
    
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    
    private float nextTimeToFire = 0f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            print(hit.collider.gameObject.name + " Layer:" + hit.collider.gameObject.layer);
            if (hit.transform.gameObject.layer == 15)
            {
                ObjectHealth target = hit.transform.GetComponent<ObjectHealth>();
                target.TakeDamage(damage);
            }
            if (hit.transform.gameObject.layer == 16)
            {
                Debug.Log("Jews");
                Destroy(hit.transform.gameObject);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }



            //GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
