using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrain : MonoBehaviour
{
    bool allowedToStart;
    Rigidbody rigidbody;
    float speed = 10.0f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(start());
    }

    void Update()
    {
        if (allowedToStart) 
        {
            rigidbody.velocity = transform.forward * speed * Time.deltaTime;
        }
    }

    IEnumerator start() 
    {
        yield return new WaitForSeconds(10);
        allowedToStart = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9) 
        {
            // palyer health er af
        }
        if (other.gameObject.layer == 10) 
        {
            // boss neemt damage
        }
        if (other.gameObject.layer == 11) 
        {
            //andere baas weer aan
            // voer reappear void uit
            // boss despawned
        }
    }
}
