using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private ObjectHealth objectHealth;

    private void Start()
    {
        objectHealth = this.GetComponent<ObjectHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            objectHealth.TakeDamage(25);
        }
    }
}
