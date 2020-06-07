using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WeaponEnemy")
        {
            this.GetComponent<ObjectHealth>().TakeDamage(25);
        }
    }
}
