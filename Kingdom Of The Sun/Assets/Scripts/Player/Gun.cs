using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 15f;
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
        }
    }



    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            ObjectHealth target = hit.transform.GetComponent<ObjectHealth>();
            if (target.gameObject.layer == 15)
            {
                target.TakeDamage(damage);
            }
            if (target.gameObject.layer == 16)
            {
                Destroy(target.gameObject);
            }



            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }



            GameObject impactObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
