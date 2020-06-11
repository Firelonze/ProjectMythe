using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private ObjectHealth objectHealth;

    private int damage;

    private void Start()
    {
        objectHealth = GetComponentInParent<ObjectHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            objectHealth.TakeDamage(damage);
        }
    }

    public void setDamage(int tempDamage)
    {
        damage = tempDamage;
    }
}
