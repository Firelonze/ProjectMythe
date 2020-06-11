using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollision : MonoBehaviour
{
    private int damage = 25;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WeaponEnemy")
        {
            GetComponentInParent<ObjectHealth>().TakeDamage(25);
        }
    }
}
