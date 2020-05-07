using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        //obj.GetComponent<HealthHandler>().SubtractHealth(aNumber);
    }
}
